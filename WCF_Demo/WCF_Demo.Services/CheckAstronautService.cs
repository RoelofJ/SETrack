using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using WCF_Demo.Contracts;
using WCF_Demo.Data;

namespace WCF_Demo.Services
{
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.PerSession, 
        ConcurrencyMode = ConcurrencyMode.Reentrant,
        ReleaseServiceInstanceOnTransactionComplete = false,
        IncludeExceptionDetailInFaults = true)]
    public class CheckAstronautService : ICheckAstronautsService, IFinalCheckAstronautService
    {
        private const int DaysPerYear = 365; //from configuration
        private const int MaximumAge = 60; //from configuration
        private string names;
        public IEnumerable<string> Names
        {
            get
            {
                return names.Length != 0 ? new string[0] : names.Split(';');
            }
        }

        public bool DoFinalCheckup(FlightRosterData rosterData)
        {
            var result = true;
            var astronauts = GetAstronautsFromService(rosterData);
            var clearedData = new RosterClearedData
            {
                Captain = false,
                SecondInCommand = false,
                Engineer = false,
                Navigator = false
            };
            foreach (var astronaut in astronauts)
            {
                var astronautCleared = true;
                if (astronaut.Clearance == NASAClearance.Pending || astronaut.Clearance == NASAClearance.Limited)
                {
                    astronautCleared = false;
                }
                if (astronaut.LastMedicalCheck < new DateTime(2015, 1, 1))
                {
                    astronautCleared = false;
                }
                if (astronaut.Birthdate < DateTime.Now.Subtract(TimeSpan.FromDays(DaysPerYear * MaximumAge)))
                {
                    astronautCleared = false;
                }

                if (rosterData.CaptainName == astronaut.Name)
                    clearedData.Captain = astronautCleared;
                else if (rosterData.SecondInCommandName == astronaut.Name)
                    clearedData.SecondInCommand = astronautCleared;
                else if (rosterData.NavigatorName == astronaut.Name)
                    clearedData.Navigator = astronautCleared;
                else if (rosterData.EngineerName == astronaut.Name)
                    clearedData.Engineer = astronautCleared;

                result = result && astronautCleared;
                var callback = OperationContext.Current.GetCallbackChannel<ICallbackFinalCheck>();
                if (callback != null)
                {
                    callback.SendClearedData(clearedData);
                }
                Thread.Sleep(1000);
            }
            return result;
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

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)] //autocomplete is default true
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
           //OperationContext.Current.SetTransactionComplete();

        }

        public void ThrowException()
        {
            var ex = new ArgumentNullException("But we don't have parameters!");
            var faultData = new MyFaultData
            {
                Name = "ThrowException",
                Message = "Throwing some exception in my service",
                Index = 5
            };

            throw new FaultException<MyFaultData>(faultData, "My extra message");
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
