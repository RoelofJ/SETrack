using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Demo.Contracts
{
    [ServiceContract]
    public interface ICheckAstronautsService
    {
        [OperationContract]
        bool DoPreliminaryCheckup(AstronautsData data);
        [OperationContract]
        bool DoFinalCheckup(AstronautsData data);
    }
}
