using estore_api.Infrastructure;
using estore_model;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.OData.Extensions;
using System.Web.OData.Builder;

[assembly: OwinStartup(typeof(estore_api.Startup))]
namespace estore_api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Category>("category");

            config.MapODataServiceRoute(
                routeName: "category",
                routePrefix: "odata",
                model: builder.GetEdmModel());

            config.Select().Expand().Filter().OrderBy().MaxTop(null).Count();

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseOAuthAuthorizationServer(new EStoreOAuthOptions());
            app.UseJwtBearerAuthentication(new EStoreJwtOptions());

            app.UseWebApi(config);
        }
    }
}