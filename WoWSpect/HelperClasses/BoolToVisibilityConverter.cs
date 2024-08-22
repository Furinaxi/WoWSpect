using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WoWSpect.HelperClasses;

public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool) value ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Visibility visibility = (Visibility)value;
        // return visibility == Visibility.Visible;
        
        throw new NotImplementedException();
    }
}
