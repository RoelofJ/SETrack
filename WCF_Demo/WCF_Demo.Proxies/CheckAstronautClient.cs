using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public void ThrowException()
        {
            try
            {
                Channel.ThrowException();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MessageBox.Show("Exception thrown by service. " + Environment.NewLine + "Exception type: " +
                       ex.GetType().Name + Environment.NewLine +
                       "Reason: " + ex.Message + Environment.NewLine +
                       "Message: " + ex.Detail.Message + Environment.NewLine + 
                       "Proxy state: " + this.State.ToString());
            }
            catch (FaultException<MyFaultData> ex)
            {
                MessageBox.Show("FaultException thrown by service." + Environment.NewLine +
                    "Reason: " + ex.Message + Environment.NewLine +
                    "Message: " + ex.Detail + Environment.NewLine +
                    "Proxy state: " + this.State.ToString());
            }
            catch (FaultException<ArgumentNullException> ex)
            {
                MessageBox.Show("FaultException thrown by service." + Environment.NewLine +
                    "Reason: " + ex.Message + Environment.NewLine +
                    "Message: " + ex.Detail.Message + Environment.NewLine +
                    "Proxy state: " + this.State.ToString());
            }
            catch (FaultException ex)
            {
                MessageBox.Show("Exception thrown by service. " + Environment.NewLine + "Exception type: " +
                       ex.GetType().Name + Environment.NewLine +
                       "Message: " + ex.Message + Environment.NewLine +
                       "Proxy state: " + this.State.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception thrown by service. " + Environment.NewLine + "Exception type: " +
                    ex.GetType().Name + Environment.NewLine +
                    "Message: " + ex.Message + Environment.NewLine +
                    "Proxy state: " + this.State.ToString());
            }
        }
    }
}
