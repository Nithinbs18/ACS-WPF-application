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

namespace kitchenAndReadyOrders
{
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Orders> orders = new ObservableCollection<Orders>();
        public static ObservableCollection<Orders> readyOrders = new ObservableCollection<Orders>();
        public MainWindow()
        {
            InitializeComponent();
            removeMethod();
            Grd_kitchen.ItemsSource = orders;
            
        }

        private void removeMethod()
        {
            var orderItem = new ObservableCollection<Orders>();
            orders = orderItem;
            var menuFood = new ObservableCollection<Products>();
            for (int i = 1; i < 10; i++)
            {
                menuFood.Add(new Products { id = i, category = (i - 1) % 3, description = "decs" + i, name = "food" + i, price = i });
            }
            foreach (var item in menuFood)
            {
                orders.Add(new Orders { orderItem=item, quantity=2, details="detail", status=0 });
      
            }
        }

        private void Btn_status_Click(object sender, RoutedEventArgs e)
        {
            if ((Grd_kitchen.SelectedItem as Orders).status < 2)
            {
                (Grd_kitchen.SelectedItem as Orders).status++;
                if ((Grd_kitchen.SelectedItem as Orders).status == 2)
                {
                    if (!readyOrders.Contains((Grd_kitchen.SelectedItem as Orders)))
                    {
                        readyOrders.Add((Grd_kitchen.SelectedItem as Orders));
                        orders.Remove((Grd_kitchen.SelectedItem as Orders));
                    }
                }
                //Console.WriteLine((Grd_kitchen.SelectedItem as Orders).status);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ro = new Ready();
            ro.Show();
        }
    }
}
