using DeliveryApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DeliveryApp.Services
{
    public class CartItemService
    {
        public int  GetUserCartCount()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var count = cn.Table<CartItem>().Count();
            cn.Close();
            return count;
        }

        public void RemoveItemsFromCart()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            cn.DeleteAll<CartItem>();
            cn.Commit();
            cn.Close();
        }
    }
}
