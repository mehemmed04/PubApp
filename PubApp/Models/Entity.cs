using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp.Models
{
    public class Entity
    {
        public int Id { get; set; } = ++id;
        public static int id { get; set; } = 0;
    }
}
