using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCommon
{
    [DataContract]
    public class AnalogOutput: OutputTag
    {

        [DataMember]
        private double lowLimit;

        [DataMember]
        private double highLimit;

        [DataMember]
        private string units;

        public AnalogOutput() { }

        public AnalogOutput(string id, string desc,  string address, double value,
            double low, double high, string unit) : base(id, desc, address, value)
        {
            
            lowLimit = low;
            highLimit = high;
            units = unit;
        }


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
