using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;

using Common;
using DataAccess;
using DataContracts;
using Kuhlschrank.Views;
using Common.Repositories;
using Common.Repositories.UserRepository;
using DataAccess.UserRepositoriesImplementation;

namespace Kuhlschrank.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region PUBLIC PROPERTIES
        private string _identifiant { get; set; }
        public string Identifiant
        {
            get { return _identifiant; }
            set
            {
                if (_identifiant != value)
                {
                    _identifiant = value;
                    NotifyPropertyChanged("Identifiant");
                }
            }
        }

        private string _password { get; set; }
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    NotifyPropertyChanged("Password");
                }
            }
        }

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

        private IUserRepository _userRepo;
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepo ?? (_userRepo = new UserServiceRepository());
            }
        }
        #endregion

        #region CONSTRUCTOR
        public LoginViewModel(ApplicationContext context)
        {
            CheckUserPasswordCommand = new DelegateCommand(CheckUserPassword, CanCheckUserPassword);
            Context = context;
        }
        #endregion

        #region COMMANDS AND CANEXECUTES
        private DelegateCommand _checkUserPasswordCommand;
        public DelegateCommand CheckUserPasswordCommand
        {
            get { return _checkUserPasswordCommand; }
            set
            {
                if (_checkUserPasswordCommand != value)
                {
                    _checkUserPasswordCommand = value;
                    NotifyPropertyChanged("CheckUserPasswordCommand");
                }
            }
        }

        private bool CanCheckUserPassword()
        {
            return Identifiant != null && Password != null;
        }

        private void CheckUserPassword()
        {
            string message;
            User user = UserRepository.GetUserFromIdAndPassword(Identifiant, Password);
            if (user == null)
            {
                message = "L'utilisateur n'existe pas !";
                System.Windows.MessageBox.Show(message);
            }
            else if (user.Password != Password)
            {
                message = "Le couple utilisateur / mot de passe est incorrect";
                System.Windows.MessageBox.Show(message);
            }
            else
            {
                Context.ApplicationUser = user;
                MenuView menu = new MenuView();
                this.Context.HostWindow.Content = menu;
            }
        }

        #endregion

        #region INotifyPropertyChanged Implementation
        private void NotifyPropertyChanged(string propertyId)
        {
            CheckUserPasswordCommand.RaiseCanExecuteChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}