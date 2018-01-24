using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Demo.Contracts
{
    [ServiceContract(CallbackContract = typeof(ICallbackFinalCheck))]
    public interface IFinalCheckAstronautService
    {
        [OperationContract]
        bool DoFinalCheckup(FlightRosterData data);
    }

    [ServiceContract]
    public interface ICallbackFinalCheck
    {
        [OperationContract(IsOneWay = true)]
        void SendClearedData(RosterClearedData data);
    }
}
