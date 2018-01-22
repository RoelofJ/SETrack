using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_Demo.Contracts;

namespace WCF_Demo.Proxies
{
    public class CheckAstronautClient : ClientBase<ICheckAstronautsService>, ICheckAstronautsService
    {
        public bool DoFinalCheckup(FlightRosterData data)
        {
            return Channel.DoFinalCheckup(data);
        }

        public bool DoPreliminaryCheckup(FlightRosterData data)
        {
            return Channel.DoPreliminaryCheckup(data);
        }

        public AstronautData GetAstronaut(string name)
        {
            return Channel.GetAstronaut(name);
        }

        public void SetNames(IEnumerable<string> names)
        {
            try
            {
                Channel.SetNames(names);
            }
            catch (Exception ex)
            {
            }
        }

        public IEnumerable<string> GetNames()
        {
            if (this.State == CommunicationState.Opened)
                return Channel.GetNames();
            else
            {
                this.Abort();
                return new string[0];
            }
        }
    }
}
