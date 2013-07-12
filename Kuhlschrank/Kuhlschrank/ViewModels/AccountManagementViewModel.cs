using Kuhlschrank.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
using DataContracts;
using Common.Repositories.UserRepository;
using DataAccess.UserRepositoriesImplementation;
using Common.Repositories.DeviceRepository;
using DataAccess.DeviceRepositoriesImplementation;
using System.Collections.ObjectModel;
using Common.Extensions;

namespace Kuhlschrank.ViewModels
{
	public class AccountManagementViewModel : INotifyPropertyChanged
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

        private string _userFirstName;
        public string UserFirstName
        {
            get { return _userFirstName; }
            set
            {
                if (_userFirstName != value)
                {
                    _userFirstName = value;
                    NotifyPropertyChanged("UserFirstName");
                }
            }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    NotifyPropertyChanged("UserName");
                }
            }
        }

        private string _userMail;
        public string UserMail
        {
            get { return _userMail; }
            set
            {
                if (_userMail != value)
                {
                    _userMail = value;
                    NotifyPropertyChanged("UserMail");
                }
            }
        }

        private bool _fNameEnabled;
        public bool FNameEnabled
        {
            get { return _fNameEnabled; }
            set
            {
                if (_fNameEnabled != value)
                {
                    _fNameEnabled = value;
                    NotifyPropertyChanged("FNameEnabled");
                }
            }
        }

        private bool _nameEnabled;
        public bool NameEnabled
        {
            get { return _nameEnabled; }
            set
            {
                if (_nameEnabled != value)
                {
                    _nameEnabled = value;
                    NotifyPropertyChanged("NameEnabled");
                }
            }
        }

        private bool _mailEnabled;
        public bool MailEnabled
        {
            get { return _mailEnabled; }
            set
            {
                if (_mailEnabled != value)
                {
                    _mailEnabled = value;
                    NotifyPropertyChanged("MailEnabled");
                }
            }
        }

        private ObservableCollection<Device> _listDevices;
        public ObservableCollection<Device> ListDevices
        {
            get { return _listDevices; }
            set
            {
                if (_listDevices != value)
                {
                    _listDevices = value;
                    NotifyPropertyChanged("ListDevices");
                }
            }
        }

        private IUserRepository _userRepo;
        public IUserRepository UserRepo
        {
            get
            {
                return _userRepo ?? (_userRepo = new UserSqlServerRepository());
            }
        }

        private IDeviceRepository _deviceRepo;
        public IDeviceRepository DeviceRepo
        {
            get
            {
                return _deviceRepo ?? (_deviceRepo = new DeviceSqlServerRepository());
            }
        }
		#endregion

		#region COMMANDS
        private DelegateCommand _updateFirstNameCommand;
        public DelegateCommand UpdateFirstNameCommand
        {
            get { return _updateFirstNameCommand; }
            set
            {
                if (_updateFirstNameCommand != value)
                {
                    _updateFirstNameCommand = value;
                    NotifyPropertyChanged("UpdateFirstNameCommand");
                }
            }
        }

        private DelegateCommand _updateNameCommand;
        public DelegateCommand UpdateNameCommand
        {
            get { return _updateNameCommand; }
            set
            {
                if (_updateNameCommand != value)
                {
                    _updateNameCommand = value;
                    NotifyPropertyChanged("UpdateNameCommand");
                }
            }
        }

        private DelegateCommand _updateMailCommand;
        public DelegateCommand UpdateMailCommand
        {
            get { return _updateMailCommand; }
            set
            {
                if (_updateMailCommand != value)
                {
                    _updateMailCommand = value;
                    NotifyPropertyChanged("MailNameCommand");
                }
            }
        }

        
        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand
        {
            get { return _saveCommand; }
            set
            {
                if (_saveCommand != value)
                {
                    _saveCommand = value;
                    NotifyPropertyChanged("SaveCommand");
                }
            }
        }
        #endregion

		#region CTOR
        public AccountManagementViewModel(ApplicationContext context)
        {
            this.UpdateFirstNameCommand = new DelegateCommand(UpdateFirstNameAction, canUpdateFirstName);
            this.UpdateNameCommand = new DelegateCommand(UpdateNameAction, canUpdateName);
            this.UpdateMailCommand = new DelegateCommand(UpdateMailAction, canUpdateMail);
            this.SaveCommand = new DelegateCommand(SaveAction, canSave);
			this.Context = context;
            this.UserName = this.Context.ApplicationUser.Nom;
            this.UserFirstName = this.Context.ApplicationUser.Prenom;
            this.UserMail = this.Context.ApplicationUser.Mail;
            this.ListDevices = this.DeviceRepo.GetByUserId(this.Context.ApplicationUser.ID).ToObservableCollection();
            this.FNameEnabled = false;
            this.MailEnabled = false;
            this.NameEnabled = false;
            this.Context.HostWindow.PageTitle.Text = "Gérer votre compte";
        }
        #endregion

		#region ACTIONS AND CANEXECUTES
        private bool canUpdateFirstName()
        {
            return true;
        }

        private void UpdateFirstNameAction()
        {
            this.FNameEnabled = true;
        }

        private bool canUpdateName()
        {
            return true;
        }

        private void UpdateNameAction()
        {
            this.NameEnabled = true;
        }

        private bool canUpdateMail()
        {
            return true;
        }

        private void UpdateMailAction()
        {
            this.MailEnabled = true;
        }

        private bool canSave()
        {
            if (NameEnabled)
                return true;

            if (MailEnabled)
                return true;

            if (FNameEnabled)
                return true;

            return false;
        }

        private void SaveAction()
        {
            User user = new User();
            user.Mail = this.UserMail;
            user.Nom = this.UserName;
            user.Prenom = this.UserFirstName;
            user.ID = this.Context.ApplicationUser.ID;
            user.Password = this.Context.ApplicationUser.Password;
            UserRepo.Update(user);

            this.Context.ApplicationUser = user;
            this.Context.HostWindow.UserName = user.Nom.ToUpper();
            this.Context.HostWindow.FirstName = user.Prenom;
        }
		#endregion

		#region INotifyPropertyChanged MEMBERS
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if (this.SaveCommand != null)
                this.SaveCommand.RaiseCanExecuteChanged();
        }
        #endregion
	}
}