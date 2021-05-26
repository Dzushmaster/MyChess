using Chess.Model.ChessLogic.Pieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Chess.Model.ChessLogic
{
    public struct Coords
    {
        public sbyte Row { get; set; }
        public sbyte Column { get; set; }
        public Coords(sbyte row, sbyte column)
        {
            Row = row;
            Column = column;
        }
        public override string ToString()
        {
            return Row + ";" + Column;
        }
    }
    class Engine : INotifyPropertyChanged
    {
        public double ImageSizeWrapPanel { get; set; }
        Button[,] buttonChessBoard;
        Coords[] selectedCoords;
        Func<bool, char> openPromotionOptions;
        Situation situation;
        CalculatedSituation calculatedSituation;
        TextBlock textBlockStatus;

        public Engine(Button[,] buttons, TextBlock textBlockStatus, Func<bool, char> openPromotionOptions)
        {
            buttonChessBoard = buttons;
            this.textBlockStatus = textBlockStatus;
            this.openPromotionOptions = openPromotionOptions;
        }
        public static void MovePiece(Coords from, Coords to, Situation situation, bool automaticPromotion = true)
        {
            if(situation.ChessBoard[from.Row, from.Column].Status == 'r')
            {
                #region Make castling from Rook
                if(from.Row == 0)
                {
                    if (from.Column == 0)
                        situation.BlackLongRookMoved = true;
                    else if(from.Column == 7)
                        situation.BlackShortRookMoved = true;
                }
                else if(from.Row == 7)
                {
                    if (from.Column == 0)
                        situation.WhiteLongRookMoved = true;
                    else if (from.Column == 7)
                        situation.WhiteShortRookMoved = true;
                }
                #endregion 
            }
            else if(situation.ChessBoard[from.Row, from.Column].Status == 'k')
            {
                #region Make castling from King
                if (situation.ChessBoard[from.Row, from.Column].IsWhite) situation.WhiteKingMoved = true;
                else situation.BlackKingMoved = true;
                int pos = from.Column - to.Column;
                if(Math.Abs(pos) > 1)
                {
                    if (pos > 0)
                        MovePiece(new Coords(from.Row, (sbyte)(from.Column - 4)), new Coords(from.Row, (sbyte)(from.Column - 1)), situation);
                    else
                        MovePiece(new Coords(from.Row, (sbyte)(from.Column + 3)), new Coords(from.Row, (sbyte)(from.Column + 1)), situation);
                    situation.WhiteOnTurn = !situation.WhiteOnTurn;
                }
                #endregion
            }
            situation.ChessBoard[to.Row, to.Column] = situation.ChessBoard[from.Row, from.Column];
            situation.ChessBoard[from.Row, from.Column].Status = 'n';
            if (automaticPromotion && situation.ChessBoard[to.Row, to.Column].Status == 'p')
                if (to.Row == 7 || to.Row == 0)
                    situation.ChessBoard[to.Row, to.Column].Status = 'q';
            situation.WhiteOnTurn = !situation.WhiteOnTurn;                
        }
        public static bool ValidMoveDuringCheck(Coords from, Coords to, Situation situation)
        {
            Situation situationCopy = new Situation(situation);
            MovePiece(from, to, situationCopy);
            situationCopy.WhiteOnTurn = !situationCopy.WhiteOnTurn;
            return !CalculatedSituation.FindOutCheck(situationCopy);
        }
        public static ConcurrentQueuedDictionary<string, CalculatedSituationData> CalculatedSituationData = new ConcurrentQueuedDictionary<string, CalculatedSituationData>(50000);
        Task turnTask = Task.Delay(0);
        void NewGame()
        {
            Settings.NewGame = false;
            Task.Run(() =>
            {
                turnTask.Wait();
            }).ContinueWith(tsk =>
            {
                situation = new Situation();
                calculatedSituation = new CalculatedSituation(situation);
                DrawCalculatedSituation();
                textBlockStatus.Text = "";
                if (selectedCoords != null)
                {
                    foreach (Coords coords in selectedCoords)
                        DeselectSquare(coords);
                    selectedCoords = null;
                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        public void PoleClick(Coords coords)
        {
            if(selectedCoords == null)
            {
                if (situation.ChessBoard[coords.Row, coords.Column].Status != 'n' && situation.ChessBoard[coords.Row, coords.Column].IsWhite == situation.WhiteOnTurn)
                    SelectPossibleMoves(coords);
            }
            else
            {
                foreach (Coords coordsPossibleMove in selectedCoords)
                    DeselectSquare(coordsPossibleMove);

                bool selectedClicked = false;
                for(int i =0;i<selectedCoords.Length - 1; i++)
                {
                    if(selectedCoords[i].Equals(coords))
                    {
                        selectedClicked = true;
                        break;
                    }
                }
                if(selectedClicked)
                {
                    MovePiece(selectedCoords[selectedCoords.Length - 1], coords);
                    selectedCoords = null;
                    DrawCalculatedSituation();
                }
                else
                {
                    if (selectedCoords[selectedCoords.Length - 1].Equals(coords) == false)
                    {
                        selectedCoords = null;
                        if (situation.ChessBoard[coords.Row, coords.Column].Status != 'n' && situation.ChessBoard[coords.Row, coords.Column].IsWhite == situation.WhiteOnTurn)
                            SelectPossibleMoves(coords);
                    }
                    else
                        selectedCoords = null;
                }
            }
        }
        public void MovePiece(Coords from, Coords to, bool automaticPromotion = false)
        {
            MovePiece(from, to, situation, automaticPromotion);
            if (automaticPromotion == false && situation.ChessBoard[to.Row, to.Column].Status == 'p')
                if (to.Row == 7 || to.Row == 0)
                    situation.ChessBoard[to.Row, to.Column].Status = openPromotionOptions(situation.ChessBoard[to.Row, to.Column].IsWhite);
            calculatedSituation = new CalculatedSituation(situation);
        }
        public void LoadedChessUserControl()
        {
            if (Settings.NewGame)
                NewGame();
            else
                DrawCalculatedSituation();
        }
        void DrawCalculatedSituation()
        {
            for(int row = 0; row < 8; row++)
            {
                for(int col = 0; col< 8; col++)
                {
                    switch(situation.ChessBoard[row, col].Status)
                    {
                        case 'n':
                            if(((Grid)buttonChessBoard[row, col].Content).Children[1] is Image)
                            {
                                ((Grid)(buttonChessBoard[row, col].Content)).Children.RemoveRange(0, 2);
                                ((Grid)(buttonChessBoard[row, col].Content)).Children.Add(new System.Windows.UIElement());
                                ((Grid)(buttonChessBoard[row, col].Content)).Children.Add(new System.Windows.UIElement());
                            }
                            break;
                        default:
                            Image img = GeneratePieceImage(situation.ChessBoard[row, col]);
                            ((Grid)(buttonChessBoard[row, col].Content)).Children.RemoveRange(0, 2);
                            ((Grid)(buttonChessBoard[row, col].Content)).Children.Add(new System.Windows.UIElement());
                            ((Grid)(buttonChessBoard[row, col].Content)).Children.Add(img);
                            break;
                    }
                }
            }
            if (selectedCoords != null)
            {
                for (int i = 0; i < selectedCoords.Length - 1; i++)
                    SelectSquare(selectedCoords[i]);
                SelectSquare(selectedCoords[selectedCoords.Length - 1]);
            }
            if(calculatedSituation.Check)
            {
                textBlockStatus.Text = "Check";
                if (calculatedSituation.DrawMate)
                    textBlockStatus.Text = "Mate";
            }
            else
            {
                if (calculatedSituation.DrawMate == false)
                    textBlockStatus.Text = "";
                else
                    textBlockStatus.Text = "Mate";
            }
        }
        void SelectPossibleMoves(Coords coords)
        {
            IPiece piece = calculatedSituation.PieceOnTurn[coords];
            selectedCoords = new Coords[piece.PossibleMoves.Length + 1];
            selectedCoords[selectedCoords.Length - 1] = coords;
            SelectSquare(coords, false, true);
            for(int i = 0; i<piece.PossibleMoves.Length; i++)
            {
                selectedCoords[i] = piece.PossibleMoves[i];
                SelectSquare(piece.PossibleMoves[i]);
            }
        }
        void SelectSquare(Coords coords, bool ai = false, bool main = false)
        {
            UIElement ui = ((Grid)(buttonChessBoard[coords.Row, coords.Column].Content)).Children[1];
            ((Grid)(buttonChessBoard[coords.Row, coords.Column].Content)).Children.RemoveRange(0, 2);
            if (!ai)
            {
                if (!main)
                    ((Grid)(buttonChessBoard[coords.Row, coords.Column].Content)).Children.Add(GenerateSelectedSquare(Brushes.Purple));
                else
                    ((Grid)(buttonChessBoard[coords.Row, coords.Column].Content)).Children.Add(GenerateSelectedSquare(Brushes.Maroon));
            }
            else
                ((Grid)(buttonChessBoard[coords.Row, coords.Column].Content)).Children.Add(GenerateSelectedSquare(Brushes.Green));
            ((Grid)(buttonChessBoard[coords.Row, coords.Column].Content)).Children.Add(ui);
        }
        void DeselectSquare(Coords coords)
        {
            UIElement ui = ((Grid)(buttonChessBoard[coords.Row, coords.Column].Content)).Children[1];
            ((Grid)(buttonChessBoard[coords.Row, coords.Column].Content)).Children.RemoveRange(0, 2);
            ((Grid)(buttonChessBoard[coords.Row, coords.Column].Content)).Children.Add(new UIElement());
            ((Grid)(buttonChessBoard[coords.Row, coords.Column].Content)).Children.Add(ui);
        }
        Rectangle GenerateSelectedSquare(Brush color)
        {
            Rectangle selectedSquare = new Rectangle();
            selectedSquare.Fill = color;
            selectedSquare.Opacity = 0.25;
            selectedSquare.Stretch = Stretch.UniformToFill;
            selectedSquare.HorizontalAlignment = HorizontalAlignment.Stretch;
            selectedSquare.IsHitTestVisible = false;
            return selectedSquare;
        }
        Image GeneratePieceImage(PieceChar pc, bool forWrapPanel = false)
        {
            Image image = new Image() { IsHitTestVisible = false };
            image.SetValue(RenderOptions.BitmapScalingModeProperty, BitmapScalingMode.Fant);
            image.Tag = pc;
            string path;
            switch(pc.Status)
            {
                case 'p':
                    if (pc.IsWhite)
                        path = "D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/White_Pawn.png";
                    else
                        path = "D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/Black_Pawn.png";
                    break;
                case 'r':
                    if (pc.IsWhite)
                        path = "D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/White_Rook.png";
                    else
                        path = "D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/Black_Rook.png";
                    break;
                case 'h':
                    if (pc.IsWhite)
                        path = "D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/White_Knight.png";
                    else
                        path = "D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/Black_Knight.png";
                    break;
                case 's':
                    if (pc.IsWhite)
                        path = "D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/White_Bishop.png";
                    else
                        path = "D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/Black_Bishop.png";
                    break;
                case 'q':
                    if (pc.IsWhite)
                        path = "D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/White_Queen.png";
                    else
                        path = "D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/Black_Queen.png";
                    break;
                case 'k':
                    if (pc.IsWhite)
                        path = "D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/White_King.png";
                    else
                        path = "D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/Black_King.png";
                    break;
                default:
                    throw new Exception("Unexpected status");
            }
            image.Source = new BitmapImage(new Uri(path));
            return image;
        }
        TextBlock GenerateNoLostPiecesTextBlock()
        {
            return new TextBlock() { FontSize = 13, FontWeight = FontWeights.Normal, Padding = new Thickness(3), Text = "No piece has benn lost." };
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
