using restaurant;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace restaurant
{
    /// <summary>
    /// Interaction logic for billing.xaml
    /// </summary>
    public partial class billing : INotifyPropertyChanged
    {
        int orderTableNo = 0;
        int TableOrderNo;
        float sum;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        public String _forOrderno;
        public String forOrderno
        {
            get { return _forOrderno; }
            set
            {
                _forOrderno = value;
                OnPropertyChanged(new PropertyChangedEventArgs("forOrderno"));
            }
        }

        public billing()
        {
            InitializeComponent();
            Grd_billOrders.ItemsSource = MainWindow.finalBillOrder;
            //Tbk_orderno.Text = this.forOrderno;
        }

        private void Cbx_tableNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tblNo = Cbx_tableNo.SelectedValue.ToString();
            //Console.WriteLine(tblNo);
            switch (tblNo)
            {
                case "System.Windows.Controls.ComboBoxItem: Table no. 1":
                    this.orderTableNo = 1;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Table no. 2":
                    this.orderTableNo = 2;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Table no. 3":
                    this.orderTableNo = 3;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Table no. 4":
                    this.orderTableNo = 4;
                    break;
            }
            MainWindow.finalBillOrder.Clear();
            var tot = 0;
            foreach (TableNo item in MainWindow.tableOrder)
            {
                if (item.tableNo == this.orderTableNo && !item.orderClosed)
                {
                    this.TableOrderNo = item.tableOrderNo;
                    Console.WriteLine(this.TableOrderNo);
                    Tbk_orderno.Text = item.tableOrderNo.ToString();
                }
            }
            foreach (Orders order in MainWindow.billOrder)
            {
                if (order.orderNo == this.TableOrderNo)
                {
                    MainWindow.finalBillOrder.Add(order);
                    Tbk_orderno.Text = order.orderNo.ToString();
                    var q = order.quantity;
                    var p = order.orderItem.price;
                    tot += q * p;
                }
                this.sum = tot;
                Tbx_sum.Text = this.sum.ToString();
                if (MainWindow.finalBillOrder.Count == 0)
                {
                    Tbk_orderno.Text = "";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.orderTableNo == 0)
            {
                MessageBox.Show("Please select a Table to close the order!", "Error", MessageBoxButton.OK);
            }
            else
            {
                foreach (var table in MainWindow.tableOrder)
                {
                    if (table.tableNo == this.orderTableNo)
                    {
                        table.orderClosed = true;
                        MessageBox.Show("Order close sucessfully.","Closed", MessageBoxButton.OK);
                        MainWindow.tableOrder.Remove(table);
                        MainWindow.finalBillOrder.Clear();
                        break;
                    }
                }
            }

        }
    }
}

