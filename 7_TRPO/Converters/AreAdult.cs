using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _7_TRPO.Converters
{
    public class AreAdult : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null)
            {
                return "Ошибка";
            }
            DateTime bd = (DateTime)value;
            var age = DateTime.Today.Year - bd.Year;
            if (bd > DateTime.Today.AddYears(-age)) age--;
            return age >= 18 ? $"Возраст: {age} (Совершеннолетний)" : $"Возраст: {age} (Несовершеннолетний)";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => Binding.DoNothing;
    }
}
