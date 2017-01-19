using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCommon
{
    [ServiceContract]
    public interface IAlarmDisplay
    {
        [OperationContract]
        List<Alarm> GetAlarms();

        [OperationContract]
        void ClearAlarmList();

        [OperationContract]
        bool CheckFlag();

        [OperationContract]
        void CheckedFlag();
    }
}
