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
using System.Windows.Shapes;

namespace Chess.View
{
    /// <summary>
    /// Логика взаимодействия для PawnSelection.xaml
    /// </summary>
    public partial class PawnSelection : Window
    {
        public char Status { get; private set; }
        public PawnSelection(bool isWhite)
        {
            InitializeComponent();
            Image img;
            for(int i = 0; i < 4; i++)
            {
                img = new Image();
                img.SetValue(RenderOptions.BitmapScalingModeProperty, BitmapScalingMode.Fant);
                img.IsHitTestVisible = false;
                switch(i)
                {
                    case 0:
                        if (isWhite)
                            img.Source = new BitmapImage(new Uri("D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/White_Rook.png"));
                        else
                            img.Source = new BitmapImage(new Uri("D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/Black_Rook.png"));
                        button_rook.Content = img;
                        break;
                    case 1:
                        if (isWhite)
                            img.Source = new BitmapImage(new Uri("D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/White_Bishop.png"));
                        else
                            img.Source = new BitmapImage(new Uri("D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/Black_Bishop.png"));
                        button_bishop.Content = img;
                        break;
                    case 2:
                        if (isWhite)
                            img.Source = new BitmapImage(new Uri("D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/White_Knight.png"));
                        else
                            img.Source = new BitmapImage(new Uri("D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/Black_Knight.png"));
                        button_knight.Content = img;
                        break;
                    case 3:
                        if (isWhite)
                            img.Source = new BitmapImage(new Uri("D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/White_Queen.png"));
                        else
                            img.Source = new BitmapImage(new Uri("D:/Last_Course_Project/COURSE_PROJECT/Image/Pieces/Black_Queen.png"));
                        button_queen.Content = img;
                        break;
                }

            }
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Button)
            {
                if (e.Source == button_rook)
                    Status = 'r';
                else if (e.Source == button_bishop)
                    Status = 's';
                else if (e.Source == button_knight)
                    Status = 'h';
                else if (e.Source == button_queen)
                    Status = 'q';
                Close();
            }
            else
                DragMove();
        }
    }
}
