using System.Collections.Generic;

namespace Wpf_ManageStudents
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