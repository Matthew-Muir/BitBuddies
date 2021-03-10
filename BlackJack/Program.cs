using System;
using System.Linq;

/*
 * HEART x2665 ♥
 * SPADE x2660 ♠
 * CLUB  x2663 ♣
 * DIAM  x2666 ♦
 *
 * create GM class
 */

namespace BlackJack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Allows console to display unicode characters
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            //create player and give them $50
            var player = new Player(50);
            var playersBet = 0;

            //get and check user bet
            do
            {
                Console.Clear();
                Console.Write($"Enter a bet (must be greater than 0, whole dollar increments, and no more than ${player.Funds}\n$");

                try
                {
                    playersBet = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                }
            } while (!GameMaster.CheckPlayersBet(player, playersBet));

            // deduct bet from player funds
            player.Funds -= playersBet;

            // begin game loop
            NewGame(player, playersBet);
        }

        public static void NewGame(Player player, int bet)
        {
            bool playAgain = true;

            // Game loop
            while (playAgain == true)
            {
                // Create bot to play against
                Player player2 = new Player();
                player2.bot = true;

                // shuffle deck
                DeckOfCards cards = new DeckOfCards();
                var rand = new Random();
                var shuffledDeck = cards.Deck.OrderBy(x => rand.Next()).ToList();

                // draw card
                GameMaster.PlayerDrawsCard(player, shuffledDeck);
                GameMaster.PlayerDrawsCard(player, shuffledDeck);

                Console.Clear();

                // output game info
                GameMaster.OutputInfo(player.Funds, bet, player);

                // Check for blackjack
                bool blackjack = GameMaster.CheckBlackjack(player, bet);

                // Hit, Stay
                while (player.bust == false)
                {
                    Console.Write("Type (1) to Hit, (2) to Stay\nYour choice: ");
                    ConsoleKeyInfo choice = Console.ReadKey();
                    if (choice.Key == ConsoleKey.D1)
                    {
                        GameMaster.OutputInfo(player.Funds, bet, player);
                        Console.Clear();
                        GameMaster.PlayerDrawsCard(player, shuffledDeck);
                        blackjack = GameMaster.CheckBlackjack(player, bet);
                        GameMaster.OutputInfo(player.Funds, bet, player);
                        GameMaster.Bust(player);
                        if (player.bust == true)
                        {
                            break;
                        }
                    }
                    else if (choice.Key == ConsoleKey.D2)
                    {
                        break;
                    }
                }

                // Cleanup and run again
                // Not sure if this is working properly
                Console.WriteLine();
                playAgain = GameMaster.PlayAgain();
                cards.Deck.Clear();
                shuffledDeck.Clear();
                player.bust = false;
                player.countAce = 0;
                player.CardsTotalVal = 0;
                player.DrawnCards.Clear();
            }
        }
    }
}