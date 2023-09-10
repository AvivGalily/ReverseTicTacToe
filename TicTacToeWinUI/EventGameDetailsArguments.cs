using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGameLogic;

namespace TicTacToeWinUI
{
    public class EventGameDetailsArguments : EventArgs
    {
        private readonly string r_Player1Name;
        private readonly string r_Player2Name;
        private readonly int r_BoardSize;
        private readonly ePlayerType r_Player2Type;
        private eCell m_CurrentPlayerSign;
        private short m_CurrPlayerIndex;

        public EventGameDetailsArguments(string i_Player1Name, string i_Player2Name, int i_BoardSize, ePlayerType i_Player2Type)
        {
            r_Player1Name = i_Player1Name;
            r_Player2Name = i_Player2Name;
            r_BoardSize = i_BoardSize;
            r_Player2Type = i_Player2Type;
            m_CurrentPlayerSign = eCell.P1;
            m_CurrPlayerIndex = 0;
        }

        public int BoardSize
        {
            get
            {
                return r_BoardSize;
            }
        }

        public string Player2Name
        {
            get
            {
                return r_Player2Name;
            }
        }

        public string Player1Name
        {
            get
            {
                return r_Player1Name;
            }
        }

        public ePlayerType Player2Type
        {
            get
            {
                return r_Player2Type;
            }
        }

        public short CurrentIndexPlayer
        {
            get
            {
                return m_CurrPlayerIndex;
            }

            set
            {
                m_CurrPlayerIndex = value;
            }
        }

        public eCell CurrentPlayerSign
        {
            get
            {
                return m_CurrentPlayerSign;
            }

            set
            {
                m_CurrentPlayerSign = value;
            }
        }
    }
}
