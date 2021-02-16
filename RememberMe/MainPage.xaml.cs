using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RememberMe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private bool _remember;
        public MainPage()
        {
            InitializeComponent();

            //if true, it automatically populates.
            if (Convert.ToBoolean(Remember.GetRememberMe))
            {
                entryUsername.Text = Remember.Username;
                entryPassword.Text = Remember.Password;
                _remember = true;
                chkRememberMe.IsChecked = true;

            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();




            if (Convert.ToBoolean(Remember.GetRememberMe))
            {
                Application.Current.Properties["IsLoggedIn"] = Boolean.TrueString;
            }
        }

        private void ChkRememberMe_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            _remember = !_remember;
        }

        private void BtnLogin_OnClicked(object sender, EventArgs e)
        {
            if (entryUsername.Text != null && entryPassword.Text != null)
            {
                string email = entryUsername.Text;

                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                {
                    string username, password;

                    username = entryUsername.Text;
                    password = entryPassword.Text;

                    if (_remember)
                    {
                        Remember.Username = username;
                        Remember.Password = password;
                        Remember.GetRememberMe = "true";
                    }
                    Navigation.PushModalAsync(new MasterInfo.MasterDetail());
                    Application.Current.Properties["IsLoggedIn"] = true;
                    //Navigation.PushModalAsync(new Homepage());
                }

                else
                {
                    DisplayAlert("Messgae", "Wrong Email! Try another one", "ok");
                }
            }
            else
            {
                DisplayAlert("Message", "Please, Enter Valid Details !!!!", "Ok");
            }
        }
    }
}

