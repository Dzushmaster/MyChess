using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic
{
    //for add different settings in the game
    class Settings
    {
        public static bool NewGame { get; set; }
        static Settings()
        {
            NewGame = true;
        }
    }
}
