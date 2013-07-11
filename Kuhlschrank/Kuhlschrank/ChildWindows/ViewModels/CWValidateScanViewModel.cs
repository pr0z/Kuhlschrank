using Kuhlschrank.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
using DataContracts;
using System.Windows;

namespace Kuhlschrank.ChildWindows.ViewModels
{
	public class CWValidateScanViewModel : INotifyPropertyChanged
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

        private Window _view;
        public Window View
        {
            get { return _view; }
            set
            {
                if (_view != value)
                {
                    _view = value;
                    NotifyPropertyChanged("View");
                }
            }
        }
		#endregion

		#region COMMANDS
        private DelegateCommand _validateCommand;
        public DelegateCommand ValidateCommand
        {
            get { return _validateCommand; }
            set
            {
                if (_validateCommand != value)
                {
                    _validateCommand = value;
                    NotifyPropertyChanged("ValidateCommand");
                }
            }
        }

        private DelegateCommand _cancelCommand;
        public DelegateCommand CancelCommand
        {
            get { return _cancelCommand; }
            set
            {
                if (_cancelCommand != value)
                {
                    _cancelCommand = value;
                    NotifyPropertyChanged("CancelCommand");
                }
            }
        }
        #endregion

		#region CTOR
        public CWValidateScanViewModel(ApplicationContext context, Window view)
        {
            this.ValidateCommand = new DelegateCommand(ValidateAction, canValidate);
            this.CancelCommand = new DelegateCommand(CancelAction, canCancel);
			this.Context = context;
            this.View = view;
        }
        #endregion

		#region ACTIONS AND CANEXECUTES
        private bool canValidate()
        {
            return false;
        }

        private void ValidateAction()
        {
            this.View.DialogResult = true;
        }

        private bool canCancel()
        {
            return true;
        }

        private void CancelAction()
        {
            this.View.DialogResult = false;
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