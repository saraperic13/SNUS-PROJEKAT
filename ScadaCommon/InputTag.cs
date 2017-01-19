using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ScadaCommon
{
    [DataContract]
    public  class InputTag: Tag
    {
        [DataMember]
        int scanTime;

        [DataMember]
        List<Alarm> alarms;

        [DataMember]
        bool scan;

        [DataMember]
        bool auto;

        [DataMember]
        string function;


        public InputTag() { }

        public InputTag(string id, string desc, string address, int time,
            bool sc, bool automatic, string func): base(id, desc,  address)
        {
            scanTime = time;
            scan = sc;
            auto = automatic;
            alarms = new List<Alarm>();
            function = func;
        }

        public void AddAlarm(Alarm alarm)
        {
            alarms.Add(alarm);
        }

        public void RemoveAlarm(string alarmId)
        {
            foreach (Alarm a in alarms) {
                if (a.AlarmId.Equals(alarmId)) {
                    alarms.Remove(a);
                    break;
                }
                    
            }
        }
        
        public bool Scan
        {
            get { return scan; }
            set { scan = value; }
        }

        public bool Auto
        {
            get { return auto; }
            set { auto = value; }
        }


        public int ScanTime
        {
            get { return scanTime; }
            set { scanTime = value; }
        }

        public List<Alarm> Alarms
        {
            get { return alarms; }
            set { alarms = value; }
        }

        public string Function
        {
            get { return function; }
            set { function = value; }
        }
    }
}

