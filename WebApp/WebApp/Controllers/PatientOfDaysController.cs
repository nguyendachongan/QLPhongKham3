﻿using System;
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
            return View();
        }
    }
}