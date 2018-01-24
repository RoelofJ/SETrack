using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LuckyMinerWCFService.Contracts
{
    [ServiceContract]
    public interface IBankContract
    {

        [TransactionFlow(TransactionFlowOption.Allowed)]
        [OperationContract]
        void WriteToAccount(string fromName, string toName, int amount);
        [OperationContract]
        void CreateNewAccount(string name);
        [OperationContract]
        int GetBalance(string accountname);
        [OperationContract]
        void Deposit(string name, int amount);
    }
}
