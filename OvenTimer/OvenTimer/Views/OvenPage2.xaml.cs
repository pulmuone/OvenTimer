using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OvenTimer.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OvenPage2 : ContentPage
    {
        public OvenPage2()
        {
            InitializeComponent();

        }

        private async void TimerSet_Clicked(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(1, 5, 0); //1시간 5분
            TimerPage tsp = new TimerPage(ts);
            tsp.TimerSetting += Tsp_TimerSetting;

            await PopupNavigation.Instance.PushAsync(tsp, false);
        }

        private void Tsp_TimerSetting(TimeSpan timeSpan)
        {
            ReturnTimer.Text = timeSpan.ToString();
        }
    }
}