using GenZStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenZStore
{
    public class GonzStoreDbContext : DbContext
    {
        public GonzStoreDbContext() : base(@"Data Source=SORR\SQLEXPRESS;Initial Catalog=Gonz;User ID=sa; Password =147852369; Connect Timeout =60; Encrypt =False")
        { }

        public static GonzStoreDbContext context;

        public static GonzStoreDbContext GenInstance()
        {
            if(context == null) context = new GonzStoreDbContext();
            return context;
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Account> users { get; set; }
    }
}

