using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class PatientOfDaysController : Controller
    {
        // GET: PatientOfDay
        public ActionResult Index()
        {
            ViewBag.PatientOfDays = true;
            var cookie = Request.Cookies["userRole"];
            ViewBag.userRole = int.Parse(cookie.Value);

            var employeeID = Request.Cookies["EmployeeID"];
            ViewBag.employeeID = int.Parse(employeeID.Value);

            if (ViewBag.userRole == 1) return Redirect("/Drugs/Index");
            if (ViewBag.userRole == 3) return Redirect("/Patients/Index");
            if (ViewBag.userRole == 4) return Redirect("/Prescription/Index");
            return View();
        }
    }
}