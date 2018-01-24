using LuckyMinerWCFService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LuckyMinerWCFService
{
    public class LightServiceCallback : ILightServiceContractCallback
    {
        Button[] buttons;
        SynchronizationContext context;
        public LightServiceCallback(Button[] buttonsToEnable, SynchronizationContext uicontext)
        {
            buttons = buttonsToEnable;
            context = uicontext;
        }

        public void OnCallback()
        {
            SendOrPostCallback sendOrPostCallback = new SendOrPostCallback((object state) =>
            {
                foreach (Button b in buttons)
                {
                    b.IsEnabled = true;
                }
            });

            context.Post(sendOrPostCallback, null);
            
        }
    }
}
