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
    public partial class CategoryView : ContentPage
    {
         

        public CategoryView(Category category)
        {
            InitializeComponent();
            this.BindingContext = new CategoryViewModel(category);
        }

         

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = e.CurrentSelection.FirstOrDefault() as FoodItem;
            if (selectedProduct == null) return;

            Navigation.PushModalAsync(new ProductDetailsView(selectedProduct));
        }
    }
}