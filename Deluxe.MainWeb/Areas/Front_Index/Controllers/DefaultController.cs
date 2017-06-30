using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Deluxe.MainWeb.Areas.Front_Index.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Front_Index/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}