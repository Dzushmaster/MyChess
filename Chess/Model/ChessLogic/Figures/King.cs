using Chess.Model.ChessLogic.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic.Figures
{
    class King:Piece
    {
        public King(bool white) : base(white) { }
        public HashSet<Coords> PossibleEnemeAttacks { get; set; }

        public override void UpdatePossibleMoves(Situation situation, bool check, Coords coords)
        {
            List<Coords> possibleMoves = new List<Coords>();
            Coords cord = new Coords(coords.Row, (sbyte)(coords.Column - 1));
            #region Moving
            //Left
            if (coords.Column > 0)
                if (situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false && situation.ChessBoard[cord.Row, cord.Column].IsWhite != IsWhite)
                    possibleMoves.Add(cord);
            //LeftUp
            cord = new Coords((sbyte)(coords.Row - 1), (sbyte)(coords.Column - 1));
            if (coords.Column > 0 && coords.Row > 0)
                if (situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false && situation.ChessBoard[cord.Row, cord.Column].IsWhite != IsWhite)
                    possibleMoves.Add(cord);
            //Up
            cord = new Coords((sbyte)(coords.Row - 1), coords.Column);
            if (coords.Row > 0)
                if (situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false && situation.ChessBoard[cord.Row, cord.Column].IsWhite != IsWhite)
                    possibleMoves.Add(cord);
            //RightUp
            cord = new Coords((sbyte)(coords.Row - 1), (sbyte)(coords.Column + 1));
            if (coords.Row > 0 && coords.Column < 7)
                if (situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false && situation.ChessBoard[cord.Row, cord.Column].IsWhite != IsWhite)
                    possibleMoves.Add(cord);
            //Right
            cord = new Coords(coords.Row, (sbyte)(coords.Column + 1));
            if (coords.Column < 7)
                if (situation.ChessBoard[coords.Row, coords.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false && situation.ChessBoard[cord.Row, cord.Column].IsWhite != IsWhite)
                    possibleMoves.Add(cord);
            //RightDown
            cord = new Coords((sbyte) (coords.Row + 1), (sbyte)(coords.Column + 1));
            if (coords.Row < 7 && coords.Row < 7)
                if (situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false && situation.ChessBoard[cord.Row, cord.Column].IsWhite != IsWhite)
                    possibleMoves.Add(cord);
            //Down
            cord = new Coords((sbyte)(coords.Row + 1), coords.Column);
            if (coords.Row < 7)
                if (situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false && situation.ChessBoard[cord.Row, cord.Column].IsWhite != IsWhite)
                    possibleMoves.Add(cord);
            //LeftDown
            cord = new Coords((sbyte)(coords.Row + 1), (sbyte)(coords.Column - 1));
            if (coords.Row < 7 && coords.Column > 0)
                if (situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) && situation.ChessBoard[cord.Row, cord.Column].IsWhite != IsWhite)
                    possibleMoves.Add(cord);
            #endregion
            #region Castling
            if(check == false)
            {
                if(IsWhite)
                {
                    if(situation.WhiteKingMoved == false)
                    {
                        if(situation.WhiteShortRookMoved == false)
                        {
                            if(situation.ChessBoard[coords.Row, coords.Column + 1].Status == 'n' && PossibleEnemeAttacks.Contains(new Coords((coords.Row), (sbyte)(coords.Column + 1))) == false)
                            {
                                cord = new Coords(coords.Row, (sbyte)(coords.Column + 2));
                                if (situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false)
                                {
                                    if (situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false)
                                        possibleMoves.Add(cord);
                                }
                            }

                        }
                        if (situation.WhiteLongRookMoved == false)
                        {
                            if(situation.ChessBoard[coords.Row, coords.Column - 1].Status == 'n' && PossibleEnemeAttacks.Contains(new Coords(coords.Row, (sbyte)(coords.Column - 1))) == false)
                            {
                                cord = new Coords(coords.Row, (sbyte)(coords.Column - 2));
                                if(situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false)
                                {
                                    if (situation.ChessBoard[coords.Row, coords.Column - 3].Status == 'n' )
                                        possibleMoves.Add(cord);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (situation.BlackKingMoved == false)
                    {
                        if (situation.BlackShortRookMoved == false)
                        {
                            if (situation.ChessBoard[coords.Row, coords.Column + 1].Status == 'n' && PossibleEnemeAttacks.Contains(new Coords((coords.Row), (sbyte)(coords.Column + 1))) == false)
                            {
                                cord = new Coords(coords.Row, (sbyte)(coords.Column + 2));
                                if (situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false)
                                {
                                    if (situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false)
                                        possibleMoves.Add(cord);
                                }
                            }

                        }
                        if (situation.BlackLongRookMoved == false)
                        {
                            if (situation.ChessBoard[coords.Row, coords.Column - 1].Status == 'n' && PossibleEnemeAttacks.Contains(new Coords(coords.Row, (sbyte)(coords.Column - 1))) == false)
                            {
                                cord = new Coords(coords.Row, (sbyte)(coords.Column - 2));
                                if (situation.ChessBoard[cord.Row, cord.Column].Status == 'n' && PossibleEnemeAttacks.Contains(cord) == false)
                                {
                                    if (situation.ChessBoard[coords.Row, coords.Column - 3].Status == 'n')
                                        possibleMoves.Add(cord);
                                }
                            }
                        }
                    }
                }
            }
            //Check possible attack after moving this piece
            else
            {
                for (int i = possibleMoves.Count - 1; i >= 0; i--)
                    if (Engine.ValidMoveDuringCheck(coords, possibleMoves[i], situation))
                        possibleMoves.RemoveAt(i);
            }
            PossibleMoves = possibleMoves.ToArray();
            #endregion
        }
        public override void UpdatePossibleAttacks(Situation situation, Coords coords)
        {
            List<Coords> possibleAttacks = new List<Coords>(8);
            // Left
            if (coords.Column > 0)
                possibleAttacks.Add(new Coords(coords.Row, (sbyte)(coords.Column - 1)));
            // Left up
            if (coords.Column > 0 && coords.Row > 0)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row - 1), (sbyte)(coords.Column - 1)));
            // Up
            if (coords.Row > 0)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row - 1), coords.Column));
            // Right up
            if (coords.Column < 7 && coords.Row > 0)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row - 1), (sbyte)(coords.Column + 1)));
            // Right
            if (coords.Column < 7)
                possibleAttacks.Add(new Coords(coords.Row, (sbyte)(coords.Column + 1)));
            // Right down
            if (coords.Column < 7 && coords.Row < 7)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row + 1), (sbyte)(coords.Column + 1)));
            // Down
            if (coords.Row < 7)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row + 1), coords.Column));
            // Left down
            if (coords.Column > 0 && coords.Row < 7)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row + 1), (sbyte)(coords.Column - 1)));
            PossibleAttacks = possibleAttacks.ToArray();
        }
    }
}
