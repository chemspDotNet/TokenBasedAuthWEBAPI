using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using TokenBasedAuthWEBAPI.Models;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(TokenBasedAuthWEBAPI.Startup))]

namespace TokenBasedAuthWEBAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<ApplicationContext>(() => new ApplicationContext());
            app.CreatePerOwinContext<UserManager<IdentityUser>>(CreateManager);

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/auth/token"),
                Provider = new AuthorizationServerProvider("self"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AllowInsecureHttp = true,

            });

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

        private static UserManager<IdentityUser> CreateManager(IdentityFactoryOptions<UserManager<IdentityUser>> options,
            IOwinContext context)
        {
            var userStore = new UserStore<IdentityUser>(context.Get<ApplicationContext>());
            var owinManager = new UserManager<IdentityUser>(userStore);
                 
               
            return owinManager;
        }

    }
}
