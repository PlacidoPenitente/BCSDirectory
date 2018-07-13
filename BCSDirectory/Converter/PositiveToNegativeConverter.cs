﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace BCSDirectory.Converter
{
    public class PositiveToNegativeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)(value ?? 0) * -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
