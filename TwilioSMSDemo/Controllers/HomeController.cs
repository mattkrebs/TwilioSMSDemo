using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.TwiML.Mvc;

namespace TwilioSMSDemo.Controllers
{
    public class HomeController : TwilioController
    {
        //
        // GET: /Home/

        public ActionResult Index(string phonenumber)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            //If you are using the trial version of Twilio, this will have to be your phone number that you confirmed at sign up.
            items.Add(new SelectListItem { Text = "Harison Ford", Value = "+15555555555" });
            ViewBag.PhoneNumber = items;


            TwilioHelper helper = new TwilioHelper();

            var messages = helper.GetMessages();
            if (!string.IsNullOrEmpty(phonenumber))
                return View(messages.SMSMessages.Where(m => m.To.Contains(phonenumber) || m.From.Contains(phonenumber)).OrderBy(m => m.DateSent));
            else
                return View(messages.SMSMessages.OrderBy(m => m.DateSent));
        }

       

        public ActionResult SendSMS(string message, string phonenumber)
        {
            TwilioHelper helper = new TwilioHelper();
            helper.SendSMS(phonenumber, message);

            return RedirectToAction("Index");
        }


    }
}
