using Kuhlschrank.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
using Kuhlschrank.ChildWindows.Views;
using DataContracts;
using Business.ShapeDetectionEngine;
using Business.BarCodeAnalyser;
using Common.Repositories.ProductRepository;
using DataAccess.ProductRepositoriesImplementation;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using DataAccess.UserProductsRepositoriesImplementation;
using Common.Types;

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

        private Dictionary<string, string> _recognizedEan;
        public Dictionary<string, string> RecognizedEan
        {
            get { return _recognizedEan; }
            set
            {
                if (_recognizedEan != value)
                {
                    _recognizedEan = value;
                    NotifyPropertyChanged("RecognizedEan");
                }
            }
        }

        private List<Product> _recognizedProducts;
        public List<Product> RecognizedProducts
        {
            get { return _recognizedProducts; }
            set
            {
                if (_recognizedProducts != value)
                {
                    _recognizedProducts = value;
                    NotifyPropertyChanged("RecognizedProducts");
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
        private IUserProductsRepository _userProductsRepo;
        public IUserProductsRepository UserProductsRepo
        {
            get
            {
                return _userProductsRepo ?? (_userProductsRepo = new UserProductsSqlServerRepository());
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
            this.RecognizedProducts = new List<Product>();
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
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BarCodeAnalyser eanAnalyser = new BarCodeAnalyser();
            this.RecognizedEan = eanAnalyser.Analyse();
            ProcessEans();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            AnalyzeContent();
        }

        private bool canStop()
        {
            return LoadVisible;
        }

        private void StopAction()
        {
            this.LoadVisible = false;
        }
            
        #endregion

        #region PRIVATE METHODS
        private void SaveProducts()
        {
            foreach (var prod in this.HandleDoublons())
            {
                UserProducts entity = new UserProducts();
                entity.IdProduct = prod.First.ID;
                entity.IdUser = this.Context.ApplicationUser.ID;
                entity.Quantity = prod.Second;

                UserProductsRepo.Insert(entity);
            }
        }

        private List<Pair<Product, int>> HandleDoublons()
        {
            List<Pair<Product, int>> result = new List<Pair<Product, int>>();

            foreach (Product prod in this.RecognizedProducts)
                result.Add(new Pair<Product, int>(prod, 0));

            foreach (Product prod in this.RecognizedProducts)
                result.Where(o => o.First.ID == prod.ID).FirstOrDefault().Second++;

            return result;
        }

        private void ProcessEans()
        {
            foreach (KeyValuePair<string, string> product in this.RecognizedEan)
            {
                Product entity = null;
                if (!string.IsNullOrEmpty(product.Value))
                    entity = ProductRepo.GetByEan13(product.Value);

                if (entity == null)
                {
                    CWUnrecognizedProduct cw = new CWUnrecognizedProduct(this.Context, product.Key, product.Value);
                    if (cw.ShowDialog().HasValue && cw.DialogResult.Value)
                        entity = cw.GetProduct();
                }

                this.RecognizedProducts.Add(entity);
            }

            //this.SaveProducts();
            this.LoadVisible = false;
            this.ValidateScan();
        }

        private void AnalyzeContent()
        {
            ShapeDetectionEngine shapeEngine = new ShapeDetectionEngine();
            shapeEngine.ProcessImage();
        }

        private void ValidateScan()
        {
            CWValidateScanView cw = new CWValidateScanView(this.Context);
            if (cw.ShowDialog().HasValue && cw.DialogResult.Value)
                return;
            else
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += worker_DoWork;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.RunWorkerAsync();
            }

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

            if (propertyName == "RecognizedEan")
                this.ProcessEans();
        }
        #endregion
    }
}
