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

        public static ObservableCollection<Products> food = new ObservableCollection<Products>();
        public static ObservableCollection<Products> drink = new ObservableCollection<Products>();
        public static ObservableCollection<Products> starters = new ObservableCollection<Products>();
        public static readyOrder readyPage = new readyOrder();
        public static Kitchen kit = new Kitchen();
        public static welcome welcome = new welcome();
        public static int orderNo = (int.Parse(DateTime.UtcNow.ToString("yyMMdd"))) * 1000;
        public MainWindow()
        {
            InitializeComponent();
            kit.Show();
            //kit.Owner = this;
            //Console.WriteLine(orderNo);
            var menuFood = new ObservableCollection<Products>();
            menuFood = DataStorageClass.ReadXml<ObservableCollection<Products>>("foodProducts.xml");
            foreach (var item in menuFood)
            {
                if (item.category == 4)
                {
                    MainWindow.drink.Add(item);
                }
                else if (item.category == 2 || item.category == 1 || item.category == 3)
                {
                    MainWindow.food.Add(item);
                }
                else if (item.category == 0)
                {
                    MainWindow.starters.Add(item);
                }
            }

            Frm_pageView.Content = welcome;
            Dpl_bill.Visibility = Visibility.Hidden;
            Dpl_new.Visibility = Visibility.Hidden;
            Dpl_ready.Visibility = Visibility.Hidden;
        }

        private void Btn_newOrder_Click(object sender, RoutedEventArgs e)
        {
            var newOrderPager = new newOrder();
            Frm_pageView.Content = newOrderPager;
            Dpl_bill.Visibility = Visibility.Hidden;
            Dpl_new.Visibility = Visibility.Visible;
            Dpl_ready.Visibility = Visibility.Hidden;
        }

        public void Btn_readyOrder_Click(object sender, RoutedEventArgs e)
        {
            Frm_pageView.Content = readyPage;
            Dpl_bill.Visibility = Visibility.Hidden;
            Dpl_new.Visibility = Visibility.Hidden;
            Dpl_ready.Visibility = Visibility.Visible;
        }

        private void Btn_billing_Click(object sender, RoutedEventArgs e)
        {
        billing billing = new billing();
        Frm_pageView.Content = billing;
            Dpl_bill.Visibility = Visibility.Visible;
            Dpl_new.Visibility = Visibility.Hidden;
            Dpl_ready.Visibility = Visibility.Hidden;
        }

        private void Btn_kitchen_Click(object sender, RoutedEventArgs e)
        {
            kit.Show();
        }

        private void Tbk_welcome_click(object sender, MouseButtonEventArgs e)
        {
            Frm_pageView.Content = welcome;
        }
    }
}
