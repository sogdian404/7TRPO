using System.Globalization;
using System.Windows.Data;

namespace _7_TRPO.Converters
{
    public class NumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = value?.ToString() ?? string.Empty;
            if (s == string.Empty || s.Length < 11)
                return value;

            return $"{s[..2]} {s[2..5]} {s[5..8]} {s[8..10]} {s[10..]}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => Binding.DoNothing;
    }
}