using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch20Ex03Client.ServiceReference1;

namespace Ch20Ex03Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int intParam;
            do
            {
                Console.WriteLine("Enter an integer and press enter to call the WCF service.");
            } while (!int.TryParse(Console.ReadLine(), out intParam));
            Service1Client client = new Service1Client();
            Console.WriteLine(client.GetData(intParam));
            Console.WriteLine("Press an key to exit.");
            Console.ReadKey();
        }
    }

}
