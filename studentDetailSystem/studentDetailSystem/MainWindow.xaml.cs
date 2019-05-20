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

namespace studentDetailSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students;

        public MainWindow()
        {
            InitializeComponent();
            students = GenerateStudents(20);
        }

        private List<Student> GenerateStudents(int cnt)
        {
            var lst = new List<Student>();

            for (int i = 0; i < cnt; i++)
            {
                lst.Add(new Student { îd = i, FirstName = "firstname" + i, lastName = $"LName", hobbies = "hobbies" });
            }

            return lst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Lbx_students.ItemsSource = students;
        }
    }
}
