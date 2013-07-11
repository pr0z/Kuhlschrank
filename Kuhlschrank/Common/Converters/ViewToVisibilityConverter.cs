using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Common.Converters
{
    /// <summary>
    /// Converter qui prend une vue en paramètre et retourne un visiblité
    /// </summary>
    public class ViewToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Méthode de conversion
        /// </summary>
        /// <param name="value">vue</param>
        /// <param name="targetType">controle visé</param>
        /// <param name="parameter">paramètre à prendre en compte</param>
        /// <param name="culture">culture du poste courant</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Type type = null;
            if (value != null)
               type = value.GetType();

            if (value != null && type.Name != "LoginView")
                return Visibility.Visible;
            else
               return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
