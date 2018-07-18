using BCSDirectory.Model;
using System;
using System.Globalization;
using System.Windows.Data;

namespace BCSDirectory.Converter
{
    public class StringToUserTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && (UserType)value == UserType.Editor) return "Editor";
            if (value != null && (UserType)value == UserType.Employee) return "Employee";
            return "Viewer";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((string)value).Equals("Editor")) return UserType.Editor;
            if (((string)value).Equals("Employee")) return UserType.Employee;
            return UserType.Viewer;
        }
    }
}
