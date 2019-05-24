using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace increment
{
    public class items : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public int _quantity;
        public int quantity
        { get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(new PropertyChangedEventArgs("quantity"));
            }
            }

    }
}