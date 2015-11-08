using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Deck
    {
        public List<Card> Cards;
        //protected int _lastCard;

        public Deck()
        {
            Cards = new List<Card>();
        }
        public Deck(int value, int suit) : this()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Cards.Add(new Card { Value = i+1, Suit = j+1 });
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                var j = random.Next(i, Cards.Count);
                var temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }
        public void ViewCards()
        {
            foreach (Card aCard in this.Cards)
            {
                Console.WriteLine(aCard);
            }
        }
        //public int LastCard
        //{
        //    get;
        //    set;
        //}
    }
}
