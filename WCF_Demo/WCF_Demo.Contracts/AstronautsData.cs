using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Demo.Contracts
{
    [DataContract]
    public class AstronautsData
    {
        [DataMember]
        public string CaptainName { get; set; }
        [DataMember]
        public string SecondInCommandName { get; set; }
        [DataMember]
        public string NavigatorName { get; set; }
        [DataMember]
        public string EngineerName { get; set; }
    }
}
