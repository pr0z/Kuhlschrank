using Common;
using Common.Repositories.CategoryRepository;
using Common.Extensions;
using DataAccess.CategoryRepositoriesImplementation;
using DataContracts;
using Kuhlschrank.Context;
using Kuhlschrank.Views;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Common.Types;
using Common.Repositories.ProductRepository;
using DataAccess.ProductRepositoriesImplementation;
using DataAccess.UserProductsRepositoriesImplementation;

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

        private ObservableCollection<Pair<bool, Category>> _listCategory;
        public ObservableCollection<Pair<bool, Category>> ListCategory
        {
            get { return _listCategory; }
            set
            {
                if (_listCategory != value)
                {
                    _listCategory = value;
                    NotifyPropertyChanged("Context");
                }
            }
        }

        private ObservableCollection<Pair<bool, Category>> _copy;
        public ObservableCollection<Pair<bool, Category>> Copy
        {
            get { return _copy; }
            set
            {
                if (_copy != value)
                {
                    if (value != null)
                    {
                        _copy = value;
                        NotifyPropertyChanged("Copy");
                    }
                }
            }
        }

        private ObservableCollection<UserProducts> _allUserProducts;
        public ObservableCollection<UserProducts> AllUserProducts
        {
            get { return _allUserProducts; }
            set
            {
                if (_allUserProducts != value)
                {
                    _allUserProducts = value;
                    NotifyPropertyChanged("AllUserProducts");
                }
            }
        }

        private ObservableCollection<Product> _allProducts;
        public ObservableCollection<Product> AllProducts
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

        private ObservableCollection<Product> _listDrinks;
        public ObservableCollection<Product> ListDrinks
        {
            get { return _listDrinks; }
            set
            {
                if (_listDrinks != value)
                {
                    _listDrinks = value;
                    NotifyPropertyChanged("ListDrinks");
                }
            }
        }

        private ObservableCollection<Product> _listMilkProducts;
        public ObservableCollection<Product> ListMilkProducts
        {
            get { return _listMilkProducts; }
            set
            {
                if (_listMilkProducts != value)
                {
                    _listMilkProducts = value;
                    NotifyPropertyChanged("ListMilkProducts");
                }
            }
        }

        private ObservableCollection<Product> _listVegetables;
        public ObservableCollection<Product> ListVegetables
        {
            get { return _listVegetables; }
            set
            {
                if (_listVegetables != value)
                {
                    _listVegetables = value;
                    NotifyPropertyChanged("ListVegetables");
                }
            }
        }

        private ObservableCollection<Product> _listMeats;
        public ObservableCollection<Product> ListMeats
        {
            get { return _listMeats; }
            set
            {
                if (_listMeats != value)
                {
                    _listMeats = value;
                    NotifyPropertyChanged("ListMeats");
                }
            }
        }

        private Pair<bool, Category> _selectedItem;
        public Pair<bool, Category> SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    if (value != null)
                    {
                        _selectedItem = value;
                        NotifyPropertyChanged("SelectedItem");
                    }
                }
            }
        }

        private bool _milkEnabled;
        public bool MilkEnabled
        {
            get { return _milkEnabled; }
            set
            {
                if (_milkEnabled != value)
                {
                    _milkEnabled = value;
                    NotifyPropertyChanged("MilkEnabled");
                }
            }
        }

        private bool _drinkEnabled;
        public bool DrinkEnabled
        {
            get { return _drinkEnabled; }
            set
            {
                if (_drinkEnabled != value)
                {
                    _drinkEnabled = value;
                    NotifyPropertyChanged("DrinkEnabled");
                }
            }
        }

        private bool _vegetableEnabled;
        public bool VegetableEnabled
        {
            get { return _vegetableEnabled; }
            set
            {
                if (_vegetableEnabled != value)
                {
                    _vegetableEnabled = value;
                    NotifyPropertyChanged("VegetableEnabled");
                }
            }
        }

        private bool _meatEnabled;
        public bool MeatEnabled
        {
            get { return _meatEnabled; }
            set
            {
                if (_meatEnabled != value)
                {
                    _meatEnabled = value;
                    NotifyPropertyChanged("MeatEnabled");
                }
            }
        }

        private ICategoryRepository _categRepo;
        public ICategoryRepository CategRepo
        {
            get
            {
                return _categRepo ?? (_categRepo = new CategoryServiceRepository());
            }
        }

        private IProductRepository _productRepo;
        public IProductRepository ProductRepo
        {
            get
            {
                return _productRepo ?? (_productRepo = new ProductServiceRepository());
            }
        }

        private IUserProductsRepository _userProductsRepo;
        public IUserProductsRepository UserProductsRepo
        {
            get
            {
                return _userProductsRepo ?? (_userProductsRepo = new UserProductsServiceRepository());
            }
        }
        #endregion

        #region CTOR
        public BrowserViewModel(ApplicationContext context)
        {
            this.Context = context;
            this.ListCategory = CategRepo.GetAll().Select(o => new Pair<bool, Category>(false, o)).ToList().ToObservableCollection();
            this.AllUserProducts = UserProductsRepo.GetByUserId(context.ApplicationUser.ID).ToObservableCollection();
            this.MapProducts();
            this.Copy = new ObservableCollection<Pair<bool, Category>>();

            this.Context.HostWindow.PageTitle.Text = "Explorer le contenu de votre réfrigérateur";
            this.SelectedItem = this.ListCategory.First();
        }
        #endregion

        #region PRIVATE METHODS
        private void MapProducts()
        {
            this.AllProducts = new ObservableCollection<Product>();
            foreach (var product in AllUserProducts)
                this.AllProducts.Add(ProductRepo.GetById(product.IdProduct));

            this.ListDrinks = this.AllProducts.Where(o => o.IdCategory == 1).ToList().ToObservableCollection();
            this.ListMilkProducts = this.AllProducts.Where(o => o.IdCategory == 2).ToList().ToObservableCollection();
            this.ListVegetables = this.AllProducts.Where(o => o.IdCategory == 3).ToList().ToObservableCollection();
            this.ListMeats = this.AllProducts.Where(o => o.IdCategory == 4).ToList().ToObservableCollection();
        }
        #endregion

        #region INotifyPropertyChanged MEMBERS
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyId)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyId));

            if (propertyId == "SelectedItem")
            {
                SelectedItem.First = true;
                foreach (var item in this.ListCategory.Where(o => o.Second.ID != SelectedItem.Second.ID))
                    item.First = false;

                if (this.ListCategory.Count != 0)
                {
                    if (this.Copy.Count == 0)
                        foreach (var item in this.ListCategory)
                            this.Copy.Add(item);

                    if (this.Copy.Count != 0)
                        this.ListCategory.Clear();

                    if (this.ListCategory.Count == 0)
                        foreach (var item in this.Copy)
                            this.ListCategory.Add(item);
                }

                if (SelectedItem.Second.ID == 1)
                    DrinkEnabled = true;
                else
                    DrinkEnabled = false;

                if (SelectedItem.Second.ID == 2)
                    MilkEnabled = true;
                else
                    MilkEnabled = false;

                if (SelectedItem.Second.ID == 3)
                    VegetableEnabled = true;
                else
                    VegetableEnabled = false;

                if (SelectedItem.Second.ID == 4)
                    MeatEnabled = true;
                else
                    MeatEnabled = false;
            }
        }
        #endregion
    }
}
