using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Common
{
    public class ApplicationContext
    {
        public USERSbo ApplicationUser { get; set; }
        public Window HostWindow { get; set; }
    }
}
