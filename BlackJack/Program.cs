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

                // Shuffle deck
                DeckOfCards cards = new DeckOfCards();
                var rand = new Random();
                var shuffledDeck = cards.Deck.OrderBy(x => rand.Next()).ToList();

                // Draw starting cards
                GameMaster.PlayerDrawsCard(player, shuffledDeck);
                GameMaster.PlayerDrawsCard(player, shuffledDeck);

                Console.Clear();

                // Output game info (also runs a call to CheckValue and CheckBust)
                GameMaster.OutputInfo(bet, player);

                // Check for blackjack
                bool blackjack = GameMaster.CheckBlackjack(player, bet);

                // Hit, Stay
                while (player.bust == false)
                {
                    Console.Write("Type (1) to Hit, (2) to Stay\nYour choice: ");
                    ConsoleKeyInfo choice = Console.ReadKey();
                    if (choice.Key == ConsoleKey.D1)
                    {
                        Console.Clear();
                        GameMaster.PlayerDrawsCard(player, shuffledDeck);
                        blackjack = GameMaster.CheckBlackjack(player, bet);
                        GameMaster.OutputInfo(bet, player);
                        if (player.bust == true)
                        {
                            Console.Clear();
                            GameMaster.OutputInfo(bet, player);
                            break;
                        }
                    }
                    else if (choice.Key == ConsoleKey.D2)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Enter (Y) for yes, or (N) for no\n");
                    }
                }

                // Cleanup and run again
                Console.Clear();
                GameMaster.OutputInfo(bet, player);
                playAgain = GameMaster.PlayAgain(player);

                // Choose new bet
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Current Balance: ${player.Funds}");
                    Console.Write($"Enter a bet (must be greater than 0, whole dollar increments, and no more than ${player.Funds}\n$");

                    try
                    {
                        bet = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                    }
                } while (!GameMaster.CheckPlayersBet(player, bet));

                // deduct new bet from player funds
                player.Funds -= bet;

                // Reset deck
                shuffledDeck.Clear();
                shuffledDeck = cards.Deck.OrderBy(x => rand.Next()).ToList();
            }
        }
    }
}