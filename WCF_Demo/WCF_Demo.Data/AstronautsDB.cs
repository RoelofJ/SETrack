using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Demo.Data
{
    public class AstronautsDB
    {
        private List<Astronaut> db = new List<Astronaut>
        {
            new Astronaut { Name = "Andre Kuipers", LastMedicalCheck = new DateTime(2017, 11, 4), Nationality = "NL", Clearance = NASAClearance.Full },
            new Astronaut { Name = "Jason Bourne", LastMedicalCheck = new DateTime(2016, 1, 5), Nationality = "US", Clearance = NASAClearance.Pending },
            new Astronaut { Name = "James Bond", LastMedicalCheck = new DateTime(2014, 5, 6), Nationality = "UK", Clearance = NASAClearance.Limited },
            new Astronaut { Name = "Elizabeth Tudor", LastMedicalCheck = new DateTime(1603, 3, 24), Nationality = "UK", Clearance = NASAClearance.Pending },
            new Astronaut { Name = "Shinzo Abe", LastMedicalCheck = new DateTime(2007, 2, 14), Nationality = "JP", Clearance = NASAClearance.Full }
        };
        public Astronaut GetAstronaut(string name)
        {
            return db.FirstOrDefault(a => a.Name == name);
        }
    }
}
