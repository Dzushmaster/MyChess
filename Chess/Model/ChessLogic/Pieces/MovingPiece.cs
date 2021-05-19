using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic.Pieces
{
    abstract class MovingPiece : Piece
    {
        public Coords PieceProtectingKingCoords { get; set; }
        public MovingPiece(bool white):base(white) { }
    }
}
