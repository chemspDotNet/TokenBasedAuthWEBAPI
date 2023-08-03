using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TokenBasedAuthWEBAPI.DAL.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext():base("ProductConnString")
        {
           // Database.SetInitializer(new ProductDataInitializer());  
            
        }
        
      //  DbSet<Product> Products { get; set;}

        public System.Data.Entity.DbSet<TokenBasedAuthWEBAPI.DAL.Models.Product> Products { get; set; }
    }
}