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
    /// Interaction logic for Kitchen.xaml
    /// </summary>
    public partial class Kitchen : Window
    {
       
        public Kitchen()
        {
            InitializeComponent();
            //removeMethod();
            Grd_kitchen.ItemsSource = MainWindow.orders;
        }
        private void Btn_status_Click(object sender, RoutedEventArgs e)
        {
            if ((Grd_kitchen.SelectedItem as Orders).status < 2)
            {
                (Grd_kitchen.SelectedItem as Orders).status++;
                if ((Grd_kitchen.SelectedItem as Orders).status == 2)
                {
                    if (!MainWindow.readyOrders.Contains((Grd_kitchen.SelectedItem as Orders)))
                    {
                        MainWindow.readyOrders.Add((Grd_kitchen.SelectedItem as Orders));
                        MessageBox.Show("An order item is ready to be delivered","Alert",MessageBoxButton.OK);
                        
                        MainWindow.orders.Remove((Grd_kitchen.SelectedItem as Orders));
                    }
                }
                //Console.WriteLine((Grd_kitchen.SelectedItem as Orders).status);

            }

        }
    }
}
