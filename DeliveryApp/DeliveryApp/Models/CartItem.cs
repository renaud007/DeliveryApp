using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryApp.Models
{
    [Table("CartItem")]
   public class CartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public int  Quantity { get; set; }
    }
}
