using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Player
    {
        int funds = 0;
        List<Card> drawnCards = new List<Card>();
        int cardsTotalVal = 0;
        bool gotBlackJack = false;

        // Class properties
        public int Funds => funds;
        public List<Card> DrawnCards => drawnCards;
        public int CardsTotalVal => cardsTotalVal;
        public bool GotBlackJack => gotBlackJack;

        public Player(int money = 0)
        {
            this.funds = money;
        }
    }
}
