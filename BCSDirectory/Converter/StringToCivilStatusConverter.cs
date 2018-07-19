using BCSDirectory.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace BCSDirectory.Converter
{
    public class StringToCivilStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && (CivilStatus)value == CivilStatus.Married)
            {
                return "Married";
            }

            return "Single";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((string)value).Equals("Married"))
            {
                return CivilStatus.Married;
            }

            return CivilStatus.Single;
        }
    }
}
