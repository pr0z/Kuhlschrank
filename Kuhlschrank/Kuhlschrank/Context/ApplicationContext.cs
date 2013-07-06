using DataContracts;
using Kuhlschrank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kuhlschrank.Context
{
    public class ApplicationContext
    {
        public User ApplicationUser { get; set; }
        public MainWindow HostWindow { get; set; }
    }
}
