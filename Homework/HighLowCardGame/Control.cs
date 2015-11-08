using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Control
    {
        static Deck baseDeck;

        //public static int LastCard { get; private set; }

        public static void Setting()
        {
            baseDeck = new Deck(13, 4);
            baseDeck.Shuffle();
        }
        public static void CreatePlayers(Player player1, Player player2, String playerName1, String playerName2)
        {
            player1.Name = playerName1;
            player2.Name = playerName2;

        }
        public static void GiveCards(Player player1, Player player2)
        {
            for (int i = 0; i < 26; i++)
            {
                player1.PlayingDeck.Cards.Add(baseDeck.Cards[i]);
            }
            for (int i = 0; i < 26; i++)
            {
                player2.PlayingDeck.Cards.Add(baseDeck.Cards[i + 26]);
            }
        }

        public static void PlayerWinTurn(Player player, int NumberofCards = 1)
        {
            player.Count += (NumberofCards) * 2;
        }
        public static void TieTurn(Player player1, Player player2)
        {
            Console.WriteLine("<Tie 2 times> : Reshuffle the deck.");
            Console.WriteLine("....");
            player1.PlayingDeck.Shuffle();
            if (player1.PlayingDeck.Cards.Count != 2)
            {
                player2.PlayingDeck.Shuffle();
            }
        }

        public static void RemoveCards(Player player1, Player player2, int range)
        {
            int LastCard = player1.PlayingDeck.Cards.Count - 1;
            player1.PlayingDeck.Cards.RemoveRange(LastCard - range + 1, range);
            player2.PlayingDeck.Cards.RemoveRange(LastCard - range + 1, range);

        }
        public static int CompareCard(Player player1, Player player2)
        {
            int LastCard = player1.PlayingDeck.Cards.Count - 1;
            int player1_vLast = player1.PlayingDeck.Cards[LastCard].Value;
            int player2_vLast = player2.PlayingDeck.Cards[LastCard].Value;
            Console.WriteLine();
            Console.WriteLine(player1.Name + " has " + player1.PlayingDeck.Cards[LastCard]);
            Console.WriteLine(player2.Name + " has " + player2.PlayingDeck.Cards[LastCard]);
            if (player1.PlayingDeck.Cards.Count < player1_vLast && player1_vLast == player2_vLast) // Tie and not enough card to play
            {
                Console.WriteLine("<Tie> : not enough card to play.");
                Console.WriteLine("....");
                return -1;
            }
            //else if (player1_vLast == player2_vLast && (player1_vLast + player2.Count + player2.Count) > 52)
            //{
            //    Console.WriteLine("<Tie> : not enough card to play.");
            //    return -1;
            //}
            else if (player1_vLast == player2_vLast) // Tie Value Card
            {
                int LastCardTie = player1_vLast;
                Console.WriteLine("<Tie> : Draw " + LastCardTie + " Cards.");
                Console.WriteLine("....");
                Console.WriteLine(player1.Name + " has " + player1.PlayingDeck.Cards[LastCardTie]);
                Console.WriteLine(player2.Name + " has " + player2.PlayingDeck.Cards[LastCardTie]);
                int player1_fromlast = player1.PlayingDeck.Cards[LastCardTie].Value;
                int player2_fromlast = player2.PlayingDeck.Cards[LastCardTie].Value;
                if (player1_fromlast < player2_fromlast) // Tie : Player1 Win
                {
                    PlayerWinTurn(player1, LastCardTie+1);
                    RemoveCards(player1, player2, LastCardTie+1);
                    Console.WriteLine(" ----- " + player1.Name + " Win!!  -----");
                    return 1;
                }
                else if (player1_fromlast > player2_fromlast) // Tie : Player2 Win
                {
                    PlayerWinTurn(player2, LastCardTie+1);
                    RemoveCards(player1, player2, LastCardTie+1);
                    Console.WriteLine(" ----- " + player2.Name + " Win!!  -----");
                    return 2;
                }
                else // Tie 2 times
                {
                    TieTurn(player1, player2);
                    return 0;
                }

            }
            else if (player1_vLast < player2_vLast) // Player1 Win
            {
                PlayerWinTurn(player1);
                Console.WriteLine(" ----- " + player1.Name + " Win!! -----");
                RemoveCards(player1, player2, 1);
                return 1;
            }
            else if (player1_vLast > player2_vLast) // Player2 Win
            {
                PlayerWinTurn(player2);
                Console.WriteLine(" ----- " + player2.Name + " Win!!  -----");
                RemoveCards(player1, player2, 1);
                return 2;
            }
            return -1;
        }

        public static void EndGame(Player player1, Player player2)
        {
            Console.WriteLine("");
            Console.WriteLine("!!!+++>> Congratulation : " + (player1.Count > player2.Count ? player1.Name : player2.Name) + " WIN!! <<+++!!!");
        }

    }
}
