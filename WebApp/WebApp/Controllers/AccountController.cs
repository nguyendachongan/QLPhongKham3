using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {

            if (ViewBag.userRole == 2) return Redirect("/PatientOfDays/Index");
            if (ViewBag.userRole == 3) return Redirect("/Patients/Index");
            if (ViewBag.userRole == 4) return Redirect("/Prescription/Index");
            return View();
        }
    }
}