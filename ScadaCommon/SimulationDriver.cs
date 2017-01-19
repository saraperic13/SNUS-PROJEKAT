using ScadaCommon;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ScadaCommon
{
  
    [DataContract] 
    public class SimulationDriver
    {
        [DataMember]
        private List<double> tagValues;

        [DataMember]
        private List<string> addresses;

        private const double  amplitude = 100;
        
        public SimulationDriver() {
            tagValues = new List<double>();
            addresses = new List<string>();
        }

        public  void WriteTag(double value, string address) {
            
            try
            {
                int i = addresses.IndexOf(address);
                tagValues[i] = value;
            }
            catch (Exception e) {
                addresses.Add(address);
                tagValues.Add(value);
            }
            
            
        }

        public  double ReadTag(string address) {
            try
            {
                int index = addresses.IndexOf(address);
                return tagValues[index];
            }
            catch (Exception)
            {
                return -5555; 
            }
        }

        public double Sine()
        {
            return amplitude * Math.Sin((double)DateTime.Now.Second / 60 * Math.PI);
        }

        public double Cosine()
        {
            return amplitude * Math.Cos((double)DateTime.Now.Second / 60 * Math.PI);
        }

        public double Ramp()
        {
            return amplitude * DateTime.Now.Second / 60;
        }

        public  double Triangle()
        {
            return ((2 * amplitude) / Math.PI) * Math.Asin(Math.Sin(2 * Math.PI * DateTime.Now.Second / 60.0));
        }

        public  double Rectangle()
        {
            return amplitude * Math.Sign(Math.Sin((DateTime.Now.Second % 10) / 5.0));
        }

        public List<double> TagValues
        {
            get { return tagValues; }
            set { tagValues = value; }
        }

        public List<string> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }
    }
}
