using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class DrugsController : Controller
    {
        // GET: Drugs
        public ActionResult Index()
        {
            ViewBag.Drugs = true;
            var cookie = Request.Cookies["userRole"];
            ViewBag.userRole = int.Parse(cookie.Value);
            if (ViewBag.userRole == 2) return Redirect("/PatientOfDays/Index");
            if (ViewBag.userRole == 3) return Redirect("/Patients/Index");
            if (ViewBag.userRole == 4) return Redirect("/Prescription/Index");
            return View();
        }
    }
}