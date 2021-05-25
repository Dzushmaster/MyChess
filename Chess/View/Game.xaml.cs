using Chess.Model.ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Chess.View
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        Engine engine;
        System.Windows.Media.Effects.BlurEffect objBlur = new System.Windows.Media.Effects.BlurEffect() { Radius = 5 };
        public Game()
        {
            InitializeComponent();
            resizeTimer.Tick += resizeTimer_Tick;
            Image[,] buttons = createBoard();
            buttons[0, 0].Source = new BitmapImage(new Uri("D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/White_Pawn.png"));
            engine = new Engine(buttons, textBlockStatus, OpenPawnChoice);
            DataContext = this;
        }
        public Image[,] createBoard()
        {
            Image[,] buttons = new Image[8, 8];
            #region Set buttons image
            buttons[0, 0] = x0y0;
            buttons[0, 1] = x0y1;
            buttons[0, 2] = x0y2;
            buttons[0, 3] = x0y3;
            buttons[0, 4] = x0y4;
            buttons[0, 5] = x0y5;
            buttons[0, 6] = x0y6;
            buttons[0, 7] = x0y7;

            buttons[1, 0] = x1y0;
            buttons[1, 1] = x1y1;
            buttons[1, 2] = x1y2;
            buttons[1, 3] = x1y3;
            buttons[1, 4] = x1y4;
            buttons[1, 5] = x1y5;
            buttons[1, 6] = x1y6;
            buttons[1, 7] = x1y7;

            buttons[2, 0] = x2y0;
            buttons[2, 1] = x2y1;
            buttons[2, 2] = x2y2;
            buttons[2, 3] = x2y3;
            buttons[2, 4] = x2y4;
            buttons[2, 5] = x2y5;
            buttons[2, 6] = x2y6;
            buttons[2, 7] = x2y7;

            buttons[3, 0] = x3y0;
            buttons[3, 1] = x3y1;
            buttons[3, 2] = x3y2;
            buttons[3, 3] = x3y3;
            buttons[3, 4] = x3y4;
            buttons[3, 5] = x3y5;
            buttons[3, 6] = x3y6;
            buttons[3, 7] = x3y7;

            buttons[4, 0] = x4y0;
            buttons[4, 1] = x4y1;
            buttons[4, 2] = x4y2;
            buttons[4, 3] = x4y3;
            buttons[4, 4] = x4y4;
            buttons[4, 5] = x4y5;
            buttons[4, 6] = x4y6;
            buttons[4, 7] = x4y7;

            buttons[5, 0] = x5y0;
            buttons[5, 1] = x5y1;
            buttons[5, 2] = x5y2;
            buttons[5, 3] = x5y3;
            buttons[5, 4] = x5y4;
            buttons[5, 5] = x5y5;
            buttons[5, 6] = x5y6;
            buttons[5, 7] = x5y7;

            buttons[6, 0] = x6y0;
            buttons[6, 1] = x6y1;
            buttons[6, 2] = x6y2;
            buttons[6, 3] = x6y3;
            buttons[6, 4] = x6y4;
            buttons[6, 5] = x6y5;
            buttons[6, 6] = x6y6;
            buttons[6, 7] = x6y7;

            buttons[7, 0] = x7y0;
            buttons[7, 1] = x7y1;
            buttons[7, 2] = x7y2;
            buttons[7, 3] = x7y3;
            buttons[7, 4] = x7y4;
            buttons[7, 5] = x7y5;
            buttons[7, 6] = x7y6;
            buttons[7, 7] = x7y7;

            #endregion
            return buttons;
        }
        private char OpenPawnChoice(bool isWhite)
        {
            PawnSelection ps = new PawnSelection(isWhite);
            ps.Owner = Application.Current.MainWindow;
            Application.Current.MainWindow.Effect = objBlur;
            ps.ShowDialog();
            Application.Current.MainWindow.Effect = null;
            return ps.Status;
        }

        private void GridBoard_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            engine.PoleClick((Coords)((Button)e.Source).Tag);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            engine.LoadedChessUserControl();
        }
        DispatcherTimer resizeTimer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(10) };
        void resizeTimer_Tick(object sender, EventArgs e)
        {
            resizeTimer.IsEnabled = false;
            engine.ImageSizeWrapPanel = GridBoard.ActualWidth * sizeRatio;
        }
        const double sizeRatio = 0.105;
    }
}
