using System.Runtime.Serialization;

namespace WCF_Demo.Contracts
{
    [DataContract]
    public class FlightRosterData
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
