using Infant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Infant.Controllers
{
    public class HomeController : Controller
    {
        Vaccination con = new Vaccination();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult send()
        {
            var g = con.RebookVacs.ToList();
            foreach (var item in g)
            {
                int j = Convert.ToDateTime(item.VD).Day - DateTime.Today.Day;

                if(j>=3)
                {
                    try
                    {
                        MailMessage message = new MailMessage();
                        SmtpClient smtp = new SmtpClient();
                        message.From = new MailAddress("vijayproject2023@gmail.com");
                        message.To.Add(new MailAddress(item.MA));
                        message.Subject = "Vaccination Camp Remainder Notification";
                        message.IsBodyHtml = true; //to make message body as html  
                        message.Body = "Thanks for the Booking Your Vaccination through this webapplication<br/>Name of the Baby is " + item.CN + "<br/>Date of Schedule is " + item.VD + "<br/> Place of Vaccination Center " + item.Loc;
                        smtp.Port = 587;
                        smtp.Host = "smtp.gmail.com"; //for gmail host  
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("vijayproject2023@gmail.com", "lnopyipnkzjwnqmq");
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(message);
                    }
                    catch
                    {
                        throw null;
                    }
                }

            }
            return RedirectToAction("Index");

        }
    }
}