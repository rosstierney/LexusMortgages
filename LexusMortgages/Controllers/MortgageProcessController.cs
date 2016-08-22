﻿using LexusMortgages.Models;
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
        [ValidateAntiForgeryToken]
        public ActionResult Index(MortgageProcess model)
        {
            initDdl();

            if (ModelState.IsValid)
            {
                double loan = model.amount;
                double term = model.years;
                double cost = model.rate;
                int months = model.years * 12;
                ViewBag.answer = ((loan * (cost / 100)) * term)/months;
               
            }
            return View(model);
        }
        private void initDdl()
        {
            ViewBag.rateOptions = new List<Object>{
            new { value = 2.5, text = "2.5%"},
            new { value = 3.0, text = "3.0%"},
            new { value = 3.5, text = "3.5%"},
            new { value = 4.0, text = "4.0%"}};
        }

    }
}