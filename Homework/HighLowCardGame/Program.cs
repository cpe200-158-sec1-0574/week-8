using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HighLowCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            Player player2 = new Player();
            Control.Setting();
            Console.Write("Player1's name : ");
            String nPlayer1 = Console.ReadLine();
            Console.Write("Player2's name : ");
            String nPlayer2 = Console.ReadLine();
            Control.CreatePlayers(player1, player2, nPlayer1, nPlayer2);
            Control.GiveCards(player1, player2);

            int result = 0;
            int nextTurn = 1;
            do
            {
                result = Control.CompareCard(player1, player2);
                player1.ShowPlayerScore(player1);
                player2.ShowPlayerScore(player2);
                if (player1.PlayingDeck.Cards.Count == 0)
                    break;
                Console.WriteLine("Press any key and Enter to Continue...");
                String next = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

            } while (result != -1 && nextTurn == 1);
            Control.EndGame(player1, player2);
            Console.ReadKey();

        }
    }
}
