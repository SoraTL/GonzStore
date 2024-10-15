using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenZStore.Models
{
    public class Product
    {
        public string name {  get; set; }
        public int id { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int category_id { get; set; }
        public string image { get; set; }
    }
}