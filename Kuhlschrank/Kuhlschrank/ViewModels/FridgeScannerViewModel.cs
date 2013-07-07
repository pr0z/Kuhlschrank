using Kuhlschrank.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
using Kuhlschrank.ChildWindows.Views;

namespace Kuhlschrank.ViewModels
{
    public class FridgeScannerViewModel : INotifyPropertyChanged
    {
        #region PROPERTIES

        private bool _loadVisible;
        public bool LoadVisible
        {
            get { return _loadVisible; }
            set
            {
                if (_loadVisible != value)
                {
                    _loadVisible = value;
                    NotifyPropertyChanged("LoadVisible");
                }
            }
        }

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
        private DelegateCommand _stopCommand;
        public DelegateCommand StopCommand
        {
            get { return _stopCommand; }
            set
            {
                if (_stopCommand != value)
                {
                    _stopCommand = value;
                    NotifyPropertyChanged("StopCommand");
                }
            }

        }

        private DelegateCommand _startCommand;
        public DelegateCommand StartCommand
        {
            get { return _startCommand; }
            set
            {
                if (_startCommand != value)
                {
                    _startCommand = value;
                    NotifyPropertyChanged("StartCommand");
                }
            }

        }
        #endregion

        #region CTOR
        public FridgeScannerViewModel(ApplicationContext context)
        {
            this.StartCommand = new DelegateCommand(StartAction, canStart);
            this.StopCommand = new DelegateCommand(StopAction, canStop);
            this.Context = context;
            this.LoadVisible = false;
        }
        #endregion

        #region ACTIONS AND CANEXECUTES
        private bool canStart()
        {
            return !LoadVisible;
        }

        private void StartAction()
        {
            this.LoadVisible = true;
        }

        private bool canStop()
        {
            return LoadVisible;
        }

        private void StopAction()
        {
            this.LoadVisible = false;
            CWUnrecognizedProduct cw = new CWUnrecognizedProduct(this.Context, @"C:\Users\RLEI\Pictures\Products\2.png");
            cw.ShowDialog();
        }
            
        #endregion

        #region INotifyPropertyChanged MEMBERS
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if (this.StartCommand != null)
                this.StartCommand.RaiseCanExecuteChanged();

            if (this.StopCommand != null)
                this.StopCommand.RaiseCanExecuteChanged();
        }
        #endregion
    }
}
