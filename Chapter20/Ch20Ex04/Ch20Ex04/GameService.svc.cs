using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections.Generic;
using Ch20Ex04Contracts;


namespace Ch20Ex04
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GameService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GameService.svc or GameService.svc.cs at the Solution Explorer and start debugging.
    public class GameService : IGameService
    {
        private int playerLevel;
        public void SetPlayerLevel(int playerLevel)
        {
            this.playerLevel = playerLevel;
        }
        public Player[] GetProfessionalPlayer(Player[] playerToTest)
        {
            List<Player> result = new List<Player>();
            foreach (Player player in playerToTest)
            {
                if (player.Level > playerLevel)
                {
                    result.Add(player);
                }
            }
            return result.ToArray();
        }
    }
}
