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
        ObservableCollection<Products> food;
        ObservableCollection<Products> drink;
        public newOrder()
        {
            InitializeComponent();
            var menuFood = new ObservableCollection<Products>();
            for (int i = 1; i < 10; i++)
            {
                menuFood.Add(new Products { id = i, category = (i - 1) % 3, description = "decs" + i, name = "food" + i, price = i });
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

    }
}
