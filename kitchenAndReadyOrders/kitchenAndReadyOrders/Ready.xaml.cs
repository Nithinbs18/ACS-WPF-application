using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace kitchenAndReadyOrders
{
    /// <summary>
    /// Interaction logic for Ready.xaml
    /// </summary>
    public partial class Ready : Window
    {
        public Ready()
        {
            InitializeComponent();
            Grd_readyOrders.ItemsSource = MainWindow.readyOrders;
        }

        private void Btn_ready_Click(object sender, RoutedEventArgs e)
        {
            if ((Grd_readyOrders.SelectedItem as Orders).status < 3)
            {
                (Grd_readyOrders.SelectedItem as Orders).status++;
                Console.WriteLine((Grd_readyOrders.SelectedItem as Orders).status);
            }
        }
    }
}
