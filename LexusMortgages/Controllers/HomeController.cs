using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LexusMortgages.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MortgageProcess()
        {
            ViewBag.Message = "Your Mortgage Process page.";

            return View();
        }

        public ActionResult ApplyOnline()
        {
            ViewBag.Message = "Your Apply Online page.";

            return View();
        }

       
    }
}