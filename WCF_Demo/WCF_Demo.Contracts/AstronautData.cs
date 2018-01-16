using System;
using System.Runtime.Serialization;

namespace WCF_Demo.Contracts
{
    [DataContract]
    public class AstronautData
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Nationality { get; set; }
        [DataMember]
        public bool FullyCleared { get; set; }
    }
}
