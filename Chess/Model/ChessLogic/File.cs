using Chess.Model.ChessLogic.Pieces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic
{
    class ChessFile
    {
        public Situation Situation { get; private set; }
        public ChessFile()
        {

        }
        public ChessFile(Situation situation)
        {
            Situation = situation;
        }
        public void Save(string fileName)
        {
            if (Situation == null) throw new Exception("Missing data");
            FileStream fs = File.Create(fileName);
            using(StreamWriter sw = new StreamWriter(fs))
            {
                WriteBasicData(sw, Situation);
            }
        }
        void WriteBasicData(StreamWriter sw, Situation situation)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    if (situation.ChessBoard[row, column].Status == 'n')
                    {
                        sw.Write(situation.ChessBoard[row, column].Status + " ");
                    }
                    else
                    {
                        sw.Write(situation.ChessBoard[row, column].Status);
                        if (situation.ChessBoard[row, column].IsWhite)
                            sw.Write('b');
                        else
                            sw.Write('c');
                    }
                }
                sw.WriteLine();
            }
            sw.WriteLine(situation.WhiteOnTurn.ToString()[0].ToString() + situation.WhiteKingMoved.ToString()[0].ToString()
                + situation.WhiteShortRookMoved.ToString()[0].ToString() + situation.WhiteLongRookMoved.ToString()[0].ToString()
                + situation.BlackKingMoved.ToString()[0].ToString() + situation.BlackShortRookMoved.ToString()[0].ToString()
                + situation.BlackLongRookMoved.ToString()[0].ToString());
        }
        public void Load(Stream stream)
        {
            Situation = new Situation();
            using (StreamReader sr = new StreamReader(stream))
            {
                Situation = LoadBasicData(sr);
            }
        }
        Situation LoadBasicData(StreamReader sr)
        {
            Situation situation = new Situation();
            char c;
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    c = (char)sr.Read();
                    // If there is no other char to read, sr.Read() reutrns '\uffff'
                    if (c == '\uffff')
                        return null;
                    situation.ChessBoard[row, column] = new PieceChar(c);
                    if (c != 'n')
                    {
                        c = (char)sr.Read();
                        if (c == 'b')
                            situation.ChessBoard[row, column].IsWhite = true;
                        else
                            situation.ChessBoard[row, column].IsWhite = false;
                    }
                    else
                    {
                        // Reads the empty space behind the empty square ('n')
                        sr.Read();
                    }
                }
                if (row == 7)
                { }
                // Reads the "\r" char.
                sr.Read();
                // Reads the "\n" char.
                sr.Read();
            }
            // White on turn
            c = (char)sr.Read(); if (c == 'T') situation.WhiteOnTurn = true; else situation.WhiteOnTurn = false;
            // Other booleans
            c = (char)sr.Read(); if (c == 'T') situation.WhiteKingMoved = true; else situation.WhiteKingMoved = false;
            c = (char)sr.Read(); if (c == 'T') situation.WhiteShortRookMoved = true; else situation.WhiteShortRookMoved = false;
            c = (char)sr.Read(); if (c == 'T') situation.WhiteLongRookMoved = true; else situation.WhiteLongRookMoved = false;
            c = (char)sr.Read(); if (c == 'T') situation.BlackKingMoved = true; else situation.BlackKingMoved = false;
            c = (char)sr.Read(); if (c == 'T') situation.BlackShortRookMoved = true; else situation.BlackShortRookMoved = false;
            c = (char)sr.Read(); if (c == 'T') situation.BlackLongRookMoved = true; else situation.BlackLongRookMoved = false;
            c = (char)sr.Read();
            sr.Read();
            return situation;
        }
    }
}
