using GonzStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GonzStore
{
    public class GonzDBContext : DbContext
    {
        public GonzDBContext() : base("metadata=res://*/Models.DatabaseGonzStore.csdl|res://*/Models.DatabaseGonzStore.ssdl|res://*/Models.DatabaseGonzStore.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=SORR\SQLEXPRESS;initial catalog=Gonz;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework&quot;") 
        { }
        public DbSet<Customer> customers { get; set; }
    }
}