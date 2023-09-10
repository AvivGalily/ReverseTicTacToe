using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGameLogic
{
    public class Player
    {
        // < ------------------ PROPERTIES ------------------ >
        internal eCell m_PlayerShape { get; set; }
        internal string m_Name { get; set; }
        internal int m_Points { get; set; }
        internal ePlayerType playerType { get; set; }

        // C'tor
        public Player(
            eCell i_PlayerShape,
            string i_Name, 
            ePlayerType i_PlayerType)
        {
            m_Name = i_Name;
            m_PlayerShape = i_PlayerShape;
            playerType = i_PlayerType;
        }

    }
}
