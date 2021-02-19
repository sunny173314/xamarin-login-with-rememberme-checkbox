using RememberMe.MenuItems;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RememberMe.MasterInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MasterDetail()
        {
            InitializeComponent();

            menuList = new List<MasterPageItem>();

            // Adding menu items to menuList and you can define title ,page and icon
            menuList.Add(new MasterPageItem() { Title = "Home", Icon = "iconhome.png", TargetType = typeof(MasterInfo.Wellcome) });
            menuList.Add(new MasterPageItem() { Title = "Device Info", Icon = "device.png", TargetType = typeof(MasterInfo.DeviceInformation) });
            menuList.Add(new MasterPageItem() { Title = "PDF", Icon = "help.png", TargetType = typeof(MasterInfo.PdfView) });
            //menuList.Add(new MasterPageItem() { Title = "LogOut", Icon = "logout.png", TargetType = typeof(LogoutPage) });

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MasterInfo.Wellcome)));
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}