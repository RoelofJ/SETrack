using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_Demo.Services;

namespace WCF_Demo.Hosts
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostCheckAstronauts = new ServiceHost(typeof(CheckAstronautService));
            hostCheckAstronauts.Open();

            Console.WriteLine("Services started. Press [Enter] to quit.");
            Console.ReadLine();

            hostCheckAstronauts.Close();
        }
    }
}
