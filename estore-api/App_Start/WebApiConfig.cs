using System;
using System.Collections.Generic;
using System.Linq;
using estore_model;
using System.Web.Http;
using System.Web.OData.Extensions;
using System.Web.OData.Builder;
using Microsoft.OData.Edm;
using estore_repository;

namespace estore_api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

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
        }

    }
}
