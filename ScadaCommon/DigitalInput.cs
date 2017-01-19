using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCommon
{
    [DataContract]
    public class DigitalInput : InputTag
    {

        public DigitalInput():base(){ }

        public DigitalInput(string id, string desc, string address, int time,
            bool sc, bool automatic, string func): base(id, desc,  address,time, sc, automatic, func){ }


        }
}
