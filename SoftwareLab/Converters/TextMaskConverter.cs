﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace SoftwareLab.Converters
{
    public class TextMaskConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"{value:#.#}";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
