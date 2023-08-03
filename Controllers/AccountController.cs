using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TokenBasedAuthWEBAPI.Models;

namespace TokenBasedAuthWEBAPI.Controllers
{
    
    public class AccountController : ApiController
    {
        private UserManager<IdentityUser> _userManager;

        public UserManager<IdentityUser> UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<UserManager<IdentityUser>>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public AccountController()
        {
           
        }

        public AccountController(UserManager<IdentityUser> userManager)
        {

            UserManager = userManager;

        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("api/Account/Register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new IdentityUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                     return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }




    }
}
