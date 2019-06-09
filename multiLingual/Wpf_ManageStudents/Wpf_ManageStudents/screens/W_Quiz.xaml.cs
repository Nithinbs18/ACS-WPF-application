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
using System.Windows.Shapes;

namespace Wpf_ManageStudents
{
    /// <summary>
    /// Interaction logic for W_Quiz.xaml
    /// </summary>
    public partial class W_Quiz : Window
    {
        Question question;
        public W_Quiz()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            question = new Question
            {
                text = "Question text1",
                answers = new List<Answer>
            {
                new Answer{text="Answer1 Q1",status=true},
                new Answer{text="Answer2 Q1",status=false},
                new Answer{text="Answer3 Q1",status=false},
                new Answer{text="Answer4 Q1",status=false},
            }
                //question picked randomly
            };
            question.answers = question.answers.OrderBy(x => Guid.NewGuid()).ToList();
            DataContext = question;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var answer = (Answer)(sender as ListBox).SelectedItem;
            if (answer.status)
            {
                MessageBox.Show("Congrats..it was correct", "Correct", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Sorry..it was not correct", ":(", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
