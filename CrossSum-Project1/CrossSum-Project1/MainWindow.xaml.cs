using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CrossSum_Project1
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

        private void Btn_go_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            Regex regEx = new Regex(@"^\d{6}$");
            var input = Tbx_input.Text;
            int sum = 0;

            if (regEx.IsMatch(input))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    sum += Convert.ToInt32(input[i]) - 48;
                }
                Tbk_result.Text = $"the sum is {sum}";
                Tbx_input.Clear();
            }
            else
            {
                Tbk_result.Text = $"Enter a vaild 6 digit Number";
                Tbk_result.Foreground = Brushes.Red;
            }
        }

        private void Tbx_input_TextChanged(object sender, TextChangedEventArgs e)
        {
            Tbk_result.Foreground = Brushes.Black;
        }

        private void Tbx_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Calculate();
            }
        }
    }
}
