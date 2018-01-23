using System.Runtime.Serialization;

namespace WCF_Demo.Contracts
{
    [DataContract]
    public class MyFaultData
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Index { get; set; }
    }
}