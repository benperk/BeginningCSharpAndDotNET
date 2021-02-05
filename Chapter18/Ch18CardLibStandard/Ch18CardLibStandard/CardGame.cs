using System;
using System.Collections.Generic;
using System.Text;

namespace BeginningCSharp
{
    /// <summary>
    /// Class that describes a single card
    /// </summary>
    public class Card : ICloneable
    {
        public readonly Rank rank;
        public readonly Suit suit;
        public readonly string imageLink;
        public static bool isAceHigh = true;

        public Card() { }
        public Card(Suit newSuit, Rank newRank, string link) { suit = newSuit; rank = newRank; imageLink = link; }
        public object Clone() { return MemberwiseClone(); }
    }
    public class Cards : List<Card>, ICloneable
    {
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }
        public object Clone()
        {
            Cards newCards = new Cards();
            foreach (Card sourceCard in this)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }
    }
    public class Deck : ICloneable
    {
        public event EventHandler LastCardDrawn;
        private Cards cards = new Cards();

        private Deck(Cards newCards) { cards = newCards; }

        public Deck(bool isAceHigh) : this() { Card.isAceHigh = isAceHigh; }

        public Deck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal, suitVal.ToString() + "-" + rankVal.ToString() + ".PNG"));
                }
            }
        }

        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
            {
                if ((cardNum == 51) && (LastCardDrawn != null))
                    LastCardDrawn(this, EventArgs.Empty);
                return cards[cardNum];
            }
            else
                throw new Exception("Card out of range");
        }

        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();
            for (int i = 0; i < 52; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(52);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }

        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }
    }
    public class Game
    {
        private int currentCard;
        private Deck playDeck;
        private Player[] players;
        private Cards discardedCards;

        public Game()
        {
            currentCard = 0;
            playDeck = new Deck(true);
            playDeck.LastCardDrawn += LastCardDrawnEventHandler;
            playDeck.Shuffle();
            discardedCards = new Cards();
        }

        private void LastCardDrawnEventHandler(object source, EventArgs args)
        {
            Console.WriteLine("Discarded cards reshuffled into deck.");
            ((Deck)source).Shuffle();
            discardedCards.Clear();
            currentCard = 0;
        }

        public void SetPlayers(Player[] newPlayers)
        {
            players = newPlayers;
        }

        public void DealHands()
        {
            for (int p = 0; p < players.Length; p++)
            {
                for (int c = 0; c < 7; c++)
                {
                    players[p].PlayHand.Add(playDeck.GetCard(currentCard++));
                }
            }
        }
    }
    public class Player
    {
        public string Name { get; private set; }
        public Cards PlayHand { get; private set; }
        private Player() { }
        public Player(string name) { Name = name; PlayHand = new Cards(); }
    }
    public enum Rank
    {
        Ace = 1,
        Deuce,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }
    public enum Suit
    {
        Club,
        Diamond,
        Heart,
        Spade,
    }
}
