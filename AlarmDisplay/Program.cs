using System;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ScadaCommon;
using System.Threading;

namespace AlarmDisplay
{
    class Program
    {

        static private IAlarmDisplay proxy;

        static void Main(string[] args)
        {
            Uri address = new Uri("net.tcp://"+ Constants.IPAddress+":4000/IAlarmDisplay");

            NetTcpBinding binding = new NetTcpBinding { Security = { Mode = SecurityMode.None } };

            ChannelFactory<IAlarmDisplay> factory = new ChannelFactory<IAlarmDisplay>
                (binding, new EndpointAddress(address));
            proxy = factory.CreateChannel();

            Process();
        }

        private static void Process() {
            while (true) {

                if (proxy.CheckFlag()) {
                   
                    foreach(Alarm alarm in proxy.GetAlarms()) Console.WriteLine(alarm);
                    Console.WriteLine("___________________________________");
                    proxy.ClearAlarmList();
                    proxy.CheckedFlag();
                }
                Thread.Sleep(1000);

            }
        }
    }
}
