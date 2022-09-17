using PubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp.Repostories
{
    public class FakeRepo
    {
        public List<Beer> GetAll()
        {
            return new List<Beer>
            {
                new Beer{ Count = 1, Name="Tuborg", Price=12.34, Volume=0.35, ImagePath="/Images/Tuborg.jpg" },
                new Beer{ Count = 1, Name="Corona", Price=8.12, Volume=0.5, ImagePath="/Images/Corona.jpg" },
                new Beer{ Count = 1, Name="Bira", Price=7.48, Volume=0.4, ImagePath="/Images/Bira.png" },
            };
        }


    }
}
