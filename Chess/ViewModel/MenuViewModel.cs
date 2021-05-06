using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows;
//////////////////////////////
using Chess.Model.Commands;
using Chess.View;
using System.Windows.Input;

namespace Chess.ViewModel
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        private Page currentPage;
        private MenuModel menu;
        private Raiting raiting;
        private Game game;
        private RelayCommand selectPage;
        private RelayCommand closeGame;
        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                currentPage.DataContext = this;
                OnPropertyChanged("CurrentPage");
            }
        }
        public RelayCommand CloseGame
        {
            get => closeGame ?? (closeGame = new RelayCommand(obj => { Application.Current.MainWindow.Close(); }));
        }
        public RelayCommand SelectPage
        {
            get
            {
                return selectPage ??(selectPage = new RelayCommand(obj =>
                {
                      switch (obj as string)
                      {
                          case "OneDevice":
                              {
                                  if (game == null){ CurrentPage = game = new Game(); }
                                  else{ CurrentPage = game; }
                                  break;
                              }
                          case "Raiting":
                              {
                                  if (raiting == null) { CurrentPage = raiting = new Raiting(); }
                                  else { CurrentPage = raiting; }
                                  break;
                              }
                          case "Menu":
                              {
                                  if (menu == null) { CurrentPage = menu = new MenuModel(); }
                                  else { CurrentPage = menu; }

                                  break;
                              }
                          default:
                              {
                                  CurrentPage = menu;
                                  break;
                              }
                      }
                }));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
