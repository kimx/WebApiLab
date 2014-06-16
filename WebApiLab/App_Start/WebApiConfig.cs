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

            //2014/06/16 若以此設定在get/put的方法會造成404，因為參數api/products/1的products對到了area,1對到了controller,id=optional
            //            config.Routes.MapHttpRoute(
            //name: "AreaAPI",
            //routeTemplate: "api/{area}/{controller}/{id}",
            //defaults: new { id = RouteParameter.Optional }
            //                //, constraints: new { area = @"\w{3}|\w{4}|\w{5}|\w{6}|\w{7}" }//限定Area才吃此設定，防put 404 error,   2014/06/16無效
            //);


            //test:http://localhost:3752/rd
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



        }
    }
}
