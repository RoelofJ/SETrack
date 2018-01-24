using LuckyMinerWCFService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LuckyMinerWCFService.Service
{
    [ServiceBehavior (ConcurrencyMode=ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class LuckyMinerService : ILuckyMinerServiceContract
    {

        int counter = 0;
        public CoinContract GetLucky()
        {
            counter++;
            if (counter % 3 == 0)
            {
                return new CoinContract();
            }
            else
            {
                return null;
            }
        }
    }
}
