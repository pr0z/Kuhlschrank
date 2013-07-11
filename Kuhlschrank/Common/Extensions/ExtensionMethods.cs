using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    /// <summary>
    /// Classe recensant les méthodes d'extension du projet
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Extension à la classe List qui la convertit en ObservabbleCollection
        /// </summary>
        /// <typeparam name="T">type dynamique de la liste</typeparam>
        /// <param name="enumerable">liste a convertir</param>
        /// <returns>L'instance d'ObservableCollection créee</returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this List<T> enumerable)
        {
            var col = new ObservableCollection<T>();
            foreach (var cur in enumerable)
            {
                col.Add(cur);
            }
            return col;
        }
    }
}
