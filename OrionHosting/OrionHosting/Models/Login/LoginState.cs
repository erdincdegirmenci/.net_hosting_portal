using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrionHosting.Models.Entity;

namespace OrionHosting.Models.Login
{
    public class LoginState
    {
        private Models.Entity.ORIONDBEntities DB;
        public LoginState()
        {
            DB = new Models.Entity.ORIONDBEntities();
        }
        public bool IsLoginSuccess(string user,string pass)
        {
            TBLLOG resultUser = DB.TBLLOG.Where(x => x.userNAME.Equals(user) && x.userPASS.Equals(pass)).FirstOrDefault();
         
            if (resultUser!=null)
            {               
                DB.Entry(resultUser).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                HttpContext.Current.Session.Add("UserID",resultUser.userID.ToString());
                return true;
            }            
            return false;
        }
        


    }
}