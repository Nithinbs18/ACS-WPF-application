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
        ObservableCollection<Orders> orders;
        newOrder newOrder;
        public int orderNum = 0;
        public MainWindow()
        {
            InitializeComponent();
            var orderItem = new ObservableCollection<Orders>();
            orders = orderItem;
            Grd_orders.ItemsSource = orders;
        }

        private void Btn_newOrder_Click(object sender, RoutedEventArgs e)
        {
            var newOrderPager = new newOrder();
            Frm_pageView.Content = newOrderPager;
            newOrder = newOrderPager;
        }

        private void Btn_readyOrder_Click(object sender, RoutedEventArgs e)
        {
            Frm_pageView.Content = new readyOrder();
        }

        private void Btn_billing_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_addItem_Click(object sender, RoutedEventArgs e)
        {
            bool contains = false;
            Products selectedItem = (Products)newOrder.Grd_Menu_Food.SelectedItem;
            if (selectedItem == null)
            {
                selectedItem = (Products)newOrder.Grd_Menu_Drink.SelectedItem;
            }
            newOrder.Grd_Menu_Food.UnselectAll();
            newOrder.Grd_Menu_Drink.UnselectAll();
            if (selectedItem == null)
            {
                MessageBox.Show("Please selet an item to be added!", "Error");
                return;
            }
            else
            {
                foreach (var item in orders)
                {
                    if (item.orderItem == selectedItem)
                    {
                        contains = true;
                        break;
                    }
                }

                if (contains)
                {
                    MessageBox.Show("Item already in order list", "Error");
                    return;
                }

                else
                {
                    Orders st = new Orders { orderItem = selectedItem, quantity = 1 };
                    orders.Add(st);
                }

            }
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            Orders st = (Orders)Grd_orders.SelectedItem;
            if (st == null)
            {
                MessageBox.Show("Please selet an odrer to be change!", "Error");
                return;
            }
            else
            {
                st.quantity++;
            }

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Orders st = (Orders)Grd_orders.SelectedItem;
            if (st == null)
            {
                MessageBox.Show("Please selet an odrer to be change!", "Error");
                return;
            }
            else
            {
                orders.Remove(st);
            }
        }

        private void Btn_sub_Click(object sender, RoutedEventArgs e)
        {
            Orders st = (Orders)Grd_orders.SelectedItem;
            if (st == null)
            {
                MessageBox.Show("Please selet an odrer to be change!", "Error");
                return;
            }
            else
            {
                if (st.quantity > 1)
                {
                    st.quantity--;
                }
            }

        }

    }
}
