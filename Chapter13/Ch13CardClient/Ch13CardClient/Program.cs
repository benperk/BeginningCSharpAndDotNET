using System;
using Ch13CardLib;

namespace Ch13CardClient
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Deck deck1 = new Deck();
        //    try
        //    {
        //        Card myCard = deck1.GetCard(60);
        //    }
        //    catch (CardOutOfRangeException e)
        //    {
        //        Console.WriteLine(e.Message);
        //        Console.WriteLine(e.DeckContents[0]);
        //    }
        //    Console.ReadKey();
        //}
        static void Main(string[] args)
        {
            // Display introduction.
            Console.WriteLine("BenjaminCards: a new and exciting card game.");
            Console.WriteLine("To win you must have 7 cards of the same suit in" +
                              " your hand.");
            Console.WriteLine();
            // Prompt for number of players.
            bool inputOK = false;
            int choice = -1;
            do
            {
                Console.WriteLine("How many players (2–7)?");
                string input = Console.ReadLine();
                try
                {
                    // Attempt to convert input into a valid number of players.
                    choice = Convert.ToInt32(input);
                    if ((choice >= 2) && (choice <= 7))
                        inputOK = true;
                }
                catch
                {
                    // Ignore failed conversions, just continue prompting.
                }
            } while (inputOK == false);
            // Initialize array of Player objects.
            Player[] players = new Player[choice];
            // Get player names.
            for (int p = 0; p < players.Length; p++)
            {
                Console.WriteLine($"Player {p + 1}, enter your name:");
                string playerName = Console.ReadLine();
                players[p] = new Player(playerName);
            }
            // Start game.
            Game newGame = new Game();
            newGame.SetPlayers(players);
            int whoWon = newGame.PlayGame();
            // Display winning player.
            Console.WriteLine($"{players[whoWon].Name} has won the game!");
            Console.ReadKey();
        }
    }
}
