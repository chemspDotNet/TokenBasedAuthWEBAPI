using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenBasedAuthWEBAPI.DAL.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }

    }
}