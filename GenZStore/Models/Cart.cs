using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenZStore.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }

}