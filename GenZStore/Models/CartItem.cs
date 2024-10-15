using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenZStore.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; } 
        public int CartId { get; set; }      
        public int ProductId { get; set; }          
        public Product Product { get; set; }       
        public int Quantity { get; set; }         
    }
}