using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiLab.Security;

namespace WebApiLab
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            var contractResolver = (DefaultContractResolver)GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver;
            contractResolver.IgnoreSerializableAttribute = true;

             
            GlobalConfiguration.Configuration.MessageHandlers.Add(new APIKeyHandler());//http://code.tutsplus.com/tutorials/securing-aspnet-web-api--cms-26012
        }
    }
}
