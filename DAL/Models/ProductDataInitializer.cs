using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace TokenBasedAuthWEBAPI.DAL.Models
{
    public class ProductDataInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            IList<Product> products = new List<Product>();
            for (int i = 101; i <= 110; i++)
            {
                products.Add(new Product()
                {
                    ProductDescription = "Product Description " + i.ToString(),
                    ProductId = i,
                    ProductName = "Product Name " + i.ToString(),
                    ProductType = "Product Type " + i.ToString(),
                });
            }
        }
    }
}