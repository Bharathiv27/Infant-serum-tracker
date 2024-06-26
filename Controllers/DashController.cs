using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infant.Models;
using System.Data.Entity;
namespace Infant.Controllers
{
    public class DashController : Controller
    {
        Vaccination con = new Vaccination();
        public ActionResult AdminDash()
        {
            return View();
        }
        public ActionResult ParentDash()
        {
            return View();
        }
        public ActionResult parlist()
        {
            return View(con.Parents.Where(m => m.status != null).ToList());
        }

        public ActionResult parlist1()
        {
            return View(con.Parents.Where(m => m.status == null).ToList());
        }
        public ActionResult svac()
        {
            return View();
        }
        [HttpPost]
        public ActionResult svac(AddVaccine s)
        {
            con.AddVaccines.Add(s);
            con.SaveChanges();
            return RedirectToAction("svac1");
        }
        public ActionResult svac1()
        {
            return View(con.AddVaccines.ToList());
        }
        public ActionResult UserActive(int id)
        {
            var j = con.Parents.Find(id);
            j.status = "Active";
            con.SaveChanges();
            return RedirectToAction("parlist1");
        }
        public ActionResult parentprofile()
        {
            int j = Convert.ToInt32(TempData["Pro"].ToString());
            TempData.Keep();
            return View(con.Parents.Find(j));
        }
        [HttpPost]
        public ActionResult parentprofile(Parent s)
        {
            int j = Convert.ToInt32(TempData["Pro"].ToString());
            s.status = "Active";
            con.Entry(s).State = EntityState.Modified;
            con.SaveChanges();
            return RedirectToAction("parentprofile");

        }
        public ActionResult ChildrenProfile()
        {
            string k = TempData["Baby"].ToString();
            TempData.Keep();
            var d = con.Childrens.Where(m => m.CN.Equals(k)).FirstOrDefault();
            return View(d);
        }
        public ActionResult AddChild()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddChild(Children s, HttpPostedFileBase file)
        {
            int year = DateTime.Today.Year - Convert.ToDateTime(s.DOB).Year;
            s.Age = year.ToString() + "Yrs";
            string ImageName = System.IO.Path.GetFileName(file.FileName);
            string physicalPath = Server.MapPath("~/Pro/" + ImageName);
            // save image in folder
            file.SaveAs(physicalPath);
            //save new record in database
            s.Image = ImageName;
            con.Childrens.Add(s);
            con.SaveChanges();
            return RedirectToAction("AddChild");

        }
        public ActionResult vsl1()
        {
            return View(con.AddVaccines.ToList());
        }
        public ActionResult AVRD()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AVRD(vaccinedetail s)
        {
            con.vaccinedetails.Add(s);
            con.SaveChanges();
            return RedirectToAction("AdminDash");
        }
        public ActionResult CVR()
        {
            string k = TempData["Baby"].ToString();
            TempData.Keep();
            var d = con.vaccinedetails.Where(m => m.CN.Equals(k)).ToList();
            return View(d);
        }
        public ActionResult Rebook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Rebook(RebookVac f)
        {
            con.RebookVacs.Add(f);
            con.SaveChanges();
            return RedirectToAction("Rebook");
        }
        public ActionResult rebooklist()
        {
            string k = TempData["Baby"].ToString();
            TempData.Keep();
            return View(con.RebookVacs.Where(m => m.CN.Equals(k)).ToList());
        }

        public ActionResult rebooklist1()
        {
            return View(con.RebookVacs.Where(m => m.Status == null).ToList());
        }
        public ActionResult Accept(int i)
        {
            var data = con.RebookVacs.Find(i);
            data.Status = "Accept";
            con.SaveChanges();
            return RedirectToAction("rebooklist1");
        }
        public ActionResult feedbackform()
        {
            return View();
        }
        [HttpPost]
        public ActionResult feedbackform(Feedback s)
        {
            con.Feedbacks.Add(s);
            con.SaveChanges();
            return RedirectToAction("ParentDash");
        }
        public ActionResult feedlist()
        {
            return View(con.Feedbacks.ToList());
        }
        public ActionResult edit(int i)
        {
            return View(con.RebookVacs.Find(i));
        }
        [HttpPost]
        public ActionResult edit(RebookVac s)
        {
            con.Entry(s).State = EntityState.Modified;
            con.SaveChanges();
            return RedirectToAction("rebooklist");
        }
    }
}