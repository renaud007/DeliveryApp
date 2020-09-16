using DeliveryApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryApp
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] 
            { 
                 "AppTheme_Experimental",
                "MediaElement_Experimental" 
            });
            InitializeComponent();

            //  MainPage = new LoginView();
            //  MainPage = new NavigationPage(new SettingsPage());


           string uname = Preferences.Get("Username", string.Empty);
            if (String.IsNullOrEmpty(uname))
            {
                MainPage = new LoginView();
            }
            else 
            {

                MainPage = new NavigationPage(new ProductsView());

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
