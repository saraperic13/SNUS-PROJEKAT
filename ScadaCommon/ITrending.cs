using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCommon
{
    [ServiceContract]
    public interface ITrending
    {

        
        [OperationContract]
        List<Tag> GetScanningTags();

        [OperationContract]
        Dictionary<string,double> GetScanningTagValues(List<Tag> wantedTags);


        //[OperationContract]
        //List<Tag> GetUpdatedTags();

        //[OperationContract]
        //List<double> GetUpdatedValues();

        [OperationContract]
        bool CheckUpdatedValueFlag();

        [OperationContract]
        void SeenUpdatedValueFlag();


    }
}
