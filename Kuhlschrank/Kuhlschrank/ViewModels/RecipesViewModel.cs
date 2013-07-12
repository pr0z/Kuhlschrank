using Common.Repositories.ProductRepository;
using Common.Repositories.RecetteRepository;
using DataAccess.ProductRepositoriesImplementation;
using DataAccess.RecetteRepositoriesImplementation;
using DataAccess.UserProductsRepositoriesImplementation;
using DataContracts;
using Kuhlschrank.Context;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuhlschrank.ViewModels
{
    public class RecipesViewModel
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

        private List<Recette> _listRecettes;
        public List<Recette> ListRecettes
        {
            get { return _listRecettes; }
            set
            {
                if (_listRecettes != value)
                {
                    _listRecettes = value;
                    NotifyPropertyChanged("ListRecettes");
                }
            }
        }

        private List<UserProducts> _userProducts;
        public List<UserProducts> UserProducts
        {
            get { return _userProducts; }
            set
            {
                if (_userProducts != value)
                {
                    _userProducts = value;
                    NotifyPropertyChanged("UserProducts");
                }
            }
        }

        private List<Product> _listProducts;
        public List<Product> ListProducts
        {
            get { return _listProducts; }
            set
            {
                if (_listProducts != value)
                {
                    _listProducts = value;
                    NotifyPropertyChanged("ListProducts");
                }
            }
        }

        private IRecetteRepository _recetteRepo;
        public IRecetteRepository RecetteRepo
        {
            get
            {
                return _recetteRepo ?? (_recetteRepo = new RecetteServiceRepository());
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
        public RecipesViewModel(ApplicationContext context)
        {
            this.ClickCommand = new DelegateCommand(ClickAction, canClick);
            this.Context = context;
            this.UserProducts = UserProductsRepo.GetByUserId(this.Context.ApplicationUser.ID);
            this.ListProducts = new List<Product>();
            foreach (var product in this.UserProducts)
                this.ListProducts.Add(ProductRepo.GetById(product.IdProduct));

            this.ListRecettes = RecetteRepo.GetRecetteFromProducts(this.ListProducts);
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
