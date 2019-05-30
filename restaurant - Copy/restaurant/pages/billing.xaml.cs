using restaurant;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class billing
    {
        int orderTableNo;
        public static ObservableCollection<Orders> finalBillOrder = new ObservableCollection<Orders>();

        public billing()
        {
            InitializeComponent();
            Grd_billOrders.ItemsSource = finalBillOrder;
        }

        private void Cbx_tableNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tblNo = Cbx_tableNo.SelectedValue.ToString();
            Console.WriteLine(tblNo);

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
                default:
                    MessageBox.Show("Please a table!", "Error", MessageBoxButton.OK);
                    break;
            }
            finalBillOrder.Clear();
            foreach (Orders item in MainWindow.billOrder)
            {
                if (item.tableNo == this.orderTableNo)
                {
                    finalBillOrder.Add(item);
                }
            }
        }

    }
}

