using LuckyMinerWCFService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LuckyMinerWCFService.Proxy
{
    public class LightProxy : DuplexClientBase<ILightServiceContract>, ILightServiceContract
    {
        public LightProxy(InstanceContext callbackInstance) : base(callbackInstance)
        {
        }

        public string EnableButtons()
        {
            return Channel.EnableButtons();
        }
    }
}
