using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    [DataContract]
    class User : INotifyPropertyChanged
    {
        private string nickName;
        [DataMember]
        public string NickName
        {
            get => nickName;
            set
            {
                nickName = value;
                OnPropertyChanged("NickName");
            }
        }
        private string password;
        [DataMember]
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        private int amountWins;
        [DataMember]
        public int AmounWins
        {
            get => amountWins;
            set
            {
                if(checkNumber(value))
                {
                    amountWins = value;
                    OnPropertyChanged("AmountWins");
                }
            }
        }
        private int amountParties;
        [DataMember]
        public int AmountParties
        {
            get => amountParties;
            set
            {
                if (checkNumber(value))
                {
                    amountParties = value;
                    OnPropertyChanged("AmountParties");
                }
            }
        }
        private int amountLoses;
        [DataMember]
        public int AmountLoses
        {
            get => amountLoses;
            set
            {
                if(checkNumber(value))
                {
                    amountLoses = value;
                    OnPropertyChanged("AmountLoses");
                }
            }
        }
        private int role;
        [DataMember]
        public int Role
        {
            get => role;
            set
            {
                if(checkRole(value))
                {
                    role = value;
                    OnPropertyChanged("Role");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        //Заменить на валидатор
        private bool checkNumber(int value) => value > 0;
        private bool checkRole(int role) => role == (int)Roles.Role.Admin || role == (int)Roles.Role.User;
    }
}
