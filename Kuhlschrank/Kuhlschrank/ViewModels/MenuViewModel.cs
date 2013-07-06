using Common.Enums;
using Kuhlschrank.Context;
using Kuhlschrank.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Common;
using Kuhlschrank.Views;

namespace Kuhlschrank.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        #region PROPERTIES
        private ApplicationContext _context;
        public ApplicationContext Context 
        {
            get { return _context; }
            set
            {
                if (_context != value)
                {
                    _context = value;
                    OnPropertyChanged("Context");
                }
            }
        }
        #endregion

        #region CTOR
        public MenuViewModel(ApplicationContext context)
        {
            this.Context = context;

            Tiles = new ObservableCollection<TileModel>()
            {
                new TileModel(TileIdentity.ExploreContent) { Text = "Explorer le contenu", TileType = TileType.Website, Context = this.Context },
                new TileModel(TileIdentity.ScanContent) { Text = "Scanner le contenu", TileType = TileType.Application, Context = this.Context },
                new TileModel(TileIdentity.Settings) { Text = "Réglages", TileType = TileType.Browser, Context = this.Context  },
            };
        }
        #endregion

        #region INotifyPropertyChanged MEMBERS
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<TileModel> _tiles;
        public ObservableCollection<TileModel> Tiles { get { return _tiles; } set { _tiles = value; OnPropertyChanged("Tiles"); } }
        #endregion

    }
}
