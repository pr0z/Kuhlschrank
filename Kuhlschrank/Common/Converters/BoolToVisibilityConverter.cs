using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Common.Converters
{
    /// <summary>
    /// Converter qui prend une valeur booléenne en paramètre et retourne un visiblité
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Méthode de conversion
        /// </summary>
        /// <param name="value">valeur booleene</param>
        /// <param name="targetType">controle visé</param>
        /// <param name="parameter">paramètre à prendre en compte</param>
        /// <param name="culture">culture du poste courant</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
                return Visibility.Visible;
            else
                return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
