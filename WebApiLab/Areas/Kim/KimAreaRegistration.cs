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

         
       
        }
    }
}