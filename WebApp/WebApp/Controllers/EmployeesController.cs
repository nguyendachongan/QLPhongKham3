using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            ViewBag.Employees = true;
            var cookie = Request.Cookies["userRole"];
            ViewBag.userRole = int.Parse(cookie.Value);

            var employeeID = Request.Cookies["EmployeeID"];
            ViewBag.employeeID = int.Parse(employeeID.Value);
            return View();
        }
    }
}