using DeliveryApp.Helpers;
using DeliveryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DeliveryApp.ViewModels
{
    public class SearchResultViewModel : BaseViewModel
    {
        public ObservableCollection<FoodItem> FoodItemsByQuery { get; set; }


        private int _TotalFoodItems;

        public int TotalFoodItems
        {
            get { return _TotalFoodItems; }
            set
            {
                _TotalFoodItems = value; OnPropertyChanged();
            }
        }
        public SearchResultViewModel( string searchText)
        {
            FoodItemsByQuery = new ObservableCollection<FoodItem>();
            GetFoodItemsByQuery(searchText) ;
        }

        private async void GetFoodItemsByQuery( string searchText)
        {
            var data = await new FoodItemService().GetFoodItemByQueryAsync(searchText);
            FoodItemsByQuery.Clear();

           foreach (var item in data)
            {
                FoodItemsByQuery.Add(item);
            }
            TotalFoodItems = FoodItemsByQuery.Count();
        }
    }
}
