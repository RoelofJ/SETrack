using LuckyMinerWCFService.Contracts;
using LuckyMinerWCFService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LuckyMinerWCFService.Proxy
{
    public class BankProxy : ClientBase<IBankContract>, IBankContract
    {

        public void CreateNewAccount(string name)
        {
            Channel.CreateNewAccount(name);
        }

        public void Deposit(string name, int amount)
        {
            Channel.Deposit(name, amount);
        }

        public int GetBalance(string accountname)
        {
            return Channel.GetBalance(accountname);
        }

        public void WriteToAccount(string fromName, string toName, int amount)
        {
            try
            {
                Channel.WriteToAccount(fromName, toName, amount);
            }
            catch(FaultException e)
            {
                throw;
            }
        }
    }
}
