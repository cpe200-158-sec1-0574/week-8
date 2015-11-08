using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Player
    {
        private Deck _playDeck;
        private int _count;
        private String _name;


        public Player()
        {
            PlayingDeck = new Deck();
            Count = 0;
            Point = 0;
        }
        public Deck PlayingDeck
        {
            get;
            set;
        }
        public int Count
        {
            get;
            set;
        }
        public int Point
        {
            get;
            set;
        }
        public String Name
        {
            get;
            set;
        }
        public void ShowPlayerScore(Player player)
        {
            Console.WriteLine("> " + Name + " : " + Count + " Points");
        }
    }
}
