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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Orders> orders = new ObservableCollection<Orders>();
        public static ObservableCollection<Orders> readyOrders = new ObservableCollection<Orders>();
        public static ObservableCollection<Orders> billOrder = new ObservableCollection<Orders>();
        public static ObservableCollection<TableNo> tableOrder = new ObservableCollection<TableNo>();
        public static ObservableCollection<Orders> finalBillOrder = new ObservableCollection<Orders>();

        public static ObservableCollection<Products> food;
        public static ObservableCollection<Products> drink;
        public static readyOrder readyPage = new readyOrder();
        public static Kitchen kit = new Kitchen();
        
        public static int orderNo = (int.Parse(DateTime.UtcNow.ToString("yyMMdd"))) * 1000;
        public MainWindow()
        {
            InitializeComponent();
            kit.Show();
            //kit.Owner = this;
            //Console.WriteLine(orderNo);
        }

        private void Btn_newOrder_Click(object sender, RoutedEventArgs e)
        {
            var newOrderPager = new newOrder();
            Frm_pageView.Content = newOrderPager;
        }

        public void Btn_readyOrder_Click(object sender, RoutedEventArgs e)
        {
            Frm_pageView.Content = readyPage;
        }

        private void Btn_billing_Click(object sender, RoutedEventArgs e)
        {
        billing billing = new billing();
        Frm_pageView.Content = billing;
        }

        private void Btn_kitchen_Click(object sender, RoutedEventArgs e)
        {
            kit.Show();
        }
    }
}
