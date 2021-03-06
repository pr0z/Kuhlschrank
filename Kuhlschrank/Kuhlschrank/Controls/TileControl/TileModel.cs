﻿using Common.Command;
using Common.Enums;
using Kuhlschrank.Context;
using Kuhlschrank.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Kuhlschrank.Controls
{
    public class TileModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _text;
        public string Text { get { return _text; } set { _text = value; OnPropertyChanged("Text"); } }

        private BitmapSource _image;
        public BitmapSource Image { get { return _image; } set { _image = value; OnPropertyChanged("Image"); } }

        private TileType _tileType;
        public TileType TileType { get { return _tileType; } set { _tileType = value; OnPropertyChanged("TileType"); } }

        private TileIdentity _identity;
        public TileIdentity Identity { get { return _identity; } set { _identity = value; OnPropertyChanged("Identity"); } }

        private ApplicationContext _context;
        public ApplicationContext Context { get { return _context; } set { _context = value; OnPropertyChanged("Context"); } }

        public ICommand ClickCommand { get; private set; }

        public TileModel(TileIdentity identity)
        {
            ClickCommand = new ActionCommand(Click);
            this.Identity = identity;
        }

        private void Click()
        {
            switch (this.Identity)
            {
                case TileIdentity.ScanContent:
                    {
                        FridgeScannerView scanner = new FridgeScannerView(this.Context);
                        this.Context.HostWindow.SetView(scanner);
                    }
                    break;
                case TileIdentity.ExploreContent:
                    {
                        BrowserView browser = new BrowserView(this.Context);
                        this.Context.HostWindow.SetView(browser);
                    }
                    break;
                case TileIdentity.Settings:
                    {
                        AccountManagementView account = new AccountManagementView(this.Context);
                        this.Context.HostWindow.SetView(account);
                    }
                    break;
                case TileIdentity.Recipes:
                    {
                        RecipesView recipe = new RecipesView(this.Context);
                        this.Context.HostWindow.SetView(recipe);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
