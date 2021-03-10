using System.Collections.Generic;

namespace BlackJack
{
    internal class Player
    {
        public int Funds = 0;
        public List<Card> DrawnCards = new List<Card>();
        public int CardsTotalVal = 0;
        public bool GotBlackJack = false;
        public bool bust = false;
        public bool bot = false;
        public int countAce = 0;

        public Player(int money = 0)
        {
            Funds = money;
        }


    }
}