using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OvenTimer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OvenPage1 : ContentPage
    {
        Stopwatch stopwatch;
        bool IsTimerRunning = false;
        ISimpleAudioPlayer player;
        public OvenPage1()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            stopwatch.Reset();

            HourVal.Text = "0";
            MinuteVal.Text = "0";
            SecondVal.Text = "0";

            var stream = GetStreamFromFile("beep07.mp3");
            player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            player.Load(stream);
        }
        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream("OvenTimer." + filename);

            return stream;
        }

        private void StartTimer_Clicked(object sender, EventArgs e)
        {
            int h = 0;
            int m = 0;
            int s = 0;

            if (string.IsNullOrEmpty(HourVal.Text) || !int.TryParse(HourVal.Text.Trim(), out h))
            {
                h = 0;
            }

            if (string.IsNullOrEmpty(MinuteVal.Text) || !int.TryParse(MinuteVal.Text.Trim(), out m))
            {
                m = 0;
            }

            if (string.IsNullOrEmpty(SecondVal.Text) || !int.TryParse(SecondVal.Text.Trim(), out s))
            {
                s = 0;
            }

            HourVal.Text = h.ToString();
            MinuteVal.Text = m.ToString();
            SecondVal.Text = s.ToString();

            TimeSpan tsWait = new TimeSpan(h, m, s);

            if(tsWait.TotalSeconds == 0)
            {
                  return;
            }

            //stopwatch.Start();
            IsTimerRunning = true;
            stopwatch.Reset();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (!stopwatch.IsRunning)
                {
                    stopwatch.Start();
                }

                Device.BeginInvokeOnMainThread(() =>
                {
                    TimeSpan timespan = TimeSpan.FromSeconds(tsWait.TotalSeconds - stopwatch.Elapsed.TotalSeconds);
                    //HourVal.Text = ((int)(tsWait.TotalSeconds - sw.Elapsed.TotalSeconds)/3600).ToString();
                    //MinuteVal.Text = ((int)((tsWait.TotalSeconds - sw.Elapsed.TotalSeconds)/60)).ToString();
                    //SecondVal.Text = ((int)((tsWait.TotalSeconds - sw.Elapsed.TotalSeconds)%60)).ToString();

                    if (timespan.TotalSeconds <= 0)
                    {
                        //stopwatch.Stop();
                        IsTimerRunning = false;
                    } else
                    {
                        HourVal.Text = timespan.Hours.ToString();
                        MinuteVal.Text = timespan.Minutes.ToString();
                        SecondVal.Text = timespan.Seconds.ToString();
                    }
    
                });
              
                //Debug.WriteLine(" Elapsed : " + stopwatch.Elapsed.TotalSeconds);
                //Debug.WriteLine(" IsRunning : " + stopwatch.IsRunning.ToString());

                if (!IsTimerRunning)
                {
                    player.Play();
                    stopwatch.Stop();

                    return false;
                }
                else
                {
                    return true;
                }
                //return true; // runs again, or false to stop
            });
        }


        private void StopTimer_Clicked(object sender, EventArgs e)
        {
            stopwatch.Stop();
            IsTimerRunning = false;
        }

        private void ResetTimer_Clicked(object sender, EventArgs e)
        {
            IsTimerRunning = false;
            stopwatch.Stop();
            HourVal.Text = "0";
            MinuteVal.Text = "0";
            SecondVal.Text = "0";
        }

        private void SecondBtnPlus_Clicked(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.SecondVal.Text.Trim()) + 1 >= 59) return;

            this.SecondVal.Text = (Convert.ToInt32(this.SecondVal.Text.Trim()) + 1).ToString();
        }

        private void MinuteBtnPlus_Clicked(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.MinuteVal.Text.Trim()) + 1 >= 59) return;

            this.MinuteVal.Text = (Convert.ToInt32(this.MinuteVal.Text.Trim()) + 1).ToString();
        }

        private void HourBtnPlus_Clicked(object sender, EventArgs e)
        {
            this.HourVal.Text = (Convert.ToInt32(this.HourVal.Text.Trim()) + 1).ToString();
        }

        private void HourBtnMinus_Clicked(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.HourVal.Text.Trim()) - 1 < 0) return;

            this.HourVal.Text = (Convert.ToInt32(this.HourVal.Text.Trim()) - 1).ToString();
        }

        private void MinuteBtnMinus_Clicked(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.MinuteVal.Text.Trim()) - 1 < 0) return;
            this.MinuteVal.Text = (Convert.ToInt32(this.MinuteVal.Text.Trim()) - 1).ToString();
        }

        private void SecondBtnMinus_Clicked(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.SecondVal.Text.Trim()) - 1 < 0) return;

            this.SecondVal.Text = (Convert.ToInt32(this.SecondVal.Text.Trim()) - 1).ToString();
        }
    }
}