using DeliveryApp.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeliveryApp.Helpers
{
    public class AddFoodItemData
    {
        FirebaseClient client;

        public List<FoodItem> FoodItems { get; set; }

        public AddFoodItemData()
        {
            client = new FirebaseClient("https://deliveryapp-59388.firebaseio.com/");
            FoodItems = new List<FoodItem>()
            {
                new FoodItem
                {
                    ProductID = 1,
                    CategoryID = 1,
                    ImageUrl = "MainBurger",
                    Name = "Burger and Pizza Hub 1",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = " 4.8",
                    RatingDetail = " (121 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 2,
                    CategoryID = 1,
                    ImageUrl = "MainBurger",
                    Name = "Burger and Pizza Hub 2",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = " 4.8",
                    RatingDetail = " (121 raitings)",
                    HomeSelected = "EmptyHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 3,
                    CategoryID = 1,
                    ImageUrl = "MainBurger",
                    Name = "Burger and Pizza Hub 3",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = " 4.8",
                    RatingDetail = " (121 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 4,
                    CategoryID = 1,
                    ImageUrl = "MainBurger",
                    Name = "Burger and Pizza Hub 4",
                    Description = "Burger - Pizza - Breakfast",
                    Rating = " 4.8",
                    RatingDetail = " (121 raitings)",
                    HomeSelected = "EmptyHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 5,
                    CategoryID = 2,
                    ImageUrl = "MainPizza",
                    Name = "Pizza",
                    Description = "Pizza - Breakfast",
                    Rating = " 4.4",
                    RatingDetail = " (120 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 6,
                    CategoryID = 2,
                    ImageUrl = "MainPizza",
                    Name = "Pizza Hub 2",
                    Description = "Pizza Hub 2- Breakfast",
                    Rating = " 4.8",
                    RatingDetail = " (156 raitings)",
                    HomeSelected = "EmptyHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 7,
                    CategoryID = 3,
                    ImageUrl = "MainDessert",
                    Name = "Ice Creams",
                    Description = "Icecream - Breakfast",
                    Rating = " 4.4",
                    RatingDetail = " (120 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 8,
                    CategoryID = 3,
                    ImageUrl = "MainDessert",
                    Name = "Cakes",
                    Description = "Cool Cakes- Breakfast",
                    Rating = " 4.8",
                    RatingDetail = " (156 raitings)",
                    HomeSelected = "EmptyHeart",
                    Price = 45
                }
             };
        }

        public async Task AddFoodItemAsync()
        {
            try
            {
                foreach (var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                        CategoryID = item.CategoryID,
                        ProductID = item.ProductID,
                        Description = item.Description,
                        HomeSelected = item.HomeSelected,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Price = item.Price,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

    }
}
