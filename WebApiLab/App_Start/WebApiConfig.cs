using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiLab
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
name: "AreaAPI",
routeTemplate: "api/{area}/{controller}/{id}",
defaults: new { id = RouteParameter.Optional }
, constraints: new { area = @"\w{3}" }//限定Area才吃此設定，防put 404 error
);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
