using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    /// <summary>
    /// Classe recensant les différents outils utiles au reste du projet
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Méthode permettant de changer le type d'une variable vers le type passé en paramètre
        /// </summary>
        /// <typeparam name="T">type cible</typeparam>
        /// <param name="value">valer</param>
        /// <returns>l'objet convertit</returns>
        public static T ChangeType<T>(object value)
        {
            if (value == DBNull.Value)
                return default(T);

            Type conversionType = typeof(T);
            if (conversionType == null)
                throw new ArgumentNullException("conversionType");

            if (value == null)
                return default(T);

            if ((value as string) == string.Empty)
                return default(T);

            if (conversionType.IsGenericType &&
              conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }

            return (T)System.Convert.ChangeType(value, conversionType);
        }
    }
}
