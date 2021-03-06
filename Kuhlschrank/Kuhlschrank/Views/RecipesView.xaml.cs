﻿using Kuhlschrank.Context;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kuhlschrank.Views
{
    /// <summary>
    /// Interaction logic for RecipesView.xaml
    /// </summary>
    public partial class RecipesView : UserControl
    {
        private RecipesViewModel _viewModel { get; set; }

        public RecipesView(ApplicationContext context)
        {
            InitializeComponent();
            _viewModel = new RecipesViewModel(context);
            this.DataContext = _viewModel;
        }
    }
}
