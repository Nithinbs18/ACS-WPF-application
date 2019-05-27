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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace restaurant
{
    /// <summary>
    /// Interaction logic for readyOrder.xaml
    /// </summary>
    public partial class readyOrder : Page
    {
        public readyOrder()
        {
            InitializeComponent();
        }

        private void Btn_ready_Click(object sender, RoutedEventArgs e)
        {
            if (Btn_ready.Content == "Delivered")
            {
                Btn_ready.Content = "Closed order";
                Btn_ready.IsEnabled = false;
            }
            else
            {
                Btn_ready.Content = "Delivered";
            }
            
        }
    }
}
