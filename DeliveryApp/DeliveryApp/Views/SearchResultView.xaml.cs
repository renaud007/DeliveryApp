using DeliveryApp.Models;
using DeliveryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultView : ContentPage
    {
        
        public SearchResultView( string searchText)
        {
            InitializeComponent();

            this.BindingContext = new SearchResultViewModel(searchText);
        }

        

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as FoodItem;
            if (selectedItem == null) return;
            await Navigation.PushModalAsync(new ProductDetailsView(selectedItem));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}