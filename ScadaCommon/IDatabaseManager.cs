using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCommon
{
    [ServiceContract]
    public interface IDatabaseManager
    {


        [OperationContract]
        bool AddTag(Tag tag);

        [OperationContract]
        bool RemoveTag(string tagId);

        [OperationContract]
        void UpdateTag(Tag tag);

        [OperationContract]
        void ManualSetTagValue(InputTag tag, double value);

        [OperationContract]
        bool AddAlarm(Alarm alarm);

        [OperationContract]
        bool RemoveAlarm(string tagId, string alarmId);

        [OperationContract]
        bool ScanOn(string tagId);

        [OperationContract]
        bool ScanOff(string tagId);

        [OperationContract]
        void SimulationOn(string tagId);

        [OperationContract]
        void SimulationOff(string tagId);

        [OperationContract]
        bool SetInitialValue(string tagId, double value);

        [OperationContract]
        List<Tag> GetTags();


    }
}
