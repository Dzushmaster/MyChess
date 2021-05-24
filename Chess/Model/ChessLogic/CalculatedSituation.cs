using Chess.Model.ChessLogic.Figures;
using Chess.Model.ChessLogic.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic
{
    class CalculatedSituation
    {
        public Dictionary<Coords, IPiece> PieceOnTurn { get; }
        public bool WhiteOnTurn { get; }
        public bool Check { get; set; }
        public bool DrawMate { get; set; }
        public CalculatedSituation(Situation situation)
        {
            WhiteOnTurn = situation.WhiteOnTurn;
            Coords kingCoords = new Coords();
            PieceOnTurn = new Dictionary<Coords, IPiece>();
            CalculatedSituationData calculatedSituationData;
            string key = situation.ToString();
            if(Engine.CalculatedSituationData.TryGetValue(key, out calculatedSituationData))
            {
                for(int row = 0; row< 8; row++)
                {
                    for(int col = 0; col<8;col++)
                    {
                        IPiece piece;
                        if (situation.ChessBoard[row, col].IsWhite != WhiteOnTurn || situation.ChessBoard[row, col].Status == 'n') continue;
                        switch(situation.ChessBoard[row, col].Status)
                        {
                            case 'p':
                                piece = new Pawn(situation.ChessBoard[row, col].IsWhite);
                                break;
                            case 'r':
                                piece = new Rook(situation.ChessBoard[row, col].IsWhite);
                                break;
                            case 'h':
                                piece = new Knight(situation.ChessBoard[row, col].IsWhite);
                                break;
                            case 'b':
                                piece = new Bishop(situation.ChessBoard[row, col].IsWhite);
                                break;
                            case 'q':
                                piece = new Queen(situation.ChessBoard[row, col].IsWhite);
                                break;
                            case 'k':
                                piece = new King(situation.ChessBoard[row, col].IsWhite);
                                kingCoords = new Coords((sbyte)row, (sbyte)col);
                                break;
                            default:
                                throw new Exception("Unexpected status");
                        }
                        PieceOnTurn.Add(new Coords((sbyte)row, (sbyte)col), piece);
                    }
                }
            }
            else
            {
                calculatedSituationData = new CalculatedSituationData();
                for(sbyte row = 0; row<8;row++)
                {
                    for (sbyte col = 0; col < 8; col++)
                    {
                        IPiece piece;
                        switch (situation.ChessBoard[row, col].Status)
                        {
                            case 'n':
                                continue;
                            case 'p':
                                piece = new Pawn(situation.ChessBoard[row, col].IsWhite);
                                break;
                            case 'r':
                                piece = new Rook(situation.ChessBoard[row, col].IsWhite);
                                break;
                            case 'h':
                                piece = new Knight(situation.ChessBoard[row, col].IsWhite);
                                break;
                            case 'b':
                                piece = new Bishop(situation.ChessBoard[row, col].IsWhite);
                                break;
                            case 'q':
                                piece = new Queen(situation.ChessBoard[row, col].IsWhite);
                                break;
                            case 'k':
                                piece = new King(situation.ChessBoard[row, col].IsWhite);
                                if (piece.IsWhite == WhiteOnTurn)
                                    kingCoords = new Coords(row, col);
                                break;
                            default:
                                throw new Exception("Unexpected status");
                        }
                        if (piece.IsWhite == WhiteOnTurn)
                            PieceOnTurn.Add(new Coords(row, col), piece);
                        else
                        {
                            piece.UpdatePossibleAttacks(situation, new Coords(row, col));
                            foreach (Coords possibleAttacksCoords in piece.PossibleAttacks)
                                calculatedSituationData.EnemyPossibleAttacks.Add(possibleAttacksCoords);
                            if (piece is MovingPiece)
                            {
                                if (((MovingPiece)piece).PieceProtectingKingCoords.Row != 8)
                                    calculatedSituationData.KingPropertyPiecesCoords.Add(((MovingPiece)piece).PieceProtectingKingCoords);
                            }
                        }
                    }
                }
                Engine.CalculatedSituationData.TryAdd(key, calculatedSituationData);
            }
            if (calculatedSituationData.EnemyPossibleAttacks.Contains(kingCoords))
                Check = true;
            foreach(Coords coords in calculatedSituationData.KingPropertyPiecesCoords)
            {
                ((Piece)PieceOnTurn[coords]).ProtectingKing = true;
            }
            DrawMate = true;
            foreach(KeyValuePair<Coords, IPiece> pair in PieceOnTurn)
            {
                if(pair.Value is King)
                    ((King)pair.Value).PossibleEnemeAttacks = calculatedSituationData.EnemyPossibleAttacks;
                pair.Value.UpdatePossibleMoves(situation, Check, pair.Key);
                if (DrawMate == true && pair.Value.PossibleMoves.Length > 0)
                    DrawMate = false;
            }
        }
        public static bool FindOutCheck(Situation situation) => GetAllCalculatedSituation(situation).EnemyPossibleAttacks.Contains(situation.KingCoords)? true: false;

        public static CalculatedSituationData GetAllCalculatedSituation(Situation situation)
        {
            CalculatedSituationData calculatedSituationData;
            string key = situation.ToString();
            if (Engine.CalculatedSituationData.TryGetValue(key, out calculatedSituationData))
                return calculatedSituationData;
            calculatedSituationData = new CalculatedSituationData();

            #region Enemy pieces and their attacks
            for(sbyte row = 0; row<8; row++)
            {
                for(sbyte col = 0; col <8; col++)
                {
                    IPiece piece;
                    switch(situation.ChessBoard[row, col].Status)
                    {
                        case 'n':
                            continue;
                        case 'p':
                            piece = new Pawn(situation.ChessBoard[row, col].IsWhite);
                            break;
                        case 'r':
                            piece = new Rook(situation.ChessBoard[row, col].IsWhite);
                            break;
                        case 'h':
                            piece = new Knight(situation.ChessBoard[row, col].IsWhite);
                            break;
                        case 'b':
                            piece = new Bishop(situation.ChessBoard[row, col].IsWhite);
                            break;
                        case 'q':
                            piece = new Queen(situation.ChessBoard[row, col].IsWhite);
                            break;
                        case 'k':
                            piece = new King(situation.ChessBoard[row, col].IsWhite);
                            break;
                        default:
                            throw new Exception("Unexpected status");
                    }
                    if(situation.ChessBoard[row, col].IsWhite != situation.WhiteOnTurn)
                    {
                        piece.UpdatePossibleAttacks(situation, new Coords(row, col));
                        foreach(Coords possibleAttacks in piece.PossibleAttacks)
                        {
                            calculatedSituationData.EnemyPossibleAttacks.Add(possibleAttacks);
                        }
                        if (piece is MovingPiece)
                            if (((MovingPiece)piece).PieceProtectingKingCoords.Row != 8)
                                calculatedSituationData.KingPropertyPiecesCoords.Add(((MovingPiece)piece).PieceProtectingKingCoords);
                    }
                }
            }
            #endregion
            Engine.CalculatedSituationData.TryAdd(key, calculatedSituationData);
            return calculatedSituationData;
        }
    }

}
