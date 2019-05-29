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
        private bool storeData = false;
        List<InputName> male = new List<InputName>() ;
        List<InputName> female = new List<InputName>() ;
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();

            //var lst1 = new List<InputName> { new InputName { cat="m", name="qwe"}, new InputName { cat = "m", name = "qwert" } };
            //StudentInfoStorage.WriteXml<List<InputName>>(lst1, "StudentsName.xml");
            //// to write data
            students = GenerateStudents(10);
            //StudentInfoStorage.WriteXml<ObservableCollection<Student>>(students, "StudentsInfo.xml");

            //to read data
            //students = StudentInfoStorage.ReadXml<ObservableCollection<Student>>("StudentsInfo.xml");
            //if (students == null)
            //    students = new ObservableCollection<Student>();



        }

        private ObservableCollection<Student> GenerateStudents(int cnt)
        {

            //for (int i = 0; i < cnt; i++)
            //{
            //    students.Add(new Student { îd = i, FirstName = "firstname" + i, lastName = $"LName"+i, hobbies = "hobbies" });
            //}rnd.Next(female.Count)


            var lstInput = StudentInfoStorage.ReadXml<List<InputName>>("StudentsName.xml");
            male = (from n in lstInput where n.cat == "m" select n).ToList();
            female = (from n in lstInput where n.cat == "f" select n).ToList();
            var lst = new ObservableCollection<Student>();
            for (int i = 0; i < 5; i++)
            {
                lst.Add(new Student { îd = i, FirstName = female[i].name ,  lastName = $"lName{i}", hobbies = "the hobbies" });
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
                Tbx_filter.Text = "";
            }
        }
       
        string filter = "";
        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter = Tbx_filter.Text.ToLower();
            if (filter == "")
            {
                Lbx_students.ItemsSource = students;
            }

            else
            {
                var results = from s in students where s.FirstName.ToLower().Contains(filter) select s;
                Lbx_students.ItemsSource = results;
            }
            
        }
        private void Btn_task_Click(object sender, RoutedEventArgs e)
        {
            ((Student)Lbx_students.SelectedItem).taskOk = !((Student)Lbx_students.SelectedItem).taskOk;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            if (storeData)
            {
                StudentInfoStorage.WriteXml<ObservableCollection<Student>>(students, "StudentsInfo.xml");
            }
        }

        private void Tbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            storeData = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new W_quiz();
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Hidden; // hides the 1st window
        }
    }
}
