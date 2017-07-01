using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Deluxe.MainWeb.Areas.Back_Permission.Controllers
{
    public class AuthController : Controller
    {
        // GET: Back_Permission/Auth
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}