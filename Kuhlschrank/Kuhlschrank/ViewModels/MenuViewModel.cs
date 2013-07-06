using Common.Enums;
using Common.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuhlschrank.ViewModels
{
    public class MenuViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<TileModel> _tiles;
        public ObservableCollection<TileModel> Tiles { get { return _tiles; } set { _tiles = value; OnPropertyChanged("Tiles"); } }

        public MenuViewModel()
        {
            Tiles = new ObservableCollection<TileModel>()
            {
                new TileModel(TileIdentity.ExploreContent) { Text = "Explorer le contenu", TileType = TileType.Website },
                new TileModel(TileIdentity.ScanContent) { Text = "Scanner le contenu", TileType = TileType.Application },
                new TileModel(TileIdentity.Settings) { Text = "Réglages", TileType = TileType.Browser  },
            };
        }
    }
}
