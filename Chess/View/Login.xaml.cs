using Chess.ViewModel;
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

namespace Chess.View
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginInGame(object sender, RoutedEventArgs e)
        {
            if (LoginViewModel.checkAllDataToLogin(LoginBox.Text, PasswordBox.Password.GetHashCode().ToString()))
            {
                LabelInvalidNickName.Visibility = Visibility.Visible;
                Log.CommandParameter = "Login";
            }
            else
                Log.CommandParameter = "Menu";

        }
    }
}
