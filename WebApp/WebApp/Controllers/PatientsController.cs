using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class PatientsController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            ViewBag.Patients= true;
            return View();
        }
    }
}