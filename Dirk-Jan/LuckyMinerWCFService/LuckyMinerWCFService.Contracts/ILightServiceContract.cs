using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LuckyMinerWCFService.Contracts
{
    [ServiceContract(CallbackContract = typeof(ILightServiceContractCallback))]
    public interface ILightServiceContract
    {
        [FaultContract(typeof(Exception))]
        [OperationContract]
        string EnableButtons();
    }
    
    public interface ILightServiceContractCallback
    {
        [OperationContract]
        void OnCallback();
    }
}
