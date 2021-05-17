using System.Text;

namespace Chess.Model.ChessLogic.Pieces
{
    public class Situation
    {
        public PieceChar[,] ChessBoard { get; set; }
        public bool WhiteOnTurn { get; set; }
        public int Draw50 { get; set; }
        public Coords KingCoords
        {
            get
            {
                for (sbyte row = 0; row < 8; row++)
                {
                    for (sbyte column = 0; column < 8; column++)
                    {
                        if (ChessBoard[row, column].Status == 'k' && ChessBoard[row, column].IsWhite == WhiteOnTurn)
                            return new Coords(row, column);
                    }
                }
                throw new System.Exception("King is not found");
            }
        }

        #region Castling check
        public bool WhiteKingMoved { get; set; }
        public bool WhiteShortRookMoved { get; set; }
        public bool WhiteLongRookMoved { get; set; }

        public bool BlackKingMoved { get; set; }
        public bool BlackShortRookMoved { get; set; }
        public bool BlackLongRookMoved { get; set; }
        #endregion

        public Situation()
        {
            ChessBoard = new PieceChar[8, 8];
            WhiteOnTurn = true;
            Draw50 = 0;

            #region Set figures on default positions
            for(int row = 0; row < 8; row++)
                for(int column = 0; column < 8; column++)
                {
                    //black figures
                    if (row == 0)
                    {
                        if (column == 0 || column == 7)
                            ChessBoard[row, column] = new PieceChar('r', false);
                        else if (column == 1 || column == 6)
                            ChessBoard[row, column] = new PieceChar('h', false);
                        else if (column == 2 || column == 5)
                            ChessBoard[row, column] = new PieceChar('b', false);
                        else if (column == 3)
                            ChessBoard[row, column] = new PieceChar('q', false);
                        else
                            ChessBoard[row, column] = new PieceChar('k', false);
                    }
                    else if (row == 1)
                        ChessBoard[row, column] = new PieceChar('p', false);
                    //white figures
                    else if (row == 6)
                        ChessBoard[row, column] = new PieceChar('p');
                    else if(row == 7)
                    {
                        if (column == 0 || column == 7)
                            ChessBoard[row, column] = new PieceChar('r');
                        else if (column == 1 || column == 6)             
                            ChessBoard[row, column] = new PieceChar('h');
                        else if (column == 2 || column == 5)             
                            ChessBoard[row, column] = new PieceChar('b');
                        else if (column == 3)                            
                            ChessBoard[row, column] = new PieceChar('q');
                        else                                             
                            ChessBoard[row, column] = new PieceChar('k');
                    }
                    else
                        ChessBoard[row, column] = new PieceChar('n');
                }
            #endregion
        }

        public Situation(Situation situation)
        {
            ChessBoard = situation.ChessBoard;
            WhiteOnTurn = situation.WhiteOnTurn;
            Draw50 = situation.Draw50;
            WhiteKingMoved = situation.WhiteKingMoved;
            WhiteShortRookMoved = situation.WhiteShortRookMoved;
            WhiteLongRookMoved = situation.WhiteLongRookMoved;
            BlackKingMoved = situation.BlackKingMoved;
            BlackShortRookMoved = situation.BlackShortRookMoved;
            BlackLongRookMoved = situation.BlackLongRookMoved;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (ChessBoard[row, col].Status == 'n' || ChessBoard[row, col].Status == 'x') continue;
                    sb.Append(row); sb.Append(col);
                    if (ChessBoard[row, col].IsWhite)
                        sb.Append('b');
                    else
                        sb.Append('c');
                    sb.Append(ChessBoard[row, col].Status);
                }
            }
            sb.Append(WhiteOnTurn.ToString()[0]);
            sb.Append(WhiteKingMoved.ToString()[0]);
            sb.Append(WhiteShortRookMoved.ToString()[0]);
            sb.Append(WhiteLongRookMoved.ToString()[0]);
            sb.Append(BlackKingMoved.ToString()[0]);
            sb.Append(BlackShortRookMoved.ToString()[0]);
            sb.Append(BlackLongRookMoved.ToString()[0]);
            return sb.ToString();
        }
    }
}