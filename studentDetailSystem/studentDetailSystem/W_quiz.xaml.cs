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

namespace studentDetailSystem
{
    /// <summary>
    /// Interaction logic for W_quiz.xaml
    /// </summary>
    public partial class W_quiz : Window
    {
        Question questions;
        public W_quiz()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            questions = new Question { text = "Question text1", answers = new List<Answer> { new Answer { text = "answer1 q1", status=false }, new Answer { text = "answer2 q1", status = true }, new Answer { text = "answer3 q1", status = false }, new Answer { text = "answer4 q1", status = false } } };

            //questions.answers = questions.answers.OrderBy(x => Guid.NewGuid());
            DataContext = questions;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ans = (Answer)(sender as ListBox).SelectedItem;
            if (ans.status)
            {
                MessageBox.Show("Correct answer!!","correct", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Wrong!!", "Incorrect", MessageBoxButton.OK , MessageBoxImage.Error );
            }
        }
    }

  
}
