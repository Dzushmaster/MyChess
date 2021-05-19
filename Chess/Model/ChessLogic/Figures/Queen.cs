using Chess.Model.ChessLogic.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic.Figures
{
    class Queen : MovingPiece
    {
        public Queen(bool white) : base(white) { }
        public override void UpdatePossibleMoves(Situation situation, bool check, Coords coords)
        {
            List<Coords> possibleMoves = new List<Coords>();
            Rook rook = new Rook(IsWhite);
            rook.UpdatePossibleMoves(situation, check, coords);
            Bishop bishop = new Bishop(IsWhite);
            bishop.UpdatePossibleMoves(situation, check, coords);
            possibleMoves.AddRange(rook.PossibleMoves);
            possibleMoves.AddRange(bishop.PossibleMoves);
            PossibleMoves = possibleMoves.ToArray();
            //if king is checked
        }
        public override void UpdatePossibleAttacks(Situation situation, Coords coords)
        {
            PieceProtectingKingCoords = new Coords(8, 8);
            List<Coords> possibleAttacks = new List<Coords>();
            Rook rook = new Rook(IsWhite);
            rook.UpdatePossibleAttacks(situation, coords);
            if (rook.PieceProtectingKingCoords.Row != 8)
                PieceProtectingKingCoords = rook.PieceProtectingKingCoords;
            Bishop bishop = new Bishop(IsWhite);
            bishop.UpdatePossibleAttacks(situation, coords);
            if (bishop.PieceProtectingKingCoords.Row != 8)
                PieceProtectingKingCoords = bishop.PieceProtectingKingCoords;
            possibleAttacks.AddRange(rook.PossibleAttacks);
            possibleAttacks.AddRange(bishop.PossibleAttacks);
            PossibleAttacks = possibleAttacks.ToArray();
        }

    }
}
