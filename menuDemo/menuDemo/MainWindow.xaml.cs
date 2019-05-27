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

namespace menuDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Products> food;
        ObservableCollection<Products> drink;
        ObservableCollection<Orders> orders;
        public int orderNum =0;


        public MainWindow()
        {
            InitializeComponent();
            var orderItem = new ObservableCollection<Orders>();
            orders = orderItem;
            Grd_orders.ItemsSource = orders;
            var menuFood = new ObservableCollection<Products>();
            for (int i = 1; i < 10; i++)
            {
                menuFood.Add(new Products { id = i, category = (i-1)%3, description = "decs" + i, name = "food" + i, price = i });
            }
            food = menuFood;

            var menuDrink = new ObservableCollection<Products>();
            for (int i = 1; i < 5; i++)
            {
                menuDrink.Add(new Products { id = i, category = (i - 1) % 3, description = "decs" + i, name = "drink" + i, price = i });
            }
            drink = menuDrink;
            Grd_Menu_Food.ItemsSource = food;
            Grd_Menu_Drink.ItemsSource = drink;
            
        }

        private void Btn_addItem_Click(object sender, RoutedEventArgs e)
        {
            bool contains = false;
            Products selectedItem = (Products)Grd_Menu_Food.SelectedItem;
            if (selectedItem == null)
            {
                selectedItem= (Products)Grd_Menu_Drink.SelectedItem;
            }
            Grd_Menu_Food.UnselectAll();
            Grd_Menu_Drink.UnselectAll();
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

        private void Btn_ad_Click(object sender, RoutedEventArgs e)
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
