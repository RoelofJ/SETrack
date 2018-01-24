using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LuckyMinerWCFService.Contracts
{
    [DataContract]
    public class CoinContract
    {
        [DataMember]
        public byte[] hash = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(DateTime.Now.ToLongDateString()));
    }
}
