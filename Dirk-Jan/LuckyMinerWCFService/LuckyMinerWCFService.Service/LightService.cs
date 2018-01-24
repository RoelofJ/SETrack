using LuckyMinerWCFService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LuckyMinerWCFService.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, IncludeExceptionDetailInFaults =true)]
    public class LightService : ILightServiceContract
    {
        ILightServiceContractCallback callback;
        public string EnableButtons()
        {
            callback = OperationContext.Current.GetCallbackChannel<ILightServiceContractCallback>();
            Thread.Sleep(5000);
            callback.OnCallback();
            return "Nicely done!";
        }
    }


}
