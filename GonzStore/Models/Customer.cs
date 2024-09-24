using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GonzStore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Avatar { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
    }
}