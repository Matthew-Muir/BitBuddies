using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Player
    {
        public int Funds = 0;
        public List<Card> DrawnCards = new List<Card>();
        public int CardsTotalVal = 0;
        public bool GotBlackJack = false;

        

        public Player(int money = 0)
        {
            Funds = money;
        }
    }
}
