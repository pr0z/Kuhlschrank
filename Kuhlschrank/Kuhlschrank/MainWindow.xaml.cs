using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Kuhlschrank.Views;
using Microsoft.Practices.Prism.Commands;
using Kuhlschrank.Context;

namespace Kuhlschrank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region PROPERTIES
        private ApplicationContext _context { get; set; }
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

        private UIElement _previousView;
        public UIElement PreviousView
        {
            get { return _previousView; }
            set
            {
                if (_previousView != value)
                {
                    _previousView = value;
                    NotifyPropertyChanged("PreviousView");
                }
            }
        }

        private UIElement _currentView;
        public UIElement CurrentView
        {
            get { return _currentView; }
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    NotifyPropertyChanged("CurrentView");
                }
            }
        }

        private string _previousType;
        public string PreviousType
        {
            get { return _previousType; }
            set
            {
                if (_previousType != value)
                {
                    _previousType = value;
                    NotifyPropertyChanged("PreviousType");
                }
            }
        }

        private bool _isLogged;
        public bool IsLogged
        {
            get { return _isLogged; }
            set
            {
                if (_isLogged != value)
                {
                    _isLogged = value;
                    NotifyPropertyChanged("IsLogged");
                }
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        #endregion

        #region CTOR
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Context = new ApplicationContext();
            Context.HostWindow = this;

            this.CloseCommand = new DelegateCommand(CloseApp, canClose);
            this.PreviousCommand = new DelegateCommand(LoadPrevious, canLoadPrevious);
            this.PreviousView = null;
            this.IsLogged = false;

            LoginView lv = new LoginView(Context);
            this.StackContent.Children.Add(lv);
        }
        #endregion

        #region PUBLIC METHODS
        public void SetView(UIElement view)
        {
            this.PreviousView = this.StackContent.Children[0];
            this.CurrentView = view;

            this.StackContent.Children.Clear();
            this.StackContent.Children.Add(view);
        }
        #endregion

        #region COMMANDS
        private DelegateCommand _closeCommand;
        public DelegateCommand CloseCommand
        {
            get { return _closeCommand; }
            set
            {
                if (_closeCommand != value)
                {
                    _closeCommand = value;
                    NotifyPropertyChanged("CloseCommand");
                }
            }
        }

        private DelegateCommand _previousCommand;
        public DelegateCommand PreviousCommand
        {
            get { return _previousCommand; }
            set
            {
                if (_previousCommand != value)
                {
                    _previousCommand = value;
                    NotifyPropertyChanged("PreviousCommand");
                }
            }
        }
        #endregion

        #region COMMANDS AND CANEXECUTE
        private bool canClose()
        {
            return true;
        }

        private void CloseApp()
        {
            System.Environment.Exit(0);
        }

        private bool canLoadPrevious()
        {
            return true;
        }

        private void LoadPrevious()
        {
            if (PreviousView != null)
            {
                this.StackContent.Children.Clear();
                this.StackContent.Children.Add(_previousView);
                this.PreviousView = null;
            }
        }
        #endregion

        #region INotifiyPropertyChanged MEMBERS
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));

            if (p == "PreviousView")
                if (this.PreviousView != null)
                    this.PreviousType = this.PreviousView.GetType().ToString();
        }
        #endregion
    }
}
