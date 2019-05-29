﻿using System;
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
        int newOrderNo = ++MainWindow.orderNo;
        bool orderNoSet;
        public newOrder()
        {
            InitializeComponent();
            var orderItem = new ObservableCollection<Orders>();
            newOrders = orderItem;
            Grd_orders.ItemsSource = orderItem;
            var menuFood = new ObservableCollection<Products>();
            for (int i = 1; i < 10; i++)
            {
                menuFood.Add(new Products { id = i, category = (i - 1) % 3, description = "xxxxxxxxxxx" + i, name = "food" + i, price = i });
            }
            MainWindow.food = menuFood;

            var menuDrink = new ObservableCollection<Products>();
            for (int i = 1; i < 5; i++)
            {
                menuDrink.Add(new Products { id = i, category = (i - 1) % 3, description = "yyyyyyyyyyyy" + i, name = "drink" + i, price = i });
            }
            MainWindow.drink = menuDrink;
            Grd_Menu_Food.ItemsSource = MainWindow.food;
            Grd_Menu_Drink.ItemsSource = MainWindow.drink;

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
                        Orders st = new Orders { orderItem = selectedItem, quantity = 1, tableNo = this.orderTableNo, orderNo = newOrderNo };
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
            //Console.WriteLine(Cbx_tableNo.SelectedValue);
            Console.WriteLine(1);
            Console.WriteLine(Cbx_tableNo.SelectedValue);
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
            Tbx_newOrderNo.Text = newOrderNo.ToString();
            this.orderNoSet = true;
        }
    }
}