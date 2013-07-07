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
using Kuhlschrank.ViewModels;
using Kuhlschrank.Context;

namespace Kuhlschrank.Views
{
    /// <summary>
    /// Interaction logic for FridgeScannerView.xaml
    /// </summary>
    public partial class FridgeScannerView : UserControl
    {
        public FridgeScannerViewModel _viewModel { get; set; }
        public FridgeScannerView(ApplicationContext context)
        {
            InitializeComponent();
            _viewModel = new FridgeScannerViewModel(context);
            this.DataContext = _viewModel;
        }
    }
}
