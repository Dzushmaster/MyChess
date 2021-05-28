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
    class RegisterViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public static bool CheckNickName(string nickName) => CheckInvalidSymbols(nickName) || DataBaseMethods.FindUserByName(nickName) ||!CheckLength(nickName);
        private static bool CheckInvalidSymbols(string nickName) => nickName.Contains('@') && nickName.Contains('[') && nickName.Contains(']') && nickName.Contains('{') && nickName.Contains('}') && nickName.Contains(';') && nickName.Contains(':');
        private static bool CheckLength(string nickName) => nickName.Length <= 25 && nickName.Length > 7;
    }
}
