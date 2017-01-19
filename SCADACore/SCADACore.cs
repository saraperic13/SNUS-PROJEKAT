using ScadaCommon;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SCADASystem
{
    public delegate void AlarmEvent(Alarm alarm);
    public delegate void TagValueChandedEvent();

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class SCADACore : IAlarmDisplay, IDatabaseManager, ITrending
    {
        private static Dictionary<string, Tag> tags;
        static Dictionary<string, Thread> threads;
        static List<Alarm> alarms;

        static SimulationDriver simulationDriver;
        static object locker = new object();
        static object FileLocker = new object();

        static private event AlarmEvent alarmEvent;
        static int alarmFlag;
        static int updatedTagValueFlag;


        public SCADACore()
        {
            tags = new Dictionary<string, Tag>();
            threads = new Dictionary<string, Thread>();
            alarms = new List<Alarm>();

            alarmFlag = 0;
            updatedTagValueFlag = 0;

            alarmEvent += new AlarmEvent(AlarmHappened);
           
            XmlDeserialisation();
        }

        private static void Main()
        {

            ServiceHost service = new ServiceHost(typeof(SCADACore));

            Uri address = new Uri("net.tcp://" + Constants.IPAddress + ":4000/IAlarmDisplay");
            NetTcpBinding binding1 = new NetTcpBinding();
            binding1.Security.Mode = SecurityMode.None;

            service.AddServiceEndpoint(typeof(IAlarmDisplay), binding1, address);

            address = new Uri("net.tcp://" + Constants.IPAddress + ":4001/IDatabaseManager");
            NetTcpBinding binding2 = new NetTcpBinding();
            binding2.Security.Mode = SecurityMode.None;

            service.AddServiceEndpoint(typeof(IDatabaseManager), binding2, address);

            address = new Uri("net.tcp://" + Constants.IPAddress + ":4002/ITrending");
            NetTcpBinding binding3 = new NetTcpBinding();
            binding3.Security.Mode = SecurityMode.None;

            service.AddServiceEndpoint(typeof(ITrending), binding3, address);

            service.Open();

            DisplayTags();

            Console.WriteLine("WCFServer is running...");

            Thread displayTagsThread = new Thread(DisplayTags);
            displayTagsThread.IsBackground = true;
            displayTagsThread.Start();
            
            Finish();
            service.Close();

        }


        static void SignalTrending() {
            lock (locker) updatedTagValueFlag = 1;
          
        }


        static void AlarmHappened(Alarm alarm)
        {
            lock (locker)
            {
                alarm.Time = DateTime.Now;
                alarms.Add(alarm);
                alarmFlag = 1;
            }

            lock (FileLocker)
            {
                using (StreamWriter sw = File.AppendText("alarmslog.txt"))
                {
                    sw.WriteLine(alarm);
                }
            }

        }


        public bool AddTag(Tag tag)
        {
            lock (locker)
            {
                if (tags.ContainsKey(tag.TagId) || simulationDriver.Addresses.Contains(tag.IOAddress)) return false;

                else
                {
                    tag.SimulationDriver = simulationDriver;
                    tags.Add(tag.TagId, tag);

                    if (tag is InputTag)
                    {
                        InputTag iTag = (InputTag)tag;
                        simulationDriver.WriteTag(0, iTag.IOAddress);

                        if (iTag.Auto)
                        {
                            SimulationOn(tag.TagId);
                        }
                    }
                    else
                    {
                        OutputTag oTag = (OutputTag)tag;
                        simulationDriver.WriteTag(oTag.InitialValue, oTag.IOAddress);

                    }
                    SignalTrending();
                    return true;
                }
            }
        }


        public bool RemoveTag(string tagId)
        {
            lock (locker){

                if (tags.ContainsKey(tagId)){
                   
                    if (tags[tagId] is InputTag && ((InputTag)tags[tagId]).Scan){
                        threads[tagId].Abort();
                        threads.Remove(tagId);
                    }
                    SignalTrending();
                    tags.Remove(tagId);

                    return true;
                }
            }
            return false;
        }


        public void UpdateTag(Tag tag)
        {
            lock (locker)
            {
                if (tag is InputTag)
                {
                    InputTag prevTag = (InputTag)tags[tag.TagId];
                    tags[tag.TagId] = tag;
                    if (!prevTag.Auto && ((InputTag)tag).Auto)
                    {
                        SimulationOn(tag.TagId);
                    }
                    if (prevTag.Auto && ((InputTag)tag).Auto)
                    {
                        SimulationOff(tag.TagId);
                        SimulationOn(tag.TagId);
                    }
                    if (prevTag.Auto && !((InputTag)tag).Auto)
                    {
                        SimulationOff(tag.TagId);
                    }
                    if (!prevTag.Scan && ((InputTag)tag).Scan)
                    {
                        ScanOn(tag.TagId);
                    }
                    if (prevTag.Scan && !((InputTag)tag).Scan)
                    {
                        ScanOff(tag.TagId);
                    }

                }
                else {
                    simulationDriver.WriteTag(((OutputTag)tag).InitialValue, tag.IOAddress);
                    tags[tag.TagId] = tag;
                }
                
                SignalTrending();
            
            }
        }


        public bool AddAlarm(Alarm alarm)
        {
            lock (locker)
            {
                foreach (Alarm a in ((InputTag)tags[alarm.TagId]).Alarms) {
                    if (a.AlarmId.Equals(alarm.AlarmId)) return false;
                }
                ((InputTag)tags[alarm.TagId]).AddAlarm(alarm);
                return true;
                
            }
        }


        public bool RemoveAlarm(string tagId, string alarmId)
        {
            lock (locker)
            {
                ((InputTag)tags[tagId]).RemoveAlarm(alarmId);
                return true;
            }
        }


        public bool ScanOn(string tagId)
        {
            try
            {
                lock (locker)
                {
                    ((InputTag)tags[tagId]).Scan = true;
                    SignalTrending();
                    return true;
                }
            }
            catch (Exception) { return false; }

            
        }

        public bool ScanOff(string tagId)
        {
            try
            {
                lock (locker)
                {
                    ((InputTag)tags[tagId]).Scan = false;
                    SignalTrending();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }


        public void SimulationOff(string tagId) {
            try
            {
                threads[tagId].Abort();
                threads.Remove(tagId);
            }
            catch (Exception) { return; }
        }


        public void SimulationOn(string tagId) {
            
            Thread t = new Thread(new ParameterizedThreadStart(Simulate));
            threads.Add(tagId, t);
            t.Start(tags[tagId]);
        }


        public void Simulate(Object obj)
        {
            InputTag tag = (InputTag)obj;
            double newValue = 0;
            double value;
            bool notInRange;

            while (true)
            {
                lock (locker)
                {
                    value = simulationDriver.ReadTag(tag.IOAddress);
                }
                notInRange = true;

                while (notInRange)
                {

                    notInRange = false;

                    switch (tag.Function)
                    {
                        case "Sine":
                            newValue = simulationDriver.Sine();
                            break;
                        case "Cosine":
                            newValue = simulationDriver.Cosine();
                            break;
                        case "Ramp":
                            newValue = simulationDriver.Ramp();
                            break;
                        case "Triangle":
                            newValue = simulationDriver.Triangle();
                            break;
                        case "Rectangle":
                            newValue = simulationDriver.Rectangle();
                            break;
                        default:
                            break;
                    }

                    if (tag is DigitalInput) newValue = (Math.Abs(newValue - 0) <= Math.Abs(newValue - 1)) ? 0 : 1;

                    else
                    {
                        AnalogInput aTag = (AnalogInput)tag;
                        if (newValue < aTag.LowLimit || newValue > aTag.HighLimit) notInRange = true;
                    }
                }
                lock (locker)
                {
                    simulationDriver.WriteTag(newValue, tag.IOAddress);
                    InputTagValueChanged(tag, newValue);
                }
                Thread.Sleep(tag.ScanTime * 1000);
            }
        }


        public void InputTagValueChanged(InputTag tag, double newValue)
        {
            lock (locker)
            {
                foreach (Alarm alarm in tag.Alarms)
                {
                    if (newValue <= alarm.Low) {
                        alarm.Type = "Low boundary exceeded";
                        alarm.TagValue = newValue;
                        alarmEvent(alarm);
                    }
                    else if(newValue >= alarm.High)
                    {
                        alarm.Type = "High boundary exceeded";
                        alarm.TagValue = newValue;
                        alarmEvent(alarm);
                    }
                }
            }
        }


        public bool SetInitialValue(string tagId, double value)
        {
            lock (locker)
            {
                if (!(tags[tagId] is OutputTag)) return false;

                OutputTag tag = (OutputTag)tags[tagId];
                tag.InitialValue = value;
                return true;
            }
        }


        public static void Finish()
        {
            XmlSerialisation();
            foreach (Thread t in threads.Values) t.Abort();
            
        }



        public bool CheckFlag()
        {
            lock (locker)
            {
                if (alarmFlag == 1) return true;
                return false;
            }
        }


        public void CheckedFlag()
        {
            lock (locker)
            {
                alarmFlag = 0;
            }
        }


        public List<Alarm> GetAlarms()
        {
            lock (locker)
            {
                return alarms;
            }
        }


        public void ClearAlarmList()
        {
            lock (locker)
            {
                alarms.Clear();
                alarmFlag = 0;
            }
        }


        public List<Tag> GetTags()
        {
            lock (locker)
            {
                return new List<Tag>(tags.Values);
            }
        }


        public static void DisplayTags() {

            while (Console.ReadKey().Key != ConsoleKey.X)
            {
                lock (locker)
                {
                    foreach (Tag tag in tags.Values)
                    {
                        Console.WriteLine(tags[tag.TagId]);
                        Console.WriteLine(simulationDriver.ReadTag(tag.IOAddress));
                    }
                }
                Console.WriteLine("______________________________________");
               
            }
        }


        public static void XmlSerialisation()
        {
            using (var writer = new StreamWriter("scadaConfig.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Tag>));
                serializer.Serialize(writer, tags.Values.ToList());
                Console.WriteLine("Serialization finished");
            }

        }


        public void XmlDeserialisation()
        {
            if (!File.Exists("scadaConfig.xml"))
            {
                simulationDriver = new SimulationDriver();
                return;
            }
            using (var reader = new StreamReader("scadaConfig.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Tag>));
                var tagsList = (List<Tag>)serializer.Deserialize(reader);

                if (tagsList != null && tagsList.Count != 0)
                {
                    simulationDriver = tagsList[0].SimulationDriver;
                }
                if (simulationDriver == null) simulationDriver = new SimulationDriver();
                
                lock (locker)
                {
                    if (tagsList != null)
                    {
                        tags = tagsList.ToDictionary(tag => tag.TagId);
                    }
                    foreach (var tag in tags.Values)
                    {
                        if (tag is InputTag && ((InputTag)tag).Auto) SimulationOn(tag.TagId);
                        
                    }
                }
            }
        }


        public bool CheckUpdatedValueFlag()
        {
            lock (locker) {
                if (updatedTagValueFlag == 1) return true;
                return false;
            }
        }


        public void SeenUpdatedValueFlag()
        {
            lock (locker) {
                updatedTagValueFlag = 0;
            }
        }

        
        public void ManualSetTagValue(InputTag tag, double value)
        {
            lock (locker) {
                simulationDriver.WriteTag(value, tag.IOAddress);
                SignalTrending();
            }
        }


        public List<Tag> GetScanningTags()
        {
            List<Tag> scanningTags = new List<Tag>();
            lock (locker)
            {
                foreach (Tag t in tags.Values) {
                    try
                    {
                        if (((InputTag)t).Scan) scanningTags.Add(t);
                     }
                    catch (Exception) { scanningTags.Add(t); }
                }
            }
            return scanningTags;
            
        }
       
      
        public Dictionary<string, double> GetScanningTagValues(List<Tag> wantedTags)
        {
            Dictionary<string, double> tagValues = new Dictionary<string, double>();
            lock (locker)
            {
                if (wantedTags.Count == 0)
                {
                    foreach (Tag t in tags.Values) tagValues.Add(t.TagId, simulationDriver.ReadTag(t.IOAddress));
                }
                else
                {
                    foreach (Tag t in wantedTags) tagValues.Add(t.TagId, simulationDriver.ReadTag(t.IOAddress));
                }
            }
            return tagValues;
        }
    }

}
    