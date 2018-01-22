using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WCF_Demo.Contracts;
using WCF_Demo.Data;

namespace WCF_Demo.Services
{
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.PerSession, 
        ConcurrencyMode = ConcurrencyMode.Single, 
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class CheckAstronautService : ICheckAstronautsService
    {
        private const int DaysPerYear = 365; //from configuration
        private const int MaximumAge = 60; //from configuration
        private string names;
        public IEnumerable<string> Names
        {
            get
            {
                return names.Split(';');
            }
        }

        public bool DoFinalCheckup(FlightRosterData data)
        {
            var astronauts = GetAstronautsFromService(data);
            foreach (var astronaut in astronauts)
            {
                if (astronaut.Clearance == NASAClearance.Pending || astronaut.Clearance == NASAClearance.Limited)
                {
                    return false;
                }
                if (astronaut.LastMedicalCheck < new DateTime(2015, 1, 1))
                {
                    return false;
                }
                if (astronaut.Birthdate < DateTime.Now.Subtract(TimeSpan.FromDays(DaysPerYear * MaximumAge)))
                {
                    return false;
                }
            }
            return true;
        }

        public bool DoPreliminaryCheckup(FlightRosterData data)
        {
            var astronauts = GetAstronautsFromService(data);
            foreach (var astronaut in astronauts)
            {
                if (astronaut.LastMedicalCheck < new DateTime(2010, 1, 1))
                {
                    return false;
                }
                if (astronaut.Birthdate < DateTime.Now.Subtract(TimeSpan.FromDays(DaysPerYear * MaximumAge)))
                {
                    return false;
                }
            }
            return true;
        }

        public AstronautData GetAstronaut(string name)
        {
            var astronaut = GetAstronautByName(name);
            var result = new AstronautData
            {
                Name = name,
                Id = astronaut.ID,
                Nationality = astronaut.Nationality,
                FullyCleared = astronaut.Clearance == NASAClearance.Full
            };
            return result;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)] //autocomplete is default true
        public void SetNames(IEnumerable<string> input)
        {
            for (int i = 0; i < input.Count(); i++)
            {
                names += ";" + input.ElementAt(i);
                if (i == 3)
                {
                    throw new ArgumentException("Some exception");
                }
            }
           OperationContext.Current.SetTransactionComplete();

        }

        [OperationBehavior(TransactionScopeRequired = false)]
        public IEnumerable<string> GetNames()
        {
            //example of manual transaction
            using (TransactionScope scope = new TransactionScope())
            {
                scope.Complete();
            }
            return Names;
        }

        private Astronaut GetAstronautByName(string name)
        {
            var db = new AstronautsDB(); //should be done via dependency injection
            return db.GetAstronaut(name);
        }

        private List<Astronaut> GetAstronautsFromService(FlightRosterData data)
        {
            var db = new AstronautsDB(); //should be done via dependency injection
            var result = new List<Astronaut>
            {
                db.GetAstronaut(data.CaptainName),
                db.GetAstronaut(data.SecondInCommandName),
                db.GetAstronaut(data.NavigatorName),
                db.GetAstronaut(data.EngineerName)
            };
            return result;
        }
    }
}
