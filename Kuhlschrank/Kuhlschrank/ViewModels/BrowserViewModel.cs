using Common;
using Kuhlschrank.Context;
using Kuhlschrank.Views;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kuhlschrank.ViewModels
{
    public class BrowserViewModel : INotifyPropertyChanged
    {
        #region PROPERTIES
        private ApplicationContext _context;
        public ApplicationContext Context
        {
            get { return _context; }
            set
            {
                if (_context != value)
                {
                    _context = value;
                    NotifyPropertyChanged("Context");
                }
            }
        }
        #endregion

        #region CTOR
        public BrowserViewModel(ApplicationContext context)
        {
            this.Context = context;
        }
        #endregion

        #region INotifyPropertyChanged MEMBERS
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyId)
        {
        }
        #endregion
    }
}
