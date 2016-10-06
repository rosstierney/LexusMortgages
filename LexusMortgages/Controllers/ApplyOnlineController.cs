using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LexusMortgages.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Web.Configuration;

namespace LexusMortgages.Controllers
{

    public class ApplyOnlineController : Controller
    {
     
        // GET: ApplyOnline
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.MartialOptions = new List<Object>{
                       new { value = "Single" , text = "Single"  },
                       new { value = "Married" , text = "Married"  },
                       new { value = "Divorced", text = "Divorced" },
                       new { value = "Separated" , text = "Separated"},
                       new { value = "Widow(er)", text = "Widow(er)"}};
            ViewBag.MortgageTyOptions = new List<Object>{
                       new { value = "Home Purchase" , text = "Home Purchase"  },
                       new { value = "Remortgage" , text = "Remortgage"  },
                       new { value = "Equity Release", text = "Equity Release" }};
            ViewBag.MortgageTmOptions = new List<Object>{
                       new { value = "5 years" , text = "5 years"  },
                       new { value = "10 years" , text = "10 years"  },
                       new { value = "15 years", text = "15 years" },
                       new { value = "20 years" , text = "20 years"},
                       new { value = "30 years", text = "30 years"}};
            ViewBag.PropertyOptions = new List<Object>{
                       new { value = "Appartment" , text = "Appartment"  },
                       new { value = "House" , text = "House"  },
                       new { value = "Detached Villa", text = "Detached Villa" }};
            return View();
        }
        // POST: ApplyOnline
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ApplyOnline model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Mortgage Enquiry From: {0} {1} <br> D.O.B: {13}</p><p>Address:<br>{3}<br></p>"
                   + "<p>Telephone: {4}<br>"
                   + "Has found property?: {16}<br>"
                   + "Martial Status: {5}<br>"
                   + "Occupation: {8}<br>"
                   + "Employer: {15}<br>"
                   + "Net Monthly Income: {9}<br>"
                   + "Other Income: {10}<br>"
                   + "Mortgage Type: {7}<br>"
                   + "Mortgage Term: {6}<br>"
                   + "Propery Type: {11}<br>"
                   + "Purchase Price: {12}<br>"
                   + "Amount Required: {14}<br></p>"
                   + "This is an automated message.<br>";

                var message = new MailMessage();
                message.To.Add(new MailAddress("info@lexusmortgages.co.uk"));  // replace with valid value 
                message.From = new MailAddress(model.email);  // replace with valid value
                message.Subject = "Mortgage Enquiry From website";
                message.Body = string.Format(body, model.fname, model.sname, model.email, model.address, model.telephone, model.martial, model.mortgageTerm, model.mortgageType, model.occupation, model.netMonthlyIncome, model.otherIncome, model.propertyType, model.purchasePrice, model.dob, model.amountReq, model.employer, model.hasProperty);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    smtp.UseDefaultCredentials = false;
                    var credential = new NetworkCredential
                    {
                        UserName = "info@lexusmortgages.co.uk",  // replace with valid value
                        Password = "Jesuschrist15"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.live.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
                return View(model);
        }
        public ActionResult Sent(ApplyOnline model)
        {
            ViewBag.Message = "Your sent email page.";
            ViewBag.mail = model.email;
            return View(model);
        }
     
    }

}