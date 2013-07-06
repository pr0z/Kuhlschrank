using Common;
using Kuhlschrank.Context;
using Kuhlschrank.ViewModels;
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

namespace Kuhlschrank.Views
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        private MenuViewModel viewModel { get; set; }

        public MenuView(ApplicationContext context)
        {
            InitializeComponent();
            viewModel = new MenuViewModel(context);
            this.DataContext = viewModel;
        }
    }
}
