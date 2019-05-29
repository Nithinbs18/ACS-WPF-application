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
    public class Question
    {
        public string text { get; set; }
        public List<Answer> answers { get; set; }

    }

    public class Answer
    {
        public string text { get; set; }
        public bool status { get; set; }

    }
}