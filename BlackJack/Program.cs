using System;
using System.Collections.Generic;

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
    class Program
    {
        static void Main(string[] args)
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
                Console.WriteLine($"Enter a bet (must be greater than 0, whole $ increments, and no more than {player.Funds}");

                try
                {
                    playersBet = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    
                }

            } while (!GameMaster.CheckPlayersBet(player,playersBet));

            // deduct bet from player funds
            player.Funds -= playersBet;
            


        }
    }
}
