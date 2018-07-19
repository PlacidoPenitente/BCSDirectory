using BCSDirectory.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace BCSDirectory.Converter
{
    public class StringToGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && (Gender)value == Gender.Female)
            {
                return "Female";
            }

            return "Male";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((string)value).Equals("Female"))
            {
                return Gender.Female;
            }

            return Gender.Male;
        }
    }
}
