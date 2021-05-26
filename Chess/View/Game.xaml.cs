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
            Button[,] buttons = createBoard();
            engine = new Engine(buttons, textBlockStatus, OpenPawnChoice);
            DataContext = engine;
        }
        public Button[,] createBoard()
        {
            Button[,] buttons = new Button[8, 8];
            for (sbyte row = 0; row < 8; row++)
            {
                for (sbyte column = 0; column < 8; column++)
                {
                    Button button = new Button();
                    button.SetValue(Grid.ColumnProperty, (int)column);
                    button.SetValue(Grid.RowProperty, (int)row);
                    button.SetValue(Border.BorderThicknessProperty, new Thickness(0));
                    button.Focusable = false;
                    button.Padding = new Thickness(0);
                    button.Tag = new Coords(row, column);
                    if (row % 2 != column % 2)
                        button.Background = new SolidColorBrush(Color.FromRgb(154, 205, 205));
                    else
                        button.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    Grid grid = new Grid();
                    grid.Children.Add(new UIElement());
                    grid.Children.Add(new UIElement());
                    button.Content = grid;
                    buttons[row, column] = button;
                    GridBoard.Children.Add(button);
                }
            }
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
