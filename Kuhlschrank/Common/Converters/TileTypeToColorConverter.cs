using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Common.Converters
{
    public class TileTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush();
            TileType type = (TileType)value;
            switch (type)
            {
                case TileType.Browser: brush.Color = Colors.BlueViolet; break;
                case TileType.Application: brush.Color = Colors.DodgerBlue; break;
                case TileType.Website: brush.Color = Colors.DarkGoldenrod; break;
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
