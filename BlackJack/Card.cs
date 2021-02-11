using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Card
    {
        int value;
        string face;
        bool isRoyal;
        bool isAce;

        // Sets objects properties
        public int Value => value;
        public string Face => face;
        public bool IsRoyal => isRoyal;
        public bool IsAce => isAce;
        
        public Card(int value, string face, bool isRoyal = false, bool isAce = false)
        {
            this.value = value;
            this.face = face;
            this.isRoyal = isRoyal;
            this.isAce = isAce;
        }
    }
}
