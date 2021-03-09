using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
