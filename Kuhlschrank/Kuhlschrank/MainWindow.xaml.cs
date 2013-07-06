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
using Common;
using System.ComponentModel;
using Kuhlschrank.Views;

namespace Kuhlschrank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ApplicationContext _context { get; set; }
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

        private void NotifyPropertyChanged(string p)
        {
        }

        public MainWindow()
        {
            InitializeComponent();
            Context = new ApplicationContext();
            Context.HostWindow = this;
            LoginView lv = new LoginView(Context);
            this.SetContent(lv);
        }

        public void SetContent(UserControl uc)
        {
            this.Content = uc;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
