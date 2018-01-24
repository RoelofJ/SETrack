using LuckyMinerWCFService.Contracts;
using LuckyMinerWCFService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LuckyMinerWCFService.Proxy
{
    public class LuckyMinerProxy : ClientBase<ILuckyMinerServiceContract>, ILuckyMinerServiceContract
    {
        public CoinContract GetLucky()
        {
           return Channel.GetLucky();
        }
    }
}
