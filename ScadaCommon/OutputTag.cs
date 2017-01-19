using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCommon
{
    [DataContract]
    public class OutputTag: Tag
    {
        [DataMember]
        private double initialValue;

        public OutputTag() { }

        public OutputTag(string id, string desc, string address, double value) : base(id, desc, address)
        {
            initialValue = value;
        }

        public double InitialValue
        {
            get { return initialValue; }
            set { initialValue = value; }
        }

    }
}

