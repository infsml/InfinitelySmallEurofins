using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowLedgeHub.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(Duration = 60,VaryByParam ="*",Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult hehe()
        {
            string heheStuff = "Hehe boi";
            ViewBag.heheStuff = heheStuff;
            return View();
        }
    }
}