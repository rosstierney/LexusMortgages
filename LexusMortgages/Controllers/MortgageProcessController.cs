using LexusMortgages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LexusMortgages.Controllers
{
    public class MortgageProcessController : Controller
    {
        // GET: 
        [HttpGet]
        public ActionResult Index()
        {
            initDdl();
            return View();
        }
        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(MortgageProcess model)
        //{
           
        //}
        private void initDdl()
        {
            ViewBag.rateOptions = new List<Object>{
            new { value = 2.0, text = "2.0%"},
            new { value = 2.5, text = "2.5%"},
            new { value = 3.0, text = "3.0%"},
            new { value = 3.5, text = "3.5%"},
            new { value = 4.0, text = "4.0%"},
            new { value = 4.5, text = "4.5%"}};
        }

        [HttpPost]
        public PartialViewResult ShowDetails(MortgageProcess model)
        {
            initDdl();
            MortgageProcess mp = new MortgageProcess();
            if (ModelState.IsValid)
            {
                double loan = model.amount;
                double term = model.years;
                double cost = model.rate / 1200;
                int months = model.years * 12;
            //    double calresult = ((((loan * cost)) * term) + loan) / months;
                double calresult = (cost * loan) / (1 - (Math.Pow((1 + cost),(-term * 12))));
                // ViewBag.answer = ((((loan * cost) / 100)* term) + loan)/months;
             
                mp.result = calresult;
            }
           // if (Request.IsAjaxRequest())
          
            return PartialView("CalculatorView", mp);
        }

    }
}