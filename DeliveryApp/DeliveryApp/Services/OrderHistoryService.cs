using DeliveryApp.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Firebase.Database.Query;
using System.Linq;

namespace DeliveryApp.Services
{
   public class OrderHistoryService
    {
        FirebaseClient client;
        List<OrderHistory> UserOrders;
      
        public OrderHistoryService()
        {
            client = new FirebaseClient("https://deliveryapp-59388.firebaseio.com/");
            UserOrders = new List<OrderHistory>();
        }

        public async Task<List<OrderHistory>> GetOrderDetailsAsync()
        {
            var uname = Preferences.Get("Username", "Invite");

            var orders = (await client.Child("Orders").OnceAsync<Order>()).Where(o => o.Object.Username.Equals(uname)).Select(o => new Order
            {
                OrderId = o.Object.OrderId,
                ReceiptId = o.Object.ReceiptId,
                TotalCost = o.Object.TotalCost
            }).ToList();

            foreach(var order in orders)
            {
                OrderHistory oh = new OrderHistory();
                oh.OrderId = order.OrderId;
                oh.ReceiptId = order.ReceiptId;
                oh.TotalCost = order.TotalCost;

                var orderDetails = (await client.Child("OrderDetails").OnceAsync<OrderDetails>())
                    .Where(o => o.Object.Equals(order.OrderId))
                    .Select(o => new OrderDetails
                    {
                        OrderId= o.Object.OrderId,
                        OrderDetailId=o.Object.OrderDetailId,
                        Price= o.Object.Price,
                        ProductID=o.Object.ProductID,
                        ProductName=o.Object.ProductName,
                        Quantity=o.Object.Quantity

                    }).ToList();

                oh.AddRange(orderDetails);

                UserOrders.Add(oh);

            }
            return UserOrders;

        }
    }
}
