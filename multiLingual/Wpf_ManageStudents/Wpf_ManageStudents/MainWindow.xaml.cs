using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Wpf_ManageStudents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> students;
        private bool storeData;
        string filter = "";
        List<InputName> female = new List<InputName>();
        List<InputName> male = new List<InputName>();
        string language;
        List<string> cultures = new List<string>
        {
            "en English","hi ಕನ್ನಡ"
        };
        List<InputName> lastNames = new List<InputName>();
        Random rnd = new Random();
        public MainWindow()
        {
            //string language = "hi";
            language = Properties.Settings.Default.language;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            InitializeComponent();
            //var list = new List<InputName> { new InputName { name="XXX",category="m"},
            //new InputName { name="XXX",category="m"},
            //new InputName { name="XXX",category="m"}};
            //TestStorage.WriteXml<List<InputName>>(list, "InputData.xml");
        }

        private ObservableCollection<Student> GenerateStudents(int count)
        {
            var listInput = TestStorage.ReadXml<List<InputName>>("InputData.xml");
            male = (from n in listInput where n.category == "m" select n).ToList();
            female = (from n in listInput where n.category == "f" select n).ToList();
            lastNames = (from n in listInput where n.category == "l" select n).ToList();
            var list = new ObservableCollection<Student>();

            for (int i = 0; i < count; i++)
            {
                Student student = new Student();
                int forGender = rnd.Next(100);
                int forAge = rnd.Next(21, 31);
                if (forGender < 25)
                {
                    student = new Student
                    {
                        id = i,
                        firstName = female[rnd.Next(female.Count)].name,
                        lastName = lastNames[rnd.Next(lastNames.Count)].name,
                        hobbies = "the hobbies",
                        isFemale = true,
                        birthDate = DateTime.Today.AddYears(-forAge)
                    };
                }
                else
                {
                    student = new Student
                    {
                        id = i,
                        firstName = male[rnd.Next(male.Count)].name,
                        lastName = lastNames[rnd.Next(lastNames.Count)].name,
                        hobbies = "the hobbies",
                        isFemale = false,
                        birthDate = DateTime.Today.AddYears(-forAge)
                    };
                }
                list.Add(student);
                //list.Add(new Student { id = i, firstName = "fname" + i, lastName = $"lname{i}", hobbies = "the hobbies" });
            }

            return list;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //students = TestStorage.ReadXml<ObservableCollection<Student>>("StudentsTest.xml");
            //GenerateStudents(20);
            if (students == null)
                students = GenerateStudents(100);
            //students = new ObservableCollection<Student>();
            Cbx_lang.ItemsSource=cultures;
            Lbx_students.ItemsSource = students;
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            var stud = new Student { firstName = "Please edit!!!", lastName = "Please edit!" };
            students.Add(stud);
            Lbx_students.SelectedItem = stud;
            Lbx_students.ScrollIntoView(stud);
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (Lbx_students.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to be deleted!");
                return;
            }

            students.Remove(Lbx_students.SelectedItem as Student);
        }

        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter = Tbx_filter.Text.ToLower();
            if (filter == "")
                Lbx_students.ItemsSource = students;
            else
            {
                var results = from s in students where s.lastName.Contains(filter) select s;
                Lbx_students.ItemsSource = results;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Lbx_students.SelectedItem as Student).taskOk = !(Lbx_students.SelectedItem as Student).taskOk;
            storeData = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (storeData)
                TestStorage.WriteXml<ObservableCollection<Student>>(students, "StudentsTest.xml");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            storeData = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var win = new W_Quiz();
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Hidden;
        }

        private void Lbx_stu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var wi= new Dvd((Medium))
        }

        private void Cbx_lang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var txt = (sender as ComboBox).SelectedItem.ToString();
            language = txt.Substring(0, 2);
            Properties.Settings.Default.language = language;
            Properties.Settings.Default.Save();
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            //Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Close();
        }
    }
}
