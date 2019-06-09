using restaurant;
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
    /// Interaction logic for newOrder.xaml
    /// </summary>
    public partial class newOrder : Page
    {

        ObservableCollection<Orders> newOrders;
        int orderTableNo;
        //int newOrderNum;
        int newOrderNum = MainWindow.orderNo;
        bool orderNoSet;
        public newOrder()
        {
            InitializeComponent();
            var orderItem = new ObservableCollection<Orders>();
            newOrders = orderItem;
            Grd_orders.ItemsSource = orderItem;          
            Grd_Menu_Food.ItemsSource = MainWindow.food;
            Grd_Menu_Drink.ItemsSource = MainWindow.drink;
            Grd_Menu_starter.ItemsSource = MainWindow.starters;

        }

        private void Cbx_tableNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tblNo = Cbx_tableNo.SelectedValue.ToString();
            Console.WriteLine(tblNo);
            Cbx_tableNo.IsEnabled = false;

            switch (tblNo)
            {
                case "System.Windows.Controls.ComboBoxItem: Table no. 1":
                    this.orderTableNo = 1;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Table no. 2":
                    this.orderTableNo = 2;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Table no. 3":
                    this.orderTableNo = 3;
                    break;
                case "System.Windows.Controls.ComboBoxItem: Table no. 4":
                    this.orderTableNo = 4;
                    break;
                    //default:
                    //    MessageBox.Show("Please a table!","Error",MessageBoxButton.OK);
                    //    break;
            }
            this.orderNoSet = true;
            bool set = false;
            if (MainWindow.tableOrder.Count != 0)
            {
                foreach (var table in MainWindow.tableOrder)
                {
                    if (!table.orderClosed && table.tableNo == this.orderTableNo)
                    {
                        this.newOrderNum = table.tableOrderNo;
                            set = true;
                            Tbx_newOrderNo.Text = table.tableOrderNo.ToString();
                            break;     
                    }
                }
                if (!set)
                {
                    this.newOrderNum = ++MainWindow.orderNo;
                    TableNo tNo = new TableNo { tableNo = this.orderTableNo, tableOrderNo = this.newOrderNum, orderClosed = false };
                    MainWindow.tableOrder.Add(tNo);
                    Tbx_newOrderNo.Text = newOrderNum.ToString();
                    set = true;
                }
            }
            else
            {
                this.newOrderNum = ++MainWindow.orderNo;
                TableNo tNo = new TableNo { tableNo = this.orderTableNo, tableOrderNo = this.newOrderNum, orderClosed = false };
                MainWindow.tableOrder.Add(tNo);
                Tbx_newOrderNo.Text = newOrderNum.ToString();
            }
        }

        private void Btn_addItem_Click(object sender, RoutedEventArgs e)
        {
            bool contains = false;
            if (orderNoSet)
            {
                Products selectedItem = (Products)Grd_Menu_Food.SelectedItem;
                if (selectedItem == null)
                {
                    selectedItem = (Products)Grd_Menu_Drink.SelectedItem;
                    if (selectedItem == null)
                    {
                        selectedItem = (Products)Grd_Menu_starter.SelectedItem;
                    }
                }
                Grd_Menu_Food.UnselectAll();
                Grd_Menu_Drink.UnselectAll();
                Grd_Menu_starter.UnselectAll();
                if (selectedItem == null)
                {
                    MessageBox.Show("Please selet an item to be added!", "Error");
                    return;
                }
                else
                {
                    foreach (var item in MainWindow.orders)
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
                        Orders st = new Orders { orderItem = selectedItem, quantity = 1, tableNo = this.orderTableNo, orderNo = this.newOrderNum };
                        newOrders.Add(st);
                        MainWindow.orders.Add(st);
                    }

                }
            }
            else
            {
                MessageBox.Show("Please select a table!", "Error");
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
                if (st.status == 2)
                {
                    MessageBox.Show("Cannot make changes to this item, Please add it from the menu!!", "Error");
                    return;
                }
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
                if (st.status == 0)
                {
                    MainWindow.orders.Remove(st);
                    newOrders.Remove(st);
                }
                else
                    MessageBox.Show("Cannot delete item!", "Error");

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
                    if (st.status == 0)
                    {
                        st.quantity--;
                    }
                    
                }
            }

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }


        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = Tbx_filter.Text.ToLower();
            if (filter == "")
            {
                Grd_Menu_Food.ItemsSource = MainWindow.food;
                Grd_Menu_Drink.ItemsSource = MainWindow.drink;
                Grd_Menu_starter.ItemsSource = MainWindow.starters;
            }

            else
            {
                var results = from s in MainWindow.food where s.name.ToLower().Contains(filter) select s;
                Grd_Menu_Food.ItemsSource = results;
                var results1 = from s in MainWindow.drink where s.name.ToLower().Contains(filter) select s;
                Grd_Menu_Drink.ItemsSource = results1;
                var results2 = from s in MainWindow.starters where s.name.ToLower().Contains(filter) select s;
                Grd_Menu_starter.ItemsSource = results2;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tbx_filter.Text = "";
            Grd_Menu_Food.ItemsSource = MainWindow.food;
            Grd_Menu_Drink.ItemsSource = MainWindow.drink;
            Grd_Menu_starter.ItemsSource = MainWindow.starters;
        }

        private void Btn_clearFilter_Click(object sender, RoutedEventArgs e)
        {
            Tbx_filter.Text = "";
            Grd_Menu_Food.ItemsSource = MainWindow.food;
            Grd_Menu_Drink.ItemsSource = MainWindow.drink;
            Grd_Menu_starter.ItemsSource = MainWindow.starters;
        }
    }
}
