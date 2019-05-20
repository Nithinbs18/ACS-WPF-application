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

namespace demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_newOrder_Click(object sender, RoutedEventArgs e)
        {
            var newOrder = new Window1();
            newOrder.Show();
        }

        private void Btn_searchOrder_Click(object sender, RoutedEventArgs e)
        {
            var searchOrder = new Window3();
            searchOrder.Show();
        }

        private void Btn_readyOrder_Click(object sender, RoutedEventArgs e)
        {
            var readyOrder = new Window2();
            readyOrder.Show();
        }
    }
}
