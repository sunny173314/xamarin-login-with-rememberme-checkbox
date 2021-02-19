using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RememberMe.MasterInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Wellcome : ContentPage
    {
        public Wellcome()
        {
            InitializeComponent();
            user.Text = Remember.Username;
        }

        private async void logoff_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Message", "Do You want to logout","ok", "Cancel");
            if(result == true)
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