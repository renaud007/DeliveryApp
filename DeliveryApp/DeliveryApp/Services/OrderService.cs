using DeliveryApp.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DeliveryApp.Services
{
   public class OrderService
    {
        FirebaseClient client;
        public OrderService()
        {
            client = new FirebaseClient("https://deliveryapp-59388.firebaseio.com/");
        }
        public async Task<string> PlaceOrderAsync()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var data = cn.Table<CartItem>().ToList();

            var orderId = Guid.NewGuid().ToString();
            var uname = Preferences.Get("Username", "Invite");

            decimal totalCost = 0;

            foreach(var item in data)
            {
                var od = new OrderDetails()
                {
                    OrderId = orderId,
                    OrderDetailId = Guid.NewGuid().ToString(),
                    ProductID=item.ProductId,
                    ProductName=item.ProductName,
                    Price=item.Price,
                    Quantity= item.Quantity

                };

                totalCost += item.Price * item.Quantity;
                await client.Child("OrderDetails").PostAsync(od);
            }

            await client.Child("Orders").PostAsync(new Order() { 
            
            OrderId=orderId,
            Username= uname,
            TotalCost=totalCost
            
            });
            return orderId;

        }
    }
}
