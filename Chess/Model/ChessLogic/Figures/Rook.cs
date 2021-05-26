using Chess.Model.ChessLogic.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic.Figures
{
    class Rook : MovingPiece
    {
        public Rook(bool white):base(white) { }
        public override void UpdatePossibleMoves(Situation situation, bool check, Coords coords)
        {
            List<Coords> possibleMoves = new List<Coords>();
            //Left side
            for (sbyte col = (sbyte)(coords.Column - 1); col >= 0; col--)
            {
                if (situation.ChessBoard[coords.Row, col].Status == 'n')
                    possibleMoves.Add(new Coords(coords.Row, col));
                else
                {
                    if (situation.ChessBoard[coords.Row, col].IsWhite != IsWhite)
                        possibleMoves.Add(new Coords(coords.Row, col));
                    break;
                }
            }
            //Right side
            for (sbyte col = (sbyte)(coords.Column + 1); col < 8; col++)
            {
                if (situation.ChessBoard[coords.Row, col].Status == 'n')
                    possibleMoves.Add(new Coords(coords.Row, col));
                else
                {
                    if (situation.ChessBoard[coords.Row, col].IsWhite != IsWhite)
                        possibleMoves.Add(new Coords(coords.Row, col));
                    break;
                }
            }

            //Top side
            for (sbyte row = (sbyte)(coords.Row-1); row>=0;row--)
            {
                if (situation.ChessBoard[row, coords.Column].Status == 'n')
                    possibleMoves.Add(new Coords(row, coords.Column));
                else
                {
                    if (situation.ChessBoard[row, coords.Column].IsWhite != IsWhite)
                        possibleMoves.Add(new Coords(row, coords.Column));
                    break;
                }
            }
            //Bottom side
            for (sbyte row = (sbyte)(coords.Row + 1); row < 8; row++)
            {
                if (situation.ChessBoard[row, coords.Column].Status == 'n')
                    possibleMoves.Add(new Coords(row, coords.Column));
                else
                {
                    if (situation.ChessBoard[row, coords.Column].IsWhite != IsWhite)
                        possibleMoves.Add(new Coords(row, coords.Column));
                    break;
                }
            }
            //Check after moving this piece
            if (check || ProtectingKing)
                for (int i = possibleMoves.Count - 1; i >= 0; i--)
                    if (Engine.ValidMoveDuringCheck(coords, possibleMoves[i], situation) == false)
                        possibleMoves.RemoveAt(i);

            PossibleMoves = possibleMoves.ToArray();
        }

        public override void UpdatePossibleAttacks(Situation situation, Coords coords)
        {
            PieceProtectingKingCoords = new Coords(8, 8);
            List<Coords> possibleAttacks = new List<Coords>();
            //Left side
            for (sbyte col = (sbyte)(coords.Column - 1); col >= 0; col--)
            {
                if (situation.ChessBoard[coords.Row, col].Status == 'n')
                    possibleAttacks.Add(new Coords(coords.Row, col));
                else
                {
                    possibleAttacks.Add(new Coords(coords.Row, col));
                    if (situation.ChessBoard[coords.Row, col].IsWhite != IsWhite)
                    {
                        for (sbyte col2 = (sbyte)(col - 1); col2 >= 0; col2--)
                        {
                            if (situation.ChessBoard[coords.Row, col2].Status == 'k')
                            {
                                if (situation.ChessBoard[coords.Row, col2].IsWhite != IsWhite)
                                    PieceProtectingKingCoords = new Coords(coords.Row, col2);
                            }
                            else
                                break;
                        }
                    }
                    break;
                }
            }
            //Right side
            for (sbyte col = (sbyte)(coords.Column + 1); col < 8; col++)
            {
                if (situation.ChessBoard[coords.Row, col].Status == 'n')
                    possibleAttacks.Add(new Coords(coords.Row, col));
                else
                {
                    possibleAttacks.Add(new Coords(coords.Row, col));
                    if (situation.ChessBoard[coords.Row, col].IsWhite != IsWhite)
                    {
                        for (sbyte col2 = (sbyte)(col + 1); col2 < 0; col2++)
                        {
                            if (situation.ChessBoard[coords.Row, col2].Status == 'k')
                            {
                                if (situation.ChessBoard[coords.Row, col2].IsWhite != IsWhite)
                                    PieceProtectingKingCoords = new Coords(coords.Row, col2);
                            }
                            else
                                break;
                        }
                    }
                    break;
                }
            }

            //Top side
            for (sbyte row = (sbyte)(coords.Row - 1); row >= 0; row--)
            {
                if (situation.ChessBoard[row, coords.Column].Status == 'n')
                    possibleAttacks.Add(new Coords(row, coords.Column));
                else
                {
                    possibleAttacks.Add(new Coords(row, coords.Column));
                    if(situation.ChessBoard[row, coords.Column].IsWhite != IsWhite)
                    {
                        for(sbyte row2 = (sbyte)(row-1); row2>=0; row2--)
                        {
                            if (situation.ChessBoard[row2, coords.Column].Status == 'k')
                            {
                                if (situation.ChessBoard[row, coords.Column].IsWhite != IsWhite)
                                    PieceProtectingKingCoords = new Coords(row, coords.Column);
                            }
                            else
                                break;
                        }
                    }
                    break;
                }
            }
            //Bottom side
            for (sbyte row = (sbyte)(coords.Row + 1); row < 8; row++)
            {
                if (situation.ChessBoard[row, coords.Column].Status == 'n')
                    possibleAttacks.Add(new Coords(row, coords.Column));
                else
                {
                    possibleAttacks.Add(new Coords(row, coords.Column));
                    if (situation.ChessBoard[row, coords.Column].IsWhite != IsWhite)
                    {
                        for (sbyte row2 = (sbyte)(row + 1); row2 < 8; row2++)
                        {
                            if (situation.ChessBoard[row2, coords.Column].Status == 'k')
                            {
                                if (situation.ChessBoard[row, coords.Column].IsWhite != IsWhite)
                                    PieceProtectingKingCoords = new Coords(row, coords.Column);
                            }
                            else
                                break;
                        }
                    }
                    break;
                }
            }
            PossibleAttacks = possibleAttacks.ToArray();
        }

    }
}
