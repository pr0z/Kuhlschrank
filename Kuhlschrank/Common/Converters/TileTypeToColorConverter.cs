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
    /// <summary>
    /// Converter qui convertit le type d'une tuile en une SolidColorBrush
    /// </summary>
    public class TileTypeToColorConverter : IValueConverter
    {
        /// <summary>
        /// Méthode de conversion
        /// </summary>
        /// <param name="value">valeur du type de tuile</param>
        /// <param name="targetType">controle visé</param>
        /// <param name="parameter">paramètre à prendre en compte</param>
        /// <param name="culture">culture du poste courant</param>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush();
            TileType type = (TileType)value;
            switch (type)
            {
                case TileType.Browser: brush.Color = Colors.BlueViolet; break;
                case TileType.Application: brush.Color = Colors.DodgerBlue; break;
                case TileType.Website: brush.Color = Colors.DarkGoldenrod; break;
                case TileType.Tile: brush.Color = Colors.ForestGreen; break;
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
