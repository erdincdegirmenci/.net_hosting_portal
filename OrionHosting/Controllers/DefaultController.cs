using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using OrionHosting.Login;
using OrionHosting.Models.Entity;

namespace OrionHosting.Controllers
{
    [Yetki(Roles = "Admin")]
    [ControlLogin]

    public class DefaultController : Controller
    {
        // GET: Default
        ORIONDBEntities DB = new ORIONDBEntities();
     
        public ActionResult Index()
        {
            //KALANGÜNSAYISIHESAP
            //var result = from i in DB.TBLDOMAIN
            // select SqlMethods.DateDiffDay(i.domainHBS, i.domainHBT);
            var result = DB.TBLDOMAIN.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Newdomain()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult Newdomain(TBLDOMAIN p1)
        {
            DB.TBLDOMAIN.Add(p1);
            DB.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
        [HttpGet]
        public ActionResult DomainList(string p)
        {
            var variable = from v in DB.TBLDOMAIN select v;
            if(!string.IsNullOrEmpty(p))
            {
                variable = variable.Where(m => m.domainNAME.Contains(p) || m.domainSELLER.Contains(p));
            }
            return View(variable.ToList());
        }
        [HttpPost]
        public ActionResult DomainList(DateTime p)
        {
            var variable = from v in DB.TBLDOMAIN where v.domainDBS >= DateTime.Today && v.domainDBS <= p select v;
            return View(variable.ToList());
        }
       
        public ActionResult domainUptade(int id)
        {
            var variable = DB.TBLDOMAIN.Find(id);
            return View("domainUptade",variable);
        }
        public ActionResult domainU(TBLDOMAIN p2)
        {
            var variable = DB.TBLDOMAIN.Find(p2.domainID);
            variable.domainNAME = p2.domainNAME;
            variable.domainDBS = p2.domainDBS;
            variable.domainDBT = p2.domainDBT;
            variable.domainCUSTOMER = p2.domainCUSTOMER;
            variable.domainDETAIL = p2.domainDETAIL;
            variable.domainHBS = p2.domainHBS;
            variable.domainHBT = p2.domainHBT;
            variable.domainSELLER = p2.domainSELLER;
            DB.SaveChanges();
            return RedirectToAction("DomainList", "Default");

        }
        
    }
}