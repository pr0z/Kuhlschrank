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

        private Product _selectedItem;
        public Product SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    NotifyPropertyChanged("SelectedItem");
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

        private string _eanCode;
        public string EanCode
        {
            get { return _eanCode; }
            set
            {
                if (_eanCode != value)
                {
                    _eanCode = value;
                    NotifyPropertyChanged("EanCode");
                }
            }
        }

        private string _libelle;
        public string Libelle
        {
            get { return _libelle; }
            set
            {
                if (_libelle != value)
                {
                    _libelle = value;
                    NotifyPropertyChanged("Libelle");
                }
            }
        }

        private int _idCategory;
        public int IdCategory
        {
            get { return _idCategory; }
            set
            {
                if (_idCategory != value)
                {
                    _idCategory = value;
                    NotifyPropertyChanged("IdCategory");
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

        private Product _productToAdd;
        public Product ProductToAdd
        {
            get { return _productToAdd; }
            set
            {
                if (_productToAdd != value)
                {
                    _productToAdd = value;
                    NotifyPropertyChanged("ProductToAdd");
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
        #endregion

        #region CTOR
        public CWUnrecognizedProductViewModel(ApplicationContext context, string fileName, Window view, string ean13)
        {
            ImageSource = new BitmapImage();
            ImageSource.BeginInit();
            ImageSource.UriSource = new Uri(fileName);
            ImageSource.EndInit();

            this.FilterCommand = new DelegateCommand(FilterAction, canFilter);
            this.CloseCommand = new DelegateCommand(CloseAction);
            this.ValidateCommand = new DelegateCommand(ValidateAction, canValidate);

            this.View = view;
            this.AllProducts = ProductRepo.GetAll().OrderBy(o => o.Libelle).ToList();
            this.EanCode = ean13;
        }
        #endregion

        #region ACTIONS AND CANEXECUTES
        private bool canFilter()
        {
            return !String.IsNullOrEmpty(Filter);
        }

        private void FilterAction()
        {
            this.AllProducts = this.AllProducts.Where(o => o.Libelle.ToLower().Contains(this.Filter)).OrderBy(o => o.Libelle).ToList();
        }

        private void CloseAction()
        {
            this.View.Close();
            this.View.DialogResult = false;
        }

        private bool canValidate()
        {
            return (this.SelectedItem != null) || (!String.IsNullOrEmpty(this.EanCode) && !String.IsNullOrEmpty(this.Libelle) && this.IdCategory != 0);
        }

        private void ValidateAction()
        {
            if (!String.IsNullOrEmpty(this.EanCode) && !String.IsNullOrEmpty(this.Libelle) && this.IdCategory != 0)
            {
                this.ProductToAdd = new Product();
                this.ProductToAdd.IdCategory = this.IdCategory;
                this.ProductToAdd.Libelle = this.Libelle;
                this.ProductToAdd.Code = this.EanCode;

                ProductRepo.Insert(this.ProductToAdd);
                this.View.DialogResult = true;
            }

            if (SelectedItem != null)
            {
                this.ProductToAdd = SelectedItem;
                this.View.DialogResult = true;
            }
        }

        public Product GetProduct()
        {
            return this.ProductToAdd;
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

            if (this.ValidateCommand != null)
                this.ValidateCommand.RaiseCanExecuteChanged();
        }
        #endregion
    }
}
