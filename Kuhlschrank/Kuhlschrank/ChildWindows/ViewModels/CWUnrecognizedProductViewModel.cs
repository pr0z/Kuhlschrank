using Kuhlschrank.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;
using DataContracts;
using Common.Repositories.ProductRepository;
using DataAccess.ProductRepositoriesImplementation;
using Microsoft.Practices.Prism.Commands;
using System.Windows;

namespace Kuhlschrank.ChildWindows.ViewModels
{
    public class CWUnrecognizedProductViewModel : INotifyPropertyChanged
    {
        #region PROPERTIES
        private BitmapImage _imageSource;
        public BitmapImage ImageSource
        {
            get { return _imageSource; }
            set 
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    NotifyPropertyChanged("ImageSource");
                }
            }
        }

        private List<Product> _allProducts;
        public List<Product> AllProducts
        {
            get { return _allProducts; }
            set
            {
                if (_allProducts != value)
                {
                    _allProducts = value;
                    NotifyPropertyChanged("AllProducts");
                }
            }
        }

        private IProductRepository _productRepo;
        public IProductRepository ProductRepo
        {
            get
            {
                return _productRepo ?? (_productRepo = new ProductSqlServerRepository());
            }
        }

        private string _filter;
        public string Filter
        {
            get { return _filter; }
            set
            {
                if (_filter != value)
                {
                    _filter = value;
                    NotifyPropertyChanged("Filter");
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
        private DelegateCommand _filterCommand;
        public DelegateCommand FilterCommand
        {
            get { return _filterCommand; }
            set
            {
                if (_filterCommand != value)
                {
                    _filterCommand = value;
                    NotifyPropertyChanged("FilterCommand");
                }
            }
        }

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
        #endregion

        public CWUnrecognizedProductViewModel(ApplicationContext context, string fileName, Window view)
        {
            ImageSource = new BitmapImage();
            ImageSource.BeginInit();
            ImageSource.UriSource = new Uri(fileName);
            ImageSource.EndInit();

            this.FilterCommand = new DelegateCommand(FilterAction, canFilter);
            this.CloseCommand = new DelegateCommand(CloseAction);

            this.View = view;
            this.AllProducts = ProductRepo.GetAll();
        }

        #region ACTIONS AND CANEXECUTES
        private bool canFilter()
        {
            return !String.IsNullOrEmpty(Filter);
        }

        private void FilterAction()
        {
            this.AllProducts = this.AllProducts.Where(o => o.Libelle.ToLower().Contains(this.Filter)).ToList();
        }

        private void CloseAction()
        {
            this.View.Close();
        }
        #endregion

        #region INotifyPropertyChanged MEMBERS
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if (this.FilterCommand != null)
                this.FilterCommand.RaiseCanExecuteChanged();
        }
        #endregion
    }
}
