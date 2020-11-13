using System;
using System.Globalization;
using System.Windows.Data;

namespace SoftwareLab.Converters
{
    public class OffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double val)
                return val - double.Parse(parameter.ToString());

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
