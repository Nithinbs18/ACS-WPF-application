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

namespace increment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<items> prod;
        public MainWindow()
        {
            InitializeComponent();
            var item = new ObservableCollection<items>();
            for (int i = 0; i < 20; i++)
            {
                item.Add(new items { id = i, description = "item"+i, name = "item0"+i, quantity = 1 });
            }
            prod = item;
            gridData.ItemsSource = prod;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            items st = (items)gridData.SelectedItem;
            st.quantity++;
        }

        private void Btn_sub_Click(object sender, RoutedEventArgs e)
        {
            items st = (items)gridData.SelectedItem;
            if (st.quantity > 1)
            {
                st.quantity--;
            }

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            items st = (items)gridData.SelectedItem;
            prod.Remove(st);
        }
    }

    
}