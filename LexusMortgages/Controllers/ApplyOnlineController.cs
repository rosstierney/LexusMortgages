using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LexusMortgages.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

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
                var body = "<p>Mortgage Enquiry From: {0} {1} <br> D.O.B: {16}</p><p>Address:<br>{3}<br>{4}<br>{5}<br>{6}<br></p>"
                   + "<p>Telephone: {7}<br>"
                   + "Martial Status: {8}<br>"
                   + "Occupation: {11}<br>"
                   + "Employer: {18}<br>"
                   + "Net Monthly Income: {12}<br>"
                   + "Other Income: {13}<br>"
                   + "Mortgage Type: {10}<br>"
                   + "Mortgage Term: {9}<br>"
                   + "Propery Type: {14}<br>"
                   + "Purchase Price: {15}<br>"
                   + "Amount Required: {17}<br></p>"
                   + "This is an automated message.<br>";

                var message = new MailMessage();
                message.To.Add(new MailAddress("info@lexusmortgages.co.uk"));  // replace with valid value 
                message.From = new MailAddress(model.email);  // replace with valid value
                message.Subject = "Mortgage Enquiry From website";
                message.Body = string.Format(body, model.fname, model.sname, model.email, model.street, model.town, model.country, model.postcode, model.telephone, model.martial, model.mortgageTerm, model.mortgageType, model.occupation, model.netMonthlyIncome, model.otherIncome, model.propertType, model.purchasePrice, model.dob, model.amountReq, model.employer);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "rosstierney@hotmail.com",  // replace with valid value
                        Password = "Corolla2016"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
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