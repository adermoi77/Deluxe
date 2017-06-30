using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Deluxe.MainWeb.Controllers
{
    public class SysMainController : Controller
    {
        // GET: SysMain
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Default", new { Areas = "Front_Index" });
        }
    }
}