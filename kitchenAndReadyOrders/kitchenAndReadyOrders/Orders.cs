using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kitchenAndReadyOrders
{
    public class Orders : INotifyPropertyChanged
    {
        
        public string details { get; set; }
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
        public int _status;
       public int status {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(new PropertyChangedEventArgs("status"));
            }
        }

    }
}
