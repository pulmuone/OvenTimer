using OvenTimer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OvenTimer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Oven1Button_Clicked(object sender, EventArgs e)
        {
            foreach (var item in Navigation.NavigationStack)
            {
                //중복 클릭 방지
                if (item.ToString().EndsWith("OvenPage1"))
                {
                    return;
                }
            }

            await Navigation.PushAsync(new OvenPage1());
        }

        private async void Oven2Button_Clicked(object sender, EventArgs e)
        {
            foreach (var item in Navigation.NavigationStack)
            {
                //중복 클릭 방지
                if (item.ToString().EndsWith("OvenPage2"))
                {
                    return;
                }
            }

            await Navigation.PushAsync(new OvenPage2());
        }
    }
}
