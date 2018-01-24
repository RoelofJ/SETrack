using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LuckyMinerWCFService.Contracts
{
    [ServiceContract(SessionMode=SessionMode.Allowed)]
    public interface ILuckyMinerServiceContract
    {
        [OperationContract]
        CoinContract GetLucky();
    }
}
