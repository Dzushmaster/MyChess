using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    [Table("Player")]
    public class Player : INotifyPropertyChanged
    {
        public Player() { }
        public Player(string nickName, string password)
        {
            NickName = nickName;
            Password = password;
            WinsCount = 0;
            AmountParties = 0;
            Role = (int)Roles.Role.User;
        }
        
        private string nickName;
        [Key]
        [MaxLength(25)]
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
        [Required]
        [MaxLength(20)]
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        private int winsCount;
        [Required]
        public int WinsCount
        {
            get => winsCount;
            set
            {
                if(checkNumber(value))
                {
                    winsCount = value;
                    OnPropertyChanged("AmountWins");
                }
            }
        }
        private int amountParties;
        [Required]
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
        private int role;
        [Required]
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

        private bool checkNumber(int value) => value > 0;
        private bool checkRole(int role) => role == (int)Roles.Role.Admin || role == (int)Roles.Role.User;
    }
}
