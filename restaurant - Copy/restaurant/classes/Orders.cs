using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant
{
    public class Orders : INotifyPropertyChanged
    {
        public int _orderNo;
        public int orderNo
        {
            get { return _orderNo; }
            set
            {
                _orderNo = value;
                OnPropertyChanged(new PropertyChangedEventArgs("orderNo"));
            }
        }
        public int tableNo { get; set; }
        
        public Products orderItem { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        public string _details;
        public string details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertyChanged(new PropertyChangedEventArgs("details"));
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
        public int status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(new PropertyChangedEventArgs("status"));
            }
        }

    }
}
