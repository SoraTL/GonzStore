using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenZStore.Models
{
    public class Account
    {
        public int Id { get; set; }          
        public string FirstName { get; set; }      
        public string LastName { get; set; }         
        public string Username { get; set; }         
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }    
        public string Address { get; set; }
        public string Role { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } 

    }
}