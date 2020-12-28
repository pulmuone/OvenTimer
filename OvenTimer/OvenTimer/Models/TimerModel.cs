using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OvenTimer.Models
{

    public class TimerModel
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        private readonly ObservableCollection<string> wheelHour, wheelMinute, wheelSecond;

        public IReadOnlyCollection<ObservableCollection<string>> ItemsSource { get; }

        public TimerModel()
        {
            wheelHour = new ObservableCollection<string>{"0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            wheelMinute = new ObservableCollection<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            wheelSecond = new ObservableCollection<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            ItemsSource = new[] { wheelHour, wheelMinute, wheelSecond };
        }
    }
}
