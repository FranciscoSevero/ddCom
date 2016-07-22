using ChannelMonitor.Models;
using CHM_Site_V3_RedBox.Models;
using ModelChannelMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHM_Site_V3_RedBox.Controllers
{
    public class SitesController : Controller
    {
        readonly Repository rep = new Repository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSites()
        {           
            return Json(new
            {           
                sites = rep.Sites()
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SendPlataforma(tbl_Plataforma plataforma)
        {
            Session["plataforma"] = plataforma;
        }

        [HttpPost]
        public bool SaveSite(tbl_Sites site)
        {
            site.cadastro = DateTime.Now;
            return rep.SaveSite(site);
            
        }

        [HttpPost]
        public bool RemoveSite(tbl_Sites site)
        {
            return rep.RemoveSite(site);
        }
    }
}
