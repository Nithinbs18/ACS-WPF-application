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

namespace comboFilter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Orders> billOrder = new ObservableCollection<Orders>();
        public static ObservableCollection<Orders> tmpbillOrder;
        int orderTableNo;
        public MainWindow()
        {
            InitializeComponent();
            removemethod();
            Grd_billOrders.ItemsSource = billOrder;
        }

        private void removemethod()
        {
            var ddd = new ObservableCollection<Orders>();
            for (int i = 0; i < 4; i++)
            {
                ddd.Add(new Orders { name = i, price = i * 10, quantity = i });
            }
            tmpbillOrder = ddd;
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
            billOrder.Clear();
            foreach (Orders item in tmpbillOrder)
            {
                if (item.name == this.orderTableNo)
                {
                    billOrder.Add(item);
                }
            }
        }

        public class Orders
        {
            public int name { get; set; }
            public int quantity { get; set; }
            public int price { get; set; }
        }
    }
}
