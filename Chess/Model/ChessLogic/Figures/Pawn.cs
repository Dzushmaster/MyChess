using Chess.Model.ChessLogic.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic.Figures
{
    class Pawn : Piece
    {
        public Pawn(bool white) : base(white) { }
        public override void UpdatePossibleMoves(Situation situation, bool check, Coords coords)
        {
            List<Coords> possibleMoves = new List<Coords>();
            if(IsWhite ==  false)
            {
                if (coords.Row != 7)
                {
                    if (situation.ChessBoard[coords.Row + 1, coords.Column].Status == 'n')
                    {
                        possibleMoves.Add(new Coords((sbyte)(coords.Row + 1), coords.Column));

                        if (coords.Row == 1)
                            if(situation.ChessBoard[coords.Row + 2, coords.Column].Status == 'n')
                                possibleMoves.Add(new Coords((sbyte)(coords.Row + 2), coords.Column));
                    }
                    if (coords.Column != 0 && situation.ChessBoard[coords.Row + 1, coords.Column - 1].Status != 'n' && situation.ChessBoard[coords.Row + 1, coords.Column - 1].IsWhite != IsWhite)
                    {
                        possibleMoves.Add(new Coords((sbyte)(coords.Row + 1), (sbyte)(coords.Column - 1)));
                    }
                    if (coords.Column != 7 && situation.ChessBoard[coords.Row + 1, coords.Column + 1].Status != 'n' && situation.ChessBoard[coords.Row + 1, coords.Column + 1].IsWhite != IsWhite)
                    {
                        possibleMoves.Add(new Coords((sbyte)(coords.Row + 1), (sbyte)(coords.Column + 1)));
                    }
                }
            }
            else
            {
                if (coords.Row != 0)
                {
                    if (situation.ChessBoard[coords.Row - 1, coords.Column].Status == 'n')
                    {
                        possibleMoves.Add(new Coords((sbyte)(coords.Row - 1), coords.Column));
                        if (coords.Row == 6 && situation.ChessBoard[coords.Row - 2, coords.Column].Status == 'n')
                            possibleMoves.Add(new Coords((sbyte)(coords.Row - 2), coords.Column));
                    }
                    if (coords.Column != 0 && situation.ChessBoard[coords.Row - 1, coords.Column - 1].Status != 'n' && situation.ChessBoard[coords.Row - 1, coords.Column - 1].IsWhite != IsWhite)
                    {
                        possibleMoves.Add(new Coords((sbyte)(coords.Row - 1), (sbyte)(coords.Column - 1)));
                    }
                    if (coords.Column != 7 && situation.ChessBoard[coords.Row - 1, coords.Column + 1].Status != 'n' && situation.ChessBoard[coords.Row - 1, coords.Column + 1].IsWhite != IsWhite)
                    {
                        possibleMoves.Add(new Coords((sbyte)(coords.Row - 1), (sbyte)(coords.Column + 1)));
                    }
                }
            }
            //Check after moving this piece
            if(check || ProtectingKing)
            {
                for (int i = possibleMoves.Count - 1; i >= 0; i--)
                    if (Engine.ValidMoveDuringCheck(coords, possibleMoves[i], situation) == false)
                        possibleMoves.RemoveAt(i);
            }
            PossibleMoves = possibleMoves.ToArray();
        }
        public override void UpdatePossibleAttacks(Situation situation, Coords coords)
        {
            List<Coords> possibleAttacks = new List<Coords>();
            if(IsWhite == false)
            {
                if (coords.Row != 7)
                {
                    if (coords.Column != 0)
                        possibleAttacks.Add(new Coords((sbyte)(coords.Row + 1), (sbyte)(coords.Column - 1)));
                    if (coords.Column != 7)
                        possibleAttacks.Add(new Coords((sbyte)(coords.Row + 1), (sbyte)(coords.Column + 1)));
                }
            }
            else
            {
                if (coords.Row != 0)
                {
                    if (coords.Column != 0)
                        possibleAttacks.Add(new Coords((sbyte)(coords.Row - 1), (sbyte)(coords.Column - 1)));
                    if (coords.Column != 7)
                        possibleAttacks.Add(new Coords((sbyte)(coords.Row - 1), (sbyte)(coords.Column + 1)));
                }
            }
            PossibleAttacks = possibleAttacks.ToArray();
        }

    }
}
