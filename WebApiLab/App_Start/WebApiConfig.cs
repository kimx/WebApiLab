using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

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
            return;

            //2014/08/11重點為default的id約束及DefaultApiWithAction，可以使用明確的action來呼叫
            //2014/08/11看起來WebApi最好的設定方式
            //http://lonetechie.com/2013/03/04/fixing-multiple-actions-were-found-that-match-the-request-aspnet-webapi/
            config.Routes.MapHttpRoute("DefaultApiWithId", "api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
            config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{action}");
            config.Routes.MapHttpRoute("DefaultApiGet", "api/{controller}", new { action = "Get" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
            config.Routes.MapHttpRoute("DefaultApiPost", "api/{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
            config.Routes.MapHttpRoute("DefaultApiPut", "api/{controller}", new { action = "Put" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) });
            config.Routes.MapHttpRoute("DefaultApiDelete", "api/{controller}", new { action = "Delete" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) });


        }
    }
}
