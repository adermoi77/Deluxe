using System.Web.Mvc;

namespace Deluxe.MainWeb.Areas.Front_Index
{
    public class Front_IndexAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Front_Index";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Front_Index_default",
                "Front_Index/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}