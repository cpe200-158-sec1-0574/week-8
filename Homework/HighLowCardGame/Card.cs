using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Card
    {
        private int _value;
        private int _suit;

        protected string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
        protected string[] face = { "Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

        public override string ToString()
        {
            return face[Value - 1] + "(" + Value + ") " + suit[Suit - 1]  ;
        }
        //public override string ToString()
        //{
        //    return base.ToString();
        //}

        public int Value
        {
            get;
            set;
        }
        public int Suit
        {
            get;
            set;
        }

    }

}
