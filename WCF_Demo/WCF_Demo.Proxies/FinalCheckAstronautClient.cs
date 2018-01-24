using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCF_Demo.Contracts;

namespace WCF_Demo.Proxies
{
    public class FinalCheckAstronautClient : DuplexClientBase<IFinalCheckAstronautService>, IFinalCheckAstronautService
    {
        public FinalCheckAstronautClient(InstanceContext instanceContext) : base(instanceContext) { }

        public bool DoFinalCheckup(FlightRosterData data)
        {
            return Channel.DoFinalCheckup(data);
        }
    }
}
