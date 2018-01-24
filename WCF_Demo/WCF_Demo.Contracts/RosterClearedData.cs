using System.Runtime.Serialization;

namespace WCF_Demo.Contracts
{
    [DataContract]
    public class RosterClearedData
    {
        [DataMember]
        public bool Captain { get; set; }
        [DataMember]
        public bool SecondInCommand { get; set; }
        [DataMember]
        public bool Navigator { get; set; }
        [DataMember]
        public bool Engineer { get; set; }
    }
}
