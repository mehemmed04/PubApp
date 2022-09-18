using PubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp.Repostories
{
    public class ProductHistory
    {
        public List<BeerProduct> History { get; set; }=new List<BeerProduct> ();
    }
}
