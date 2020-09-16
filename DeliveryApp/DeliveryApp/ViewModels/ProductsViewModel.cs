using DeliveryApp.Helpers;
using DeliveryApp.Models;
using DeliveryApp.Services;
using DeliveryApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using static System.Net.Mime.MediaTypeNames;
using Application = Xamarin.Forms.Application;

namespace DeliveryApp.ViewModels
{
   public class ProductsViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { _Username = value;
                OnPropertyChanged();
            }
        }
        private string _SearchText;
        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                _SearchText = value;
                OnPropertyChanged();
            }
        }

        private int _UserCartItemsCount;
        public int UserCartItemsCount
        {
            get { return _UserCartItemsCount; }
            set { _UserCartItemsCount = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<FoodItem> LatestItems { get; set; }

        public Command ViewCartCommand { get; set; }
        public Command LogoutCommand { get; set; }
        public Command OrdersHistoryCommand { get; set; }
        public Command SearchViewCommand { get; set; }

        public ProductsViewModel()
        {
            var uname = Preferences.Get("Username", String.Empty);
            if (string.IsNullOrEmpty(uname))
            {
                Username = "Invité";
            }
            else { Username = uname; }

            UserCartItemsCount = new CartItemService().GetUserCartCount();
            Categories = new ObservableCollection<Category>();
            LatestItems= new ObservableCollection<FoodItem>();


            GetCategoriesAsync();
            GetLatestItems();

            ViewCartCommand = new Command(async () => await ViewCartAsync());
            LogoutCommand = new Command(async () => await LogoutAsync());
            OrdersHistoryCommand = new Command(async () => await OrdersHistoryAsync());
            SearchViewCommand = new Command(async () => await SearchViewAsync());
        }

        private async Task SearchViewAsync()
        {
            if (SearchText == null)
            { 
                await Application.Current.MainPage.DisplayAlert("erreur", "la barre de recherche ne peut-être vide", "ok");
            }
            else 
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new SearchResultView(SearchText)); 
            }
           
        }

        private async Task OrdersHistoryAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new OrdersHistoryView());
        }

        private async Task LogoutAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());
        }

        private async Task ViewCartAsync()
        {
          await  Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async void GetLatestItems()
        {
            var data = await new FoodItemService().GetLatestFoodItemsAsync();
            LatestItems.Clear();
            foreach(var item in data)
            {
                LatestItems.Add(item);
            }

        }

        private async void GetCategoriesAsync()
        {
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach( var item in data)
            {
                Categories.Add(item);
            }
        }
    }
}
