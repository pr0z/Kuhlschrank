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

        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                if (_userPassword != value)
                {
                    _userPassword = value;
                    NotifyPropertyChanged("UserPassword");
                }
            }
        }

        private List<Device> _listDevices;
        public List<Device> ListDevices
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
        public AccountManagementViewModel(ApplicationContext context)
        {
            this.ClickCommand = new DelegateCommand(ClickAction, canClick);
			this.Context = context;
            this.UserName = this.Context.ApplicationUser.Nom;
            this.UserFirstName = this.Context.ApplicationUser.Prenom;
            this.UserMail = this.Context.ApplicationUser.Mail;
            this.UserPassword = this.Context.ApplicationUser.Password;
            //this.ListDevices = DeviceRepo.get
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