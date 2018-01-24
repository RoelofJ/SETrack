using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckyMinerWCFService.Contracts;
using System.ServiceModel;

namespace LuckyMinerWCFService.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single, ReleaseServiceInstanceOnTransactionComplete = false, IncludeExceptionDetailInFaults =true)]
    public class BankService : LuckyMinerWCFService.Contracts.IBankContract
    {
        List<AccountContract> accounts = new List<AccountContract>();

        
        public void CreateNewAccount(string name)
        {
            AccountContract acc = new AccountContract();
            acc.Name = name;
            acc.Balance = 0;
            accounts.Add(acc);
        }

        [OperationBehavior(TransactionScopeRequired =  true, TransactionAutoComplete = true)]
        public void WriteToAccount(string fromName, string toName, int amount)
        {
            try
            {
                //first remove from the account
                AccountContract fromAcc = accounts.Find(x => x.Name == fromName);
                fromAcc.Balance -= amount;
                //if the account in not found, throw an error so the transaction hsould be rollbacked otherwise, the amount should be added to the toacc balance.
                AccountContract toAcc = accounts.Find(x => x.Name == toName);
                toAcc.Balance += amount;
            }
            catch
            {
                throw;
            }
        }

        public int GetBalance(string accountName)
        {
            AccountContract acc = accounts.Find(x => x.Name == accountName);
            if(acc == null)
            {
                throw new KeyNotFoundException("Account not found");
            }
            return acc.Balance ;
        }

        public void Deposit(string name, int amount)
        {
            accounts.Find(x => x.Name == name).Balance += amount;
        }
    }
}
