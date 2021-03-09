using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class DeckOfCards
    {
        public List<Card> Deck;
        


        // Deck constructor
        public DeckOfCards()
        {
            Deck = new List<Card>();


            //Fill Deck with cards
            for (int value = 2; value < 15; value++)
            {
                if (value == 11)
                {
                    string faceH = $"J \x2665";
                    Card heartCard = new Card(10, faceH, true);
                    Deck.Add(heartCard);

                    string faceS = $"J \x2660";
                    Card spadeCard = new Card(10, faceS, true);
                    Deck.Add(spadeCard);

                    string faceC = $"J \x2663";
                    Card clubCard = new Card(10, faceC, true);
                    Deck.Add(clubCard);

                    string faceD = $"J \x2666";
                    Card diaCard = new Card(10, faceD, true);
                    Deck.Add(diaCard);
                }
                else if (value == 12)
                {
                    string faceH = $"Q \x2665";
                    Card heartCard = new Card(10, faceH, true);
                    Deck.Add(heartCard);

                    string faceS = $"Q \x2660";
                    Card spadeCard = new Card(10, faceS, true);
                    Deck.Add(spadeCard);

                    string faceC = $"Q \x2663";
                    Card clubCard = new Card(10, faceC, true);
                    Deck.Add(clubCard);

                    string faceD = $"Q \x2666";
                    Card diaCard = new Card(10, faceD, true);
                    Deck.Add(diaCard);


                }
                else if (value == 13)
                {
                    string faceH = $"K \x2665";
                    Card heartCard = new Card(10, faceH, true);
                    Deck.Add(heartCard);

                    string faceS = $"K \x2660";
                    Card spadeCard = new Card(10, faceS, true);
                    Deck.Add(spadeCard);

                    string faceC = $"K \x2663";
                    Card clubCard = new Card(10, faceC, true);
                    Deck.Add(clubCard);

                    string faceD = $"K \x2666";
                    Card diaCard = new Card(10, faceD, true);
                    Deck.Add(diaCard);
                }
                else if (value == 14)
                {
                    string faceH = $"A \x2665";
                    Card heartCard = new Card(1, faceH, false, true);
                    Deck.Add(heartCard);

                    string faceS = $"A \x2660";
                    Card spadeCard = new Card(1, faceS, false, true);
                    Deck.Add(spadeCard);

                    string faceC = $"A \x2663";
                    Card clubCard = new Card(1, faceC, false, true);
                    Deck.Add(clubCard);

                    string faceD = $"A \x2666";
                    Card diaCard = new Card(1, faceD, false, true);
                    Deck.Add(diaCard);
                }

                else
                {
                    string faceH = $"{value} \x2665";
                    Card heartCard = new Card(value, faceH);
                    Deck.Add(heartCard);

                    string faceS = $"{value} \x2660";
                    Card spadeCard = new Card(value, faceS);
                    Deck.Add(spadeCard);

                    string faceC = $"{value} \x2663";
                    Card clubCard = new Card(value, faceC);
                    Deck.Add(clubCard);

                    string faceD = $"{value} \x2666";
                    Card diaCard = new Card(value, faceD);
                    Deck.Add(diaCard);
                }
            }
        }

        public void PrintDeck()
        {
            foreach (Card card in Deck)
            {
                Console.WriteLine(card.Face);
            }
        }
    }
}
