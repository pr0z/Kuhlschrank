using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Common.Command
{
    /// <summary>
    /// Classe qui gère les interactions utilisateur avec les tuiles du menu
    /// </summary>
    public class ActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _action;

        /// <summary>
        /// Constructeur qui initialise l'action
        /// </summary>
        /// <param name="action">Action a valuer</param>
        public ActionCommand(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// Méthode qui détermine si la tuile courante peut être cliquée
        /// </summary>
        /// <param name="parameter">paramètres a passer</param>
        /// <returns></returns>
        public bool CanExecute(object parameter) { return true; }

        /// <summary>
        /// Action exécutée au clic sur la tuille
        /// </summary>
        /// <param name="parameter">paramètres a passer</param>
        public void Execute(object parameter)
        {
            if (_action != null)
                _action();
        }
    }
}
