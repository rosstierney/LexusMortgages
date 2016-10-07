using LexusMortgages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LexusMortgages.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        // POST: ApplyOnline
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Contact model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Mortgage Enquiry From: {0}<br>"
                    + "City: {1}<br>"
                    + "Email: {2}<br>"
                    + "Telephone: {3}<br>"
                    + "Enquiry: {4}<br></p>"
                    + "This is an automated message.<br>";

                var body1 = "<p>Dear {0},<br>"
                    + "Thank you for the interest you have shown in Lexus Mortgages. </p>"
                    + "This is an automated message.<br>";

                // send information for lexusmortgages
                var message = new MailMessage();
                message.To.Add(new MailAddress("info@lexusmortgages.co.uk"));  // lexus email // "info@lexusmortgages.co.uk"
                message.From = new MailAddress(model.email);  // users email
                message.Sender = new MailAddress(model.email); // change sender
                message.Subject = "Mortgage Enquiry From website";
                message.Body = string.Format(body, model.fullname, model.city, model.email, model.telephone, model.enquiry);
                message.IsBodyHtml = true;

                // send email back to client from LexusMortgages
                var message1 = new MailMessage();
                message1.To.Add(new MailAddress(model.email));  // user email // 
                message1.From = new MailAddress("info@lexusmortgages.co.uk");
                message1.Sender = new MailAddress("info@lexusmortgages.co.uk"); // change sender
                message1.Subject = "Confirmation Email";
                message1.Body = string.Format(body1, model.fullname);
                message1.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.ServicePoint.MaxIdleTime = 1;
                    smtp.Timeout = 10000;
                    await smtp.SendMailAsync(message);
                    await smtp.SendMailAsync(message1);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        

        public ActionResult Sent(Contact model)
        {
            ViewBag.Message = "Your sent email page.";
            ViewBag.mail = model.email;
            return View(model);
        }
    }

   

}