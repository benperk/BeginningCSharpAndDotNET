using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch20Ex05;
using System.ServiceModel;

namespace Ch20Ex05Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to begin.");
            Console.ReadLine();
            Console.WriteLine("Opening channel.");
            IAppControlService client =
               ChannelFactory<IAppControlService>.CreateChannel(
                  new NetTcpBinding(),
                  new EndpointAddress(
                     "net.tcp://localhost:8081/AppControlService"));
            Console.WriteLine("Creating sun.");
            client.SetRadius(100, "yellow", 3);
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            Console.WriteLine("Growing sun to red giant.");
            client.SetRadius(200, "Red", 5);
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            Console.WriteLine("Collapsing sun to neutron star.");
            client.SetRadius(50, "AliceBlue", 2);
            Console.WriteLine("Finished. Press enter to exit.");
            Console.ReadLine();
        }
    }

}
