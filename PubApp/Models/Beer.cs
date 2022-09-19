using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PubApp.Models
{
    public class Beer:Entity,INotifyPropertyChanged,ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public double Price { get; set; }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
