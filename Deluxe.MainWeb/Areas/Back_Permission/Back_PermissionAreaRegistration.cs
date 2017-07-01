using System.Web.Mvc;

namespace Deluxe.MainWeb.Areas.Back_Permission
{
    public class Back_PermissionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Back_Permission";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Back_Permission_default",
                "Back_Permission/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}