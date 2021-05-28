using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    [Table("GameInfo")]
    class GameInfo : INotifyPropertyChanged
    {
        [Required]
        long GameNumber { get; set; }
        [Required]
        [MaxLength(7)]
        string Duration { get; set; }
        [Required]
        bool Win { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
