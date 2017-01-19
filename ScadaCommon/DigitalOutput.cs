using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCommon
{
    [DataContract]
    public class DigitalOutput : OutputTag
    {

        public DigitalOutput(string id, string desc, string address, int value) :
            base(id, desc, address, value) { }


        public DigitalOutput() { }

    }
}
