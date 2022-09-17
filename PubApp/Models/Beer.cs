﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp.Models
{
    public class Beer:Entity
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
