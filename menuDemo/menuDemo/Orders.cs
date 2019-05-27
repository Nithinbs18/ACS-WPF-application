using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menuDemo
{
    public class Orders : INotifyPropertyChanged
    {
        //public int orderID { get; set; }
        public Products orderItem { get; set; }
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
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(new PropertyChangedEventArgs("quantity"));
            }
        }

    }
}
