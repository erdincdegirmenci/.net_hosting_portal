
using OrionHosting.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrionHosting.Models.Entity;

namespace OrionHosting.Controllers
{

    public class LoginController : Controller
    {
        ORIONDBEntities DB = new ORIONDBEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]        
        public ActionResult Login(string username,string password)
        {
            if(new LoginState().IsLoginSuccess(username,password))
            {
                Session["username"] = username;
                return RedirectToAction("Index", "Default");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }            
        }      

        public ActionResult Quit()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
        
    }
}