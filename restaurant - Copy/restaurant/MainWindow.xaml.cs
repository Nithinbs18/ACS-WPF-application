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
        public static ObservableCollection<Products> food;
        public static ObservableCollection<Products> drink;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_newOrder_Click(object sender, RoutedEventArgs e)
        {
            var newOrderPager = new newOrder();
            Frm_pageView.Content = newOrderPager;
        }

        private void Btn_readyOrder_Click(object sender, RoutedEventArgs e)
        {
            Frm_pageView.Content = new readyOrder();
        }

        private void Btn_billing_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_kitchen_Click(object sender, RoutedEventArgs e)
        {
            var kit = new Kitchen();
            kit.Show();
        }
    }
}
