using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StudentTestingSystem.Converters
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TimeOnly time)
            {
                return time.ToString("t");
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string timeString)
            {
                if (TimeOnly.TryParse(timeString, out TimeOnly time))
                {
                    return time;
                }
            }
            return Binding.DoNothing; // or throw new InvalidOperationException("Unable to convert string to TimeOnly");
        }
    }
}

