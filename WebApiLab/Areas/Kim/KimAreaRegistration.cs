using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApiLab.Areas.Kim
{
    public class KimAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Kim";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Kim_default",
                "Kim/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            //自訂api,順序為area-->上層default
            context.Routes.MapHttpRoute(
name: "KimAreaAPI",
routeTemplate: "api/kim/{controller}/{id}",
defaults: new { id = RouteParameter.Optional }
);

        }
    }
}