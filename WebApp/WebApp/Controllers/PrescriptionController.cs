using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class PrescriptionController : Controller
    {
        // GET: Prescription
        public ActionResult Index()
        {
            ViewBag.Prescription = true;
            var cookie = Request.Cookies["userRole"];
            ViewBag.userRole = int.Parse(cookie.Value);
            if (ViewBag.userRole == 1) return Redirect("/Prescription/Admin");
            if (ViewBag.userRole == 2) return Redirect("/PatientOfDays/Index");
            if (ViewBag.userRole == 3) return Redirect("/Patients/Index");
            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.PrescriptionAdmin = true;
            var cookie = Request.Cookies["userRole"];
            ViewBag.userRole = int.Parse(cookie.Value);
            if (ViewBag.userRole == 4) return Redirect("/Prescription/Index");
            if (ViewBag.userRole == 2) return Redirect("/PatientOfDays/Index");
            if (ViewBag.userRole == 3) return Redirect("/Patients/Index");
            return View();
        }
    }
}