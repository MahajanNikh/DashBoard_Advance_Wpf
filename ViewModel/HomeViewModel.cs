﻿
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using DashBoard_Advance.Model;

namespace DashBoard_Advance.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private CollectionViewSource HomeItemsCollection;
        public ICollectionView HomeSourceCollection => HomeItemsCollection.View;

        public HomeViewModel()
        {           
            ObservableCollection<HomeItems> homeItems = new ObservableCollection<HomeItems>
            {
                new HomeItems { HomeName = "This PC", HomeImage = @"Assets/pc_icon.png" },               
            };

            HomeItemsCollection = new CollectionViewSource { Source = homeItems };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

}