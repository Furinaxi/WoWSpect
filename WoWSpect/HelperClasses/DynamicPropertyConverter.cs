using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace WoWSpect.HelperClasses;

public class DynamicPropertyConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || parameter == null) return null;

        var propertyPath = parameter.ToString();
        var properties = propertyPath.Split('.');

        foreach (var propertyName in properties)
        {
            if (value == null)
                return null;

            var property = value.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            value = property?.GetValue(value, null);
        }

        return value?.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
