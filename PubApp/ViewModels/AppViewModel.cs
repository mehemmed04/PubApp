using PubApp.Commands;
using PubApp.Models;
using PubApp.Repostories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        public FakeRepo BeerRepostery { get; set; }
        public ObservableCollection<Beer> Beers { get; set; }


        public RelayCommand BuyCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand ShowHistoryCommand { get; set; }
        public RelayCommand CountUpCommand { get; set; }
        public RelayCommand CountDownCommand { get; set; }
        public RelayCommand SelectedCommand { get; set; }
        private Beer beer;

        public  Beer Beer
        {
            get { return beer; }
            set { beer = value; OnPropertyChanged(); }
        }

        public AppViewModel()
        {
            BeerRepostery = new FakeRepo();
            Beers = new ObservableCollection<Beer>(BeerRepostery.GetAll());
            SelectedCommand = new RelayCommand(o =>
                {
                    var beer = o as Beer;
                    Beer = beer;
            });

        }


    }
}
