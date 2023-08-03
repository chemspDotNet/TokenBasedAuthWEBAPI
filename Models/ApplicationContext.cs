using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenBasedAuthWEBAPI.Models
{
    public class ApplicationContext: IdentityDbContext
    {
        public ApplicationContext():base("DefaultConnection")
        {
            
        }
    }
}