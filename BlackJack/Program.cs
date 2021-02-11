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

            DeckOfCards temp = new DeckOfCards();
         
            temp.PrintDeck();



        }
    }
}
