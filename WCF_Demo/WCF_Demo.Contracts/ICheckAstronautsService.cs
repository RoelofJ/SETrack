using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Demo.Contracts
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ICheckAstronautsService
    {
        [OperationContract(IsInitiating = false)]
        bool DoPreliminaryCheckup(FlightRosterData data);
        [OperationContract]
        AstronautData GetAstronaut(string name);
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void SetNames(IEnumerable<string> names);
        [OperationContract]
        IEnumerable<string> GetNames();
        [OperationContract]
        [FaultContract(typeof(ArgumentNullException))]
        [FaultContract(typeof(MyFaultData))]
        void ThrowException();
    }
}
