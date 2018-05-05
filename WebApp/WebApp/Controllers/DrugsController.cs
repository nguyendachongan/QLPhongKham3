﻿using System;
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
            return View();
        }
    }
}