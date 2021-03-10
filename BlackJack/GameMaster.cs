using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BlackJack
{
    class GameMaster
    {
        public static bool CheckPlayersBet(Player player, int bet)
        {
            if (bet <= player.Funds && bet > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void OutputInfo(int bet, Player player)
        {
            // Display game info, also makes a call to CheckBust.
            // Balance: xx 
            // Bet: xx 
            // Hand: xx
            // Total Value: xx

            int val = CheckValue(player);
            Console.Write($"Balance: ${player.Funds}\nBet: ${bet}");
            if (val > 21)
            {
                GameMaster.CheckBust(player);
            }

            Console.Write($"\nHand: ");
            foreach (Card card in player.DrawnCards)
            {
                Console.Write($"{card.Face}  ");
            }
            Console.WriteLine($"\nTotal Value: {val}\n");
        }

        public static Card HandleAces(Card cardAce, Player player)
        {
            // Player chooses value of ace.
            Console.Clear();
            bool makingChoice = true;
            player.countAce += 1;
            do
            {
                Console.Write($"Default ace value is 1. Would you rather play your {cardAce.Face} with the value 11? (Y/N)\nYour choice: ");
                ConsoleKeyInfo chooseAce = Console.ReadKey();
                Console.Clear();
                if (chooseAce.Key == ConsoleKey.Y)
                {
                    cardAce.Value = 11;
                    makingChoice = false;
                }
                else if (chooseAce.Key == ConsoleKey.N)
                {
                    cardAce.Value = 1;
                    makingChoice = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Enter (Y) for yes, or (N) for no\n");
                    makingChoice = true;
                }
            } while (makingChoice == true);
            return cardAce;
        }

        public static void CheckBust(Player player)
        {
            bool bust = false;
            int z = 0;
            int i = CheckValue(player);
            int x = player.countAce;

            // Given player busts, change aces from value 11 to value 1, one at a time.
            // Check each time the value of an ace changes.
            // Resume game if player falls bellow 21, bust if still greater than 21 after all aces change to 1.
            if (i > 21)
            {
                foreach (Card card in player.DrawnCards)
                {
                    if (card.IsAce == true)
                    {
                        card.Value = 1;
                        if (x == z)
                        {
                            bust = true;
                            break;
                        }
                        z += 1;
                    }
                    bust = true;
                    int y = CheckValue(player);
                    if (y < 21)
                    {
                        bust = false;
                        break;
                    }
                }
            }
            player.bust = bust;
        }

        public static bool PlayAgain(Player player)
        {

            // Allow player to play again or quit.
            // Reset funds to $50 if player ran out of money.
            bool playAgain = true;
            bool hasSelected = false;

            while (hasSelected == false)
            {
                Console.Write("Would you like to play again? (Y/N)\nYour choice: ");
                ConsoleKeyInfo playChoice = Console.ReadKey();
                Console.WriteLine();
                if (playChoice.Key == ConsoleKey.N)
                {
                    hasSelected = true;
                    playAgain = false;
                    Console.Clear();
                    Console.WriteLine("Goodbye!\n");
                    System.Threading.Thread.Sleep(500);
                }
                else if (playChoice.Key == ConsoleKey.Y)
                {
                    hasSelected = true;
                    playAgain = true;
                    player.bust = false;
                    player.countAce = 0;
                    player.CardsTotalVal = 0;
                    player.DrawnCards.Clear();

                    if (player.Funds == 0)
                    {
                        player.Funds = 50;
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Must type (Y) for yes, or (N) for no.\n");
                }
            }
            return playAgain;
        }

        public static int CheckValue(Player player)
        {
            // Check total value of players drawn cards.
            int val = 0;
            foreach (Card card in player.DrawnCards)
            {
                val += card.Value;
            }

            return val;
        }

        public static void PlayerDrawsCard(Player player, List<Card> shuffledDeck)
        {
            // 'Deal' card out of shuffled deck, remove card from shuffled deck to eliminate repeats
            var newCard = shuffledDeck[1];
            shuffledDeck.RemoveAt(1);

            // Handle aces
            if (newCard.IsAce == true)
            {
                GameMaster.HandleAces(newCard, player);
            }

            // Add cards to drawn pile
            player.DrawnCards.Add(newCard);
            GameMaster.CheckBust(player);
        }

        public static bool CheckBlackjack(Player player, int bet)
        {
            // Check if player has blackjack.
            bool blackjack = false;
            int val = CheckValue(player);
            if (val == 21)
            {
                blackjack = true;
                player.GotBlackJack = true;
            }
            return blackjack;
        }

        public static void GameWin(Player player, Player player2, int bet)
        {
            // Displays if player wins.
            Console.Clear();
            player.Funds += bet;
            player.Funds += bet;

            if (player.GotBlackJack == true)
            {
                Console.WriteLine("Blackjack!\nCongratulations, you win!\n\nPress any key to continue... ");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Congratulations, you win!\n\nPress any key to continue... ");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
