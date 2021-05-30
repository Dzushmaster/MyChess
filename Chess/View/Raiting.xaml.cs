using Chess.Model;
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
    /// Логика взаимодействия для Raiting.xaml
    /// </summary>
    public partial class Raiting : Page
    {
        List<Player> players;
        public Raiting()
        {
            InitializeComponent();
            GetByName();
            if (!CheckAdmin())
            {
                DelBox.Visibility = Visibility.Hidden;
                DeleteUser.Visibility = Visibility.Hidden;
            }
        }
        private bool CheckAdmin() => LoginViewModel.logedUser.Role == (int)Roles.Role.Admin;

        private void PartiesBt(object sender, RoutedEventArgs e)
        {
            RaitGrid.ItemsSource = DataBaseMethods.GetPlayersByAmountParties();
        }

        private void WinsBt(object sender, RoutedEventArgs e)
        {
            RaitGrid.ItemsSource = DataBaseMethods.GetPlayersByWins();
        }
        private void GetByName()
        {
            RaitGrid.ItemsSource = DataBaseMethods.GetPlayersByName();
        }

        private void DeleteUserBt(object sender, RoutedEventArgs e)
        {
            if (DataBaseMethods.DeleteUser(DelBox.Text))
            {
                RaitGrid.ItemsSource = DataBaseMethods.GetPlayersByName();
                DelBox.Text = "Успешно удален";
            }
            else
                DelBox.Text = "Пользователь не найден";
        }
    }
}
