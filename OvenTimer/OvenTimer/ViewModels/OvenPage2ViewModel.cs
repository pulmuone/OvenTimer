using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace OvenTimer.ViewModels
{


    public class OvenPage2ViewModel : ViewModelBase
    {

        public Command ItemSelectedCommand { get; }
        public IReadOnlyList<IReadOnlyList<string>> ItemsSource { get; set; }
        private readonly ObservableCollection<string> wheelHour, wheelMinute, wheelSecond;


        public OvenPage2ViewModel()
        {
            wheelHour = new ObservableCollection<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            wheelMinute = new ObservableCollection<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            wheelSecond = new ObservableCollection<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            ItemsSource = new[] { wheelHour, wheelMinute, wheelSecond };


            ItemSelectedCommand = new Command<Tuple<int, int, IList<int>>>(tuple =>
            {
                var selectedWheelIndex = tuple.Item1;
                var selectedItemIndex = tuple.Item2;
                var selectedValue = ItemsSource[selectedWheelIndex][selectedItemIndex];
                Debug.WriteLine($"ItemSelectedCommand called wheel:{selectedWheelIndex} row:{selectedItemIndex} value:{selectedValue}");
                //SelectedItem = selectedValue;
            });
        }

    }
}
