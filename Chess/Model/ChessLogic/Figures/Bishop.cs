using Chess.Model.ChessLogic.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic.Figures
{
    class Bishop : MovingPiece
    {
        public Bishop(bool white) : base(white) { }


        public override void UpdatePossibleMoves(Situation situation, bool check, Coords coords)
        {
            List<Coords> possibleMoves = new List<Coords>();
            sbyte row = coords.Row;
            sbyte col;
            //Left top
            for(col = (sbyte)(coords.Column - 1); col >=0; col--)
            {
                row--;
                if (row >= 0)
                {
                    if (situation.ChessBoard[row, col].Status == 'n')
                        possibleMoves.Add(new Coords(row, col));
                    else
                    {
                        if (situation.ChessBoard[row, col].IsWhite != IsWhite)
                            possibleMoves.Add(new Coords(row, col));
                        break;
                    }
                }
                else
                    break;
            }
            row = coords.Row;
            //Right top
            for (col = (sbyte)(coords.Column + 1); col < 8; col++)
            {
                row--;
                if (row >= 0)
                {
                    if (situation.ChessBoard[row, col].Status == 'n')
                        possibleMoves.Add(new Coords(row, col));
                    else
                    {
                        if (situation.ChessBoard[row, col].IsWhite != IsWhite)
                            possibleMoves.Add(new Coords(row, col));
                        break;
                    }
                }
                else
                    break;
            }

            row = coords.Row;
            //Left bottom
            for (col = (sbyte)(coords.Column - 1); col >= 0; col--)
            {
                row++;
                if (row < 8)
                {
                    if (situation.ChessBoard[row, col].Status == 'n')
                        possibleMoves.Add(new Coords(row, col));
                    else
                    {
                        if (situation.ChessBoard[row, col].IsWhite != IsWhite)
                            possibleMoves.Add(new Coords(row, col));
                        break;
                    }
                }
                else
                    break;
            }
            row = coords.Row;
            //Right bottom
            for (col = (sbyte)(coords.Column + 1); col < 8; col++)
            {
                row++;
                if (row < 8)
                {
                    if (situation.ChessBoard[row, col].Status == 'n')
                        possibleMoves.Add(new Coords(row, col));
                    else
                    {
                        if (situation.ChessBoard[row, col].IsWhite != IsWhite)
                            possibleMoves.Add(new Coords(row, col));
                        break;
                    }
                }
                else
                    break;
            }
            //Check possible attack after moving this piece
            if (check || ProtectingKing)
            {
                for (int i = possibleMoves.Count - 1; i >= 0; i--)
                    if (Engine.ValidMoveDuringCheck(coords, possibleMoves[i], situation) == false)
                        possibleMoves.RemoveAt(i);
            }
            PossibleMoves = possibleMoves.ToArray();
        }
        public override void UpdatePossibleAttacks(Situation situation, Coords coords)
        {
            PieceProtectingKingCoords = new Coords(8, 8);
            List<Coords> possibleAttacks = new List<Coords>();
            sbyte row = coords.Row;
            sbyte col;
            //Left top
            for (col = (sbyte)(coords.Column - 1); col >= 0; col--)
            {
                row--;
                if (row >= 0)
                {
                    if (situation.ChessBoard[row, col].Status == 'n')
                        possibleAttacks.Add(new Coords(row, col));
                    else
                    {
                        possibleAttacks.Add(new Coords(row, col));
                        if (situation.ChessBoard[row, col].IsWhite != IsWhite)
                        {
                            sbyte row2 = row;
                            sbyte col2;
                            for (col2 = (sbyte)(col - 1); col2 >= 0; col2--)
                            {
                                row2--;
                                if (row2 >= 0)
                                {
                                    if (situation.ChessBoard[row2, col2].Status == 'k')
                                    {
                                        if (situation.ChessBoard[row2, col2].IsWhite != IsWhite)
                                            PieceProtectingKingCoords = new Coords(row, col);
                                    }
                                    else
                                        break;
                                }
                                else
                                    break;
                            }
                        }
                        break;
                    }
                }
                else
                    break;
            }
            row = coords.Row;
            //Right top

            for (col = (sbyte)(coords.Column + 1); col < 8; col++)
            {
                row--;
                if (row >= 0)
                {
                    if (situation.ChessBoard[row, col].Status == 'n')
                        possibleAttacks.Add(new Coords(row, col));
                    else
                    {
                        possibleAttacks.Add(new Coords(row, col));
                        if (situation.ChessBoard[row, col].IsWhite != IsWhite)
                        {
                            sbyte row2 = row;
                            sbyte col2;
                            for (col2 = (sbyte)(col + 1); col2 < 8; col2++)
                            {
                                row2--;
                                if (row2 >= 0)
                                {
                                    if (situation.ChessBoard[row2, col2].Status == 'k')
                                    {
                                        if (situation.ChessBoard[row2, col2].IsWhite != IsWhite)
                                            PieceProtectingKingCoords = new Coords(row, col);
                                    }
                                    else
                                        break;
                                }
                                else
                                    break;
                            }
                        }
                        break;
                    }
                }
                else
                    break;
            }
            row = coords.Row;

            //Left bottom
            for (col = (sbyte)(coords.Column - 1); col >= 0; col--)
            {
                row++;
                if (row < 8)
                {
                    if (situation.ChessBoard[row, col].Status == 'n')
                        possibleAttacks.Add(new Coords(row, col));
                    else
                    {
                        possibleAttacks.Add(new Coords(row, col));
                        if (situation.ChessBoard[row, col].IsWhite != IsWhite)
                        {
                            sbyte row2 = row;
                            sbyte col2;
                            for (col2 = (sbyte)(col - 1); col2 >= 0; col2--)
                            {
                                row2++;
                                if (row2 < 8)
                                {
                                    if (situation.ChessBoard[row2, col2].Status == 'k')
                                    {
                                        if (situation.ChessBoard[row2, col2].IsWhite != IsWhite)
                                            PieceProtectingKingCoords = new Coords(row, col);
                                    }
                                    else
                                        break;
                                }
                                else
                                    break;
                            }
                        }
                        break;
                    }
                }
                else
                    break;
            }

            row = coords.Row;
            //Right bottom
            for (col = (sbyte)(coords.Column + 1); col < 8; col++)
            {
                row++;
                if (row < 8)
                {
                    if (situation.ChessBoard[row, col].Status == 'n')
                        possibleAttacks.Add(new Coords(row, col));
                    else
                    {
                        possibleAttacks.Add(new Coords(row, col));
                        if (situation.ChessBoard[row, col].IsWhite != IsWhite)
                        {
                            sbyte row2 = row;
                            sbyte col2;
                            for (col2 = (sbyte)(col + 1); col2 < 8; col2++)
                            {
                                row2++;
                                if (row2 < 8)
                                {
                                    if (situation.ChessBoard[row2, col2].Status == 'k')
                                    {
                                        if (situation.ChessBoard[row2, col2].IsWhite != IsWhite)
                                            PieceProtectingKingCoords = new Coords(row, col);
                                    }
                                    else
                                        break;
                                }
                                else
                                    break;
                            }
                        }
                        break;
                    }
                }
                else
                    break;
            }
            PossibleAttacks = possibleAttacks.ToArray();
        }
    }
}
