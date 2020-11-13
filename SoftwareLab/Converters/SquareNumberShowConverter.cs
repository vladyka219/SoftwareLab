using System;
using System.Globalization;
using System.Windows.Data;

namespace SoftwareLab.Converters
{
    public class SquareNumberShowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is uint val)
                return $"{val} * {val} = ";

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string val)
                return int.Parse(val.Split('*')[0].Trim());

            return null;
        }
    }
}
