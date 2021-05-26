using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic.Pieces
{
    public struct PieceChar
    {
        // n - clear, k - king, q - queen, r - rook, s - bishop, h - knight, p - pawn
        public char Status { get; set; }
        public bool IsWhite { get; set; }
        public PieceChar(char Status, bool IsWhite = true)
        {
            this.Status = Status;
            this.IsWhite = IsWhite;
        }
        public override string ToString()
        {
            return Status.ToString();
        }
    }

    abstract class Piece : IPiece
    {
        public bool IsWhite { get; }
        public bool ProtectingKing { get; set; }
        public Coords[] PossibleMoves { get; protected set; }
        public Coords[] PossibleAttacks { get; protected set; }
        protected Piece(bool IsWhite)
        {
            this.IsWhite = IsWhite;
        }
        public abstract void UpdatePossibleMoves(Situation situation, bool check, Coords coords);
        public abstract void UpdatePossibleAttacks(Situation situation, Coords coords);
    }
}
