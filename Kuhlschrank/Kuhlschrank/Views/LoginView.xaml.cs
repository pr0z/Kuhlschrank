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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private LoginViewModel viewModel { get; set; }

        public LoginView(ApplicationContext context)
        {
            InitializeComponent();
            viewModel = new LoginViewModel(context);
            this.DataContext = viewModel;
        }
    }
}
