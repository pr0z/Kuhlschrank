using DataContracts;
using Kuhlschrank.ChildWindows.ViewModels;
using Kuhlschrank.Context;
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
using System.Windows.Shapes;

namespace Kuhlschrank.ChildWindows.Views
{
    /// <summary>
    /// Interaction logic for CWUnrecognizedProduct.xaml
    /// </summary>
    public partial class CWUnrecognizedProduct : Window
    {
        private CWUnrecognizedProductViewModel _viewModel;

        public CWUnrecognizedProduct(ApplicationContext context, string fileName, string ean13)
        {
            InitializeComponent();
            _viewModel = new CWUnrecognizedProductViewModel(context, fileName, this, ean13);
            this.DataContext = _viewModel;
        }

        public Product GetProduct()
        {
            return _viewModel.GetProduct();
        }
    }
}
