using Owin;
using System.Web.Http;

using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartupAttribute(typeof(WebApp.Startup))]
namespace WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureApiAuth(app);
            ConfigureWebAuth(app);

            var configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();
            configuration.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
            );

            // Make sure we only use bearer tokens.
            configuration.Filters.Add(
                 new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            app.UseWebApi(configuration);
        }
    }
}