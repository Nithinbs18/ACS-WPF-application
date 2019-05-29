using System;
using System.ComponentModel;

namespace studentDetailSystem
{
    public class Student: INotifyPropertyChanged
    {
        public int îd { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string hobbies { get; set; }
        private bool taskOk_;
        public bool taskOk
        { get { return taskOk_; }
            set {
                taskOk_ = value;
                OnPropertyChanged("taskOK");
            } }

        private void OnPropertyChanged(string v)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler!=null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}