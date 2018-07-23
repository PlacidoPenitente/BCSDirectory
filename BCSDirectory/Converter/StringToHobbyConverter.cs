using BCSDirectory.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace BCSDirectory.Converter
{
    public class StringToHobbyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Hobby)value)?.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Hobby() { Name = (string)value };
        }
    }
}
