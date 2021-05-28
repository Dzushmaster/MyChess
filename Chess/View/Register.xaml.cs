using Chess.Model.DataBase;
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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterBt(object sender, RoutedEventArgs e)
        {
            LabelInvalidPassword.Visibility = Visibility.Hidden;
            LabelInvalidNickname.Visibility = Visibility.Hidden;
            if (RegisterViewModel.CheckNickName(LoginBox.Text))
            {
                LabelInvalidNickname.Visibility = Visibility.Visible;
                Reg.CommandParameter = "Register";
            }
            else if (( !(PasswordBox.Password.Length >= 20) && (PasswordBox.Password.Length <=5)) || !PasswordBox.Password.Equals(repPasswordBox.Password))
            {
                LabelInvalidPassword.Visibility = Visibility.Visible;
                Reg.CommandParameter = "Register";
            }
            else
            {
                if(DataBaseMethods.AddUser(new Model.Player(LoginBox.Text, PasswordBox.Password.GetHashCode().ToString())))
                    Reg.CommandParameter = "Login";
            }
        }
    }
}
