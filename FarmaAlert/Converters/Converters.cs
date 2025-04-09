// InitialsConverter.cs
using System.Globalization;

namespace FarmaAlert.Converters
{
    public class InitialsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string fullName && !string.IsNullOrEmpty(fullName))
            {
                var parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 1)
                {
                    if (parts.Length >= 2)
                    {
                        return $"{parts[0][0]}{parts[1][0]}";
                    }
                    return $"{parts[0][0]}";
                }
            }
            return "?";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}