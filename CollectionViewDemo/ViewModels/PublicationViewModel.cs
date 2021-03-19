using System;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Essentials;

using CollectionViewDemo.Models;
using CollectionViewDemo.Helpers;
using CollectionViewDemo.Services;
using System.Linq;

namespace CollectionViewDemo.ViewModels
{
    public class PublicationViewModel : BaseViewModel
    {
        private ObservableCollection<Publication> _publications;

        public ObservableCollection<Publication> Publications
        {
            get => _publications;
            set
            {
                _publications = value;
                OnPropertyChanged();
            }
        }

        private Publication _currentPublication;

        public Publication CurrentPublication
        {
            get => _currentPublication;
            set
            {
                _currentPublication = value;
                OnPropertyChanged();
            }
        }


        public PublicationViewModel()
        {
            Task.Run(async () => await LoadPublications());
        }

        async Task LoadPublications()
        {
            var data = await DataService<Publication>.GetData();

            foreach (var item in data)
                item.Colors = ColorPalette.GetNextColorValues();

            Publications = new ObservableCollection<Publication>(data.Take(10));
        }
    }
}
