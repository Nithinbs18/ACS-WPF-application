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

namespace billHistory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<BillHistoryData> persistantBillData = new ObservableCollection<BillHistoryData>();

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                persistantBillData.Add(new BillHistoryData { billNo = i, total = 1 * 10 });
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Storage.WriteXml<ObservableCollection<BillHistoryData>>(persistantBillData,"billingData.xml");
        }
    }
}
