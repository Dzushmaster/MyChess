using Chess.View;
using Chess.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Chess
{
    
    public partial class MainWindow : Window
    {
        public static MenuViewModel _model = new MenuViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _model;
            _model.SelectPage.Execute("Login");
        }
    }
}
