using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCommon
{
    [DataContract]
    public class Alarm
    {
        [DataMember]
        string alarmId;

        [DataMember]
        string description;

        [DataMember]
        private string tagId;

        [DataMember]
        DateTime time;

        [DataMember]
        double low;

        [DataMember]
        double high;

        [DataMember]
        string type;

        [DataMember]
        double tagValue;

        public Alarm() { }
        

        public Alarm(string alarmId, string tagId, double ll, double hh, string desc = "") {
            this.tagId = tagId;
            low = ll;
            high = hh;
            this.alarmId = alarmId;
            description = desc;
            type = "";
            tagValue = 0;
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string TagId
        {
            get { return tagId; }
            set { tagId = value; }
        }

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public string AlarmId
        {
            get { return alarmId; }
            set { alarmId = value; }
        }

        public double Low
        {
            get { return low; }
            set { low = value; }
        }

        public double High
        {
            get { return high; }
            set { high = value; }
        }

        public double TagValue
        {
            get { return tagValue; }
            set { tagValue = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public override string ToString()
        {
            return string.Format("Time: {3}; Tag:{1}; Description: {2}; Type: {4}; AlarmID: {0}; Tag Value: {7}; Low: {5}; High: {6}", alarmId,tagId, description,time,type, low, high, tagValue);
        }

        
    }
}
