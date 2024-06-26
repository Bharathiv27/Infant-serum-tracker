using Infant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infant.Controllers
{
    public class LoginController : Controller
    {
        Vaccination con = new Vaccination();
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Login s)
        {
            if (s.us == "Admin" && s.psd == "Admin123")
            {


                return RedirectToAction("AdminDash", "Dash");
            }
            else
            {
                return View();
            }
        }
        public ActionResult ParentLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ParentLogin(Login s)
        {
            int c = con.Parents.Where(m => m.MA.Equals(s.us) && m.psd.Equals(s.psd) && m.status.Equals("Active")).Count();
            if (c != 0)
            {
                TempData["Pro"] = con.Parents.Where(m => m.MA.Equals(s.us) && m.psd.Equals(s.psd)).Select(m => m.Id).FirstOrDefault();
                TempData["Baby"] = con.Parents.Where(m => m.MA.Equals(s.us) && m.psd.Equals(s.psd)).Select(m => m.CN).FirstOrDefault();
                return RedirectToAction("ParentDash", "Dash");
            }
            else
            {
                return View();
            }
        }
        public ActionResult AddParent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddParent(Parent s)
        {
            int h = con.Parents.Where(m => m.us == s.us || m.MA == s.MA).Count();
            if (h == 0)
            {
                con.Parents.Add(s);
                con.SaveChanges();
                return RedirectToAction("ParentLogin");
            }
            else
            {
                TempData["msg"] = "<script>alert('Already User Exist')</script>";
                return View();
            }

        }
    }
}