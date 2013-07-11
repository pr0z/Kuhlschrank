using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Types
{
    /// <summary>
    /// Surchage interne de la classe Dictionnary
    /// </summary>
    /// <typeparam name="T">Type de la clé</typeparam>
    /// <typeparam name="U">Type de la valeur</typeparam>
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        /// <summary>
        /// Constructeur initialisant la clé et la valeur
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };
}
