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

namespace studentDetailSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> students;

        public MainWindow()
        {
            InitializeComponent();
            students = GenerateStudents(20);
        }

        private ObservableCollection<Student> GenerateStudents(int cnt)
        {
            var lst = new ObservableCollection<Student>();

            for (int i = 0; i < cnt; i++)
            {
                lst.Add(new Student { îd = i, FirstName = "firstname" + i, lastName = $"LName"+i, hobbies = "hobbies" });
            }

            return lst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Lbx_students.ItemsSource = students;
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            var stud = new Student { FirstName="Please edit!!", lastName="please edit",hobbies="please edit"};
            students.Add(stud);
            Lbx_students.SelectedItem = stud;
            Lbx_students.ScrollIntoView(stud);
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (Lbx_students.SelectedItem==null)
            {
                MessageBox.Show("Please selet an item to be deleted!","Error");
                return;
            }
            else
            {
                students.Remove(Lbx_students.SelectedItem as Student);
            }
        }

        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = Tbx_filter.Text;
            var results = from s in students where s.lastName.Contains(filter) select s;
            Lbx_students.ItemsSource = results;
        }
    }
}
