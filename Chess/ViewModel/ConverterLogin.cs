using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Chess.ViewModel
{
    class Combo
    {
        public string LoginValue { get; set; }
        public string PasswordValue { get; set; }
    }
    class ConverterLogin : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Combo()
            {
                LoginValue = values[0].ToString(),
                PasswordValue = values[1].ToString()
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
