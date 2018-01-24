using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LuckyMinerWCFService.Contracts
{
    [DataContract]
    public class AccountContract
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Balance { get; set; }
    }
}
