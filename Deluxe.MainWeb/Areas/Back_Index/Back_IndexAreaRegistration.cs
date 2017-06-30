using System.Web.Mvc;

namespace Deluxe.MainWeb.Areas.Back_Index
{
    public class Back_IndexAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Back_Index";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Back_Index_default",
                "Back_Index/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}