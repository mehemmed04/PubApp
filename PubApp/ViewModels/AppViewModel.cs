using PubApp.Commands;
using PubApp.Models;
using PubApp.Repostories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PubApp.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        public FakeRepo BeerRepostery { get; set; }
        public ObservableCollection<Beer> Beers { get; set; }

        public PubApp.Repostories.ProductHistory ProductHistory { get; set; } = new PubApp.Repostories.ProductHistory();
        public RelayCommand BuyCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand ShowHistoryCommand { get; set; }
        public RelayCommand CountUpCommand { get; set; }
        public RelayCommand CountDownCommand { get; set; }
        public RelayCommand SelectedCommand { get; set; }

        private Beer beer;

        public Beer Beer
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


            CountUpCommand = new RelayCommand((o) =>
            {
                Beer.Count++;
            }, (o) =>
            {
                return Beer != null;
            });

            CountDownCommand = new RelayCommand((o) =>
            {
                if (Beer != null)
                {
                    Beer.Count--;
                }

            }, (o) =>
            {
                if (Beer != null)
                {
                    return Beer.Count > 1;
                }
                return false;
            });


            BuyCommand = new RelayCommand((o) =>
            {
                BeerProduct bp = new BeerProduct
                {
                    Beer = (Beer)Beer.Clone(),
                    DateTime = DateTime.Now
                };
                ProductHistory.History.Add(bp);

                FileHelper.GeneratePDF(Beer);
                Beer.Count = 1;
                MessageBox.Show("Bought");
                Beer = null;
            }, (o) =>
            {
                return Beer != null;
            });


            ResetCommand = new RelayCommand((o) =>
            {
                Beer.Count = 1;
                Beer = null;
            }, (o) =>
            {
                return Beer != null;
            });

            ShowHistoryCommand = new RelayCommand((o) =>
            {
                ProductHistoryViewModel historyViewModel = new ProductHistoryViewModel();
                historyViewModel.History = ProductHistory.History;

                PubApp.Views.ProductHistory ph = new PubApp.Views.ProductHistory();
                ph.DataContext= historyViewModel;

                ph.ShowDialog();

            });

        }


    }
}
