using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeginningCSharp;

namespace Ch20Ex01.Controllers
{
    public class HandOfCardsController : Controller
    {       
        [HttpGet, HttpPost]
        [Route("api/HandOfCards/{playerName}")]
        public async Task<IEnumerable<HandOfCards>> GetHandOfCards(string playerName)
        {
            Player[] players = new Player[1];
            players[0] = new Player(playerName);
            Game newGame = new Game();
            newGame.SetPlayers(players);
            newGame.DealHands();
            var handOfCards = players[0].PlayHand;

            return Enumerable.Range(0, 7).Select(index => new HandOfCards
            {
                imageLink = handOfCards[index].imageLink,
                rank = handOfCards[index].rank.ToString(),
                suit = handOfCards[index].suit.ToString()
            }).ToArray();
        }
        public class HandOfCards
        {
            public string imageLink { get; set; }
            public string rank { get; set; }
            public string suit { get; set; }
        }
    }
}
