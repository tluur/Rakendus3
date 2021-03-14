using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace App15
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rakendus : ContentPage
    {
        public Rakendus()
        {
            InitializeComponent();
            SetBackground(Battery.ChargeLevel,
            Battery.State == BatteryState.Charging);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Battery.BatteryInfoChanged -= Battery_BatteryInfoChanged;
        }

        void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            SetBackground(e.ChargeLevel, e.State == BatteryState.Charging);
        }

        void SetBackground(double level, bool charging)
        {
            Color? color = null;
            var status = charging ? "Charging" : "Not charging";

            if(level > .5f)
            {
                color = Color.Green.MultiplyAlpha(level);
            }
            else if(level > .1f)
            {
                color = Color.Yellow.MultiplyAlpha(1d - level);
            }
            else
            {
                color = Color.Red.MultiplyAlpha(1d - level);
            }
            BackgroundColor = color.Value;
            LabelBatteryLevel.Text = status;
        }
    }
}