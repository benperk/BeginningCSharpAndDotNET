using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Ch20Ex04Contracts
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IGameService
    {
        [OperationContract(IsOneWay = true, IsInitiating = true)]
        void SetPlayerLevel(int playerLevel);
        [OperationContract]
        Player[] GetProfessionalPlayer(Player[] playerToTest);
    }
}
