using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic.Pieces
{
    interface IPiece
    {
        bool IsWhite { get; }
        Coords[] PossibleMoves { get; }
        Coords[] PossibleAttacks { get; }
        void UpdatePossibleMoves(Situation situation, bool check, Coords coords);
        void UpdatePossibleAttacks(Situation situation, Coords coords);
    }
}
