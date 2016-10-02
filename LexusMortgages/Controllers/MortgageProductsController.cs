using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LexusMortgages.Controllers
{
    public class MortgageProductsController : Controller
    {
        // GET: MortgageProducts
        public ActionResult Index()
        {
            return View();
        }
    }
}