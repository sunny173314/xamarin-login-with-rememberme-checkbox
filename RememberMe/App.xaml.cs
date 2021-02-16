using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace RememberMe
{
    public partial class App : Application
    {
        public App()
        {
            
            InitializeComponent();
            Device.SetFlags(new[] { "Shapes_Experimental", "MediaElement_Experimental" });
            bool isLoggedIn = Current.Properties.ContainsKey("IsLoggedIn") ? Convert.ToBoolean(Current.Properties["IsLoggedIn"]) : false;
            if (!isLoggedIn)
            {
                //load if not logged in
                //mainpage = new navigationpage(new login());
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                //Load if Logged In
                MainPage = new NavigationPage(new MasterInfo.MasterDetail());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
