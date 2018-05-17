using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM model, string ReturnUrl)
        {

            if (ModelState.IsValid)
            {
                string url = "http://localhost:6500/Service1.svc/getOneAccount?id=" + model.UserName;




                WebRequest request = WebRequest.Create(url);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                var rt = reader.ReadToEnd();

            //    Console.WriteLine(rt);

                reader.Close();
                response.Close();
                string[] Objrt = rt.Split(',');
                string[] ObjPass = rt.Split('"');



                //Code thao tác với database để kiểm tra user
                if (rt != "" && model.Password == ObjPass[13])
                {
                    url = "http://localhost:6500/Service1.svc/getEmployee?id=" + ObjPass[4].Substring(1, 1);
                    request = WebRequest.Create(url);
                    response = request.GetResponse();
                    dataStream = response.GetResponseStream();
                    reader = new StreamReader(dataStream);
                    rt = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    Objrt = rt.Split(',');
                    string[] ObjRole = rt.Split('"');
                    HttpCookie userRole = new HttpCookie("userRole");
                    userRole.Value = ObjRole[36].Substring(1, 1);
                    Response.Cookies.Add(userRole);
                    HttpCookie employeeID = new HttpCookie("employeeID");
                    employeeID.Value = ObjPass[4].Remove(0,1);
                    employeeID.Value = employeeID.Value.Remove(employeeID.Value.Length-1,1);
                    Response.Cookies.Add(employeeID);
                    //Chức năng remember me 
                    bool isRememberMe = false;
                    FormsAuthentication.SetAuthCookie(model.UserName, isRememberMe);
                    if (int.Parse(userRole.Value) == 2) return Redirect(ReturnUrl ?? "/PatientOfDays/Index");
                    return Redirect(ReturnUrl ?? "/");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác !");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thông tin nhập vào không hợp lệ !");
            }

            return View("Login", model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Login/Login");
        }
    }
}