using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCommon
{
    [DataContract]
    public class AnalogInput: InputTag
    {

        [DataMember]
        private double lowLimit;

        [DataMember]
        private double highLimit;

        [DataMember]
        private string units;


        public AnalogInput(string id, string desc, string address, int time,
            bool sc, bool automatic, double low, double high, string unit, string func): 
            base(id, desc, address, time, sc, automatic, func)
        {
            lowLimit = low;
            highLimit = high;
            units = unit;
        }

        public AnalogInput():base() { }



        public double LowLimit
        {
            get { return lowLimit; }
            set { lowLimit = value; }
        }

        public double HighLimit
        {
            get { return highLimit; }
            set { highLimit = value; }
        }

        public string Units
        {
            get { return units; }
            set { units = value; }
        }

        
    }
}

