using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RememberMe.MasterInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceInformation : ContentPage
    {
        public DeviceInformation()
        {
            InitializeComponent();

            // Device Model (SMG-950U, iPhone10,6)
            var device = Xamarin.Essentials.DeviceInfo.Model;

            // Manufacturer (Samsung)
            var manufacturer = Xamarin.Essentials.DeviceInfo.Manufacturer;

            // Device Name (Motz's iPhone)
            var deviceName = Xamarin.Essentials.DeviceInfo.Name;

            // Operating System Version Number (7.0)
            var version = Xamarin.Essentials.DeviceInfo.VersionString;

            // Platform (Android)
            var platform = Xamarin.Essentials.DeviceInfo.Platform;

            // Device Type (Physical)
            var deviceType = Xamarin.Essentials.DeviceInfo.DeviceType;

            Info.Text = "Device Info:" + device;
            Info1.Text = "Manufacturer:" + manufacturer;
            Info2.Text = "Device Name:" + deviceName;
            Info3.Text = "Version:" + version;
            Info4.Text = "Platform:" + platform;
            Info5.Text = "Device Type:" + deviceType;

            //{device} {manufacturer} {deviceName} {version} {platform} {deviceType}";
        }

        private async void logoff_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Message", "Do You want to logout", "ok", "Cancel");
            if (result == true)
            {
                Remember.ClearEverything();
                Application.Current.MainPage = new NavigationPage(new MainPage());
                Application.Current.Properties["IsLoggedIn"] = false;
            }
            else
            {

            }
        }
    }
}