using OrionHosting.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrionHosting.Login
{
    public class Yetki : AuthorizeAttribute
    {
        ORIONDBEntities DB = new ORIONDBEntities();
        private readonly List<string> _allowedroles = new List<string>();
        public Yetki()
        {
            List<string> roles = new List<string>(); // Rolleri oluşturturuyoruz
            roles.Add("Admin");
            roles.Add("user");
            _allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var role in _allowedroles) 
            {
                if (role == "Admin") 
                {
                    authorize = true; 
                    return authorize;
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

    }
}