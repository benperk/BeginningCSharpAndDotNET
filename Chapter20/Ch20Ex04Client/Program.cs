using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Ch20Ex04Contracts;

namespace Ch20Ex04Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] players = new Player[]
            {
                new Player { Level = 46, Name="Benamin" },
                new Player { Level = 73, Name="Jon" },
                new Player { Level = 92, Name="Rual" },
            new Player { Level = 24, Name="Mary" }
            };
            Console.WriteLine("Player:");
            OutputPlayers(players);
            IGameService client = ChannelFactory<IGameService>.CreateChannel(
               new WSHttpBinding(),
               new EndpointAddress("http://localhost:52262/GameService.svc"));
            client.SetPlayerLevel(70);
            Player[] professionalPlayers = client.GetProfessionalPlayer(players);
            Console.WriteLine();
            Console.WriteLine("Professional players:");
            OutputPlayers(professionalPlayers);
            Console.ReadKey();
        }
        static void OutputPlayers(Player[] players)
        {
            foreach (Player player in players)
                Console.WriteLine($"{player.Name}, level: {player.Level}");
        }
    }

}
