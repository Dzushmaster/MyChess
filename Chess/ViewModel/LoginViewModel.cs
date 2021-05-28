using Chess.Model;
using Chess.Model.Commands;
using Chess.Model.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public static Player logedUser { get; set; }
        public static Player logedEnemy { get; set; }
        public static bool checkAllDataToLogin(string nickName, string password)
        {
            if(DataBaseMethods.FindUserByName(nickName))
                logedUser = DataBaseMethods.FindUserPassword(nickName, password);
            return logedUser == null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
