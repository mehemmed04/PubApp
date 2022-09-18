using PubApp.Models;
using PubApp.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp.ViewModels
{
    public class ProductHistoryViewModel:BaseViewModel
    {

        private List<BeerProduct> history;

        public List<BeerProduct> History
        {
            get { return history; }
            set { history = value;OnPropertyChanged(); }
        }

    }
}
