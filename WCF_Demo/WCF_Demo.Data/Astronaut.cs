using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Demo.Data
{
    public class Astronaut
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime LastMedicalCheck { get; set; }
        public Address Address { get; set; }
        public string Nationality { get; set; }
        public int SocialSecurityNumber { get; set; }
        public NASAClearance Clearance { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public enum NASAClearance
    {
        Pending,
        Limited,
        Full
    }
}
