using Kuhlschrank.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
using DataContracts;

namespace Kuhlschrank.ViewModels
{
	public class TestViewModel : INotifyPropertyChanged
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

		#region COMMANDS
        private DelegateCommand _clickCommand;
        public DelegateCommand ClickCommand
        {
            get { return _clickCommand; }
            set
            {
                if (_clickCommand != value)
                {
                    _clickCommand = value;
                    NotifyPropertyChanged("ClickCommand");
                }
            }
        }
        #endregion

		#region CTOR
        public TestViewModel(ApplicationContext context)
        {
            this.ClickCommand = new DelegateCommand(ClickAction, canClick);
			this.Context = context;
        }
        #endregion

		#region ACTIONS AND CANEXECUTES
        private bool canClick()
        {
            return false;
        }

        private void ClickAction()
        {
            
        }
		#endregion

		#region INotifyPropertyChanged MEMBERS
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
	}
}