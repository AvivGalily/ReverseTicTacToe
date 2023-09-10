using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeWinUI
{
    public class UIResources
    {
        private static readonly string sr_OSign = "OSign.png";
        private static readonly string sr_XSign = "XSign.png";
        private static readonly string sr_ButtonClickSound = "Button_Click.wav";
        private static readonly string sr_ResourcesFolderPath;
        private static readonly string sr_LoseSound = "Lose_sound_effect.wav";
        private static readonly string sr_WinSound = "Win_sound_effect.wav";
        private static readonly string sr_TieSound = "Tie_sound_effect.wav";
        static UIResources()
        {
            sr_ResourcesFolderPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Resources");
            //sr_ResourcesFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
            //sr_ResourcesFolderPath = ".\\Resources";
            //sr_ResourcesFolderPath = "C:\\Users\\avivg\\OneDrive\\שולחן העבודה\\מדעי המחשב\\C#\\תרגיל 5\\B23 Ex05 Amit 316108224 Aviv 316431774\\TicTacToeWinUI\\Resources\\";
        }

        public static string OSign
        {
            get
            {
                return sr_OSign;
            }
        }

        public static string XSign
        {
            get
            {
                return sr_XSign;
            }
        }

        public static string ResourcesFolderPath
        {
            get
            {
                return sr_ResourcesFolderPath;
            }
        }

        public static string ButtonClickSound
        {
            get
            {
                return sr_ButtonClickSound;
            }
        }

        public static string LoseSound
        {
            get
            {
                return sr_LoseSound;
            }
        }

        public static string TieSound
        {
            get
            {
                return sr_TieSound;
            }
        }

        public static string WinSound
        {
            get
            {
                return sr_WinSound;
            }
        }
    }
}
