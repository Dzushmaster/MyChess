using Chess.Model.ChessLogic.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic.Figures
{
    class Knight : MovingPiece
    {
        public Knight(bool white) : base(white) { }

        public override void UpdatePossibleMoves(Situation situation, bool check, Coords coords)
        {
            List<Coords> possibleMoves = new List<Coords>();
            Coords procCoords;
            //TopLeft
            if(coords.Row > 1 && coords.Column > 0)
            {
                procCoords = new Coords((sbyte)(coords.Row - 2), (sbyte)(coords.Column - 1));
                if (situation.ChessBoard[procCoords.Row, procCoords.Column].Status == 'n' || situation.ChessBoard[procCoords.Row, procCoords.Column].IsWhite != IsWhite)
                    possibleMoves.Add(procCoords);
            }
            //TopRight
            if(coords.Row > 1 && coords.Column < 7)
            {
                procCoords = new Coords((sbyte)(coords.Row - 2), (sbyte)(coords.Column + 1));
                if (situation.ChessBoard[procCoords.Row, procCoords.Column].Status == 'n' || situation.ChessBoard[procCoords.Row, procCoords.Column].IsWhite != IsWhite)
                    possibleMoves.Add(procCoords);
            }
            //LeftTop 
            if (coords.Row > 0 && coords.Column > 1)
            {
                procCoords = new Coords((sbyte)(coords.Row - 1), (sbyte)(coords.Column - 2));
                if (situation.ChessBoard[procCoords.Row, procCoords.Column].Status == 'n' || situation.ChessBoard[procCoords.Row, procCoords.Column].IsWhite != IsWhite)
                    possibleMoves.Add(procCoords);
            }
            //RightTop
            if (coords.Row > 0 && coords.Column < 6)
            {
                procCoords = new Coords((sbyte)(coords.Row - 1), (sbyte)(coords.Column + 2));
                if (situation.ChessBoard[procCoords.Row, procCoords.Column].Status == 'n' || situation.ChessBoard[procCoords.Row, procCoords.Column].IsWhite != IsWhite)
                    possibleMoves.Add(procCoords);
            }
            //LeftBot
            if (coords.Row < 7 && coords.Column > 1)
            {
                procCoords = new Coords((sbyte)(coords.Row + 1), (sbyte)(coords.Column - 2));
                if (situation.ChessBoard[procCoords.Row, procCoords.Column].Status == 'n' || situation.ChessBoard[procCoords.Row, procCoords.Column].IsWhite != IsWhite)
                    possibleMoves.Add(procCoords);
            }
            //RightBot
            if (coords.Row < 7 && coords.Column < 6)
            {
                procCoords = new Coords((sbyte)(coords.Row + 1), (sbyte)(coords.Column + 2));
                if (situation.ChessBoard[procCoords.Row, procCoords.Column].Status == 'n' || situation.ChessBoard[procCoords.Row, procCoords.Column].IsWhite != IsWhite)
                    possibleMoves.Add(procCoords);
            }
            //BotLeft
            if (coords.Row < 6 && coords.Column > 0)
            {
                procCoords = new Coords((sbyte)(coords.Row + 2), (sbyte)(coords.Column - 1));
                if (situation.ChessBoard[procCoords.Row, procCoords.Column].Status == 'n' || situation.ChessBoard[procCoords.Row, procCoords.Column].IsWhite != IsWhite)
                    possibleMoves.Add(procCoords);
            }
            //BotRight
            if (coords.Row < 6 && coords.Column < 7)
            {
                procCoords = new Coords((sbyte)(coords.Row + 2), (sbyte)(coords.Column + 1));
                if (situation.ChessBoard[procCoords.Row, procCoords.Column].Status == 'n' || situation.ChessBoard[procCoords.Row, procCoords.Column].IsWhite != IsWhite)
                    possibleMoves.Add(procCoords);
            }
            PossibleMoves = possibleMoves.ToArray();
        }
        public override void UpdatePossibleAttacks(Situation situation, Coords coords)
        {
            List<Coords> possibleAttacks = new List<Coords>();
            //TopLeft
            if (coords.Row > 1 && coords.Column > 0)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row - 2), (sbyte)(coords.Column - 1)));
            //TopRight
            if (coords.Row > 1 && coords.Column < 7)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row - 2), (sbyte)(coords.Column + 1)));
            //LeftTop 
            if (coords.Row > 0 && coords.Column > 1)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row - 1), (sbyte)(coords.Column - 2)));
            //RightTop
            if (coords.Row > 0 && coords.Column < 6)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row - 1), (sbyte)(coords.Column + 2)));
            //LeftBot
            if (coords.Row < 7 && coords.Column > 1)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row + 1), (sbyte)(coords.Column - 2)));
            //RightBot
            if (coords.Row < 7 && coords.Column < 6)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row + 1), (sbyte)(coords.Column + 2)));
            //BotLeft
            if (coords.Row < 6 && coords.Column > 0)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row + 2), (sbyte)(coords.Column - 1)));
            //BotRight
            if (coords.Row < 6 && coords.Column < 7)
                possibleAttacks.Add(new Coords((sbyte)(coords.Row + 2), (sbyte)(coords.Column + 1)));
            
            PossibleAttacks = possibleAttacks.ToArray();
        }

    }
}
