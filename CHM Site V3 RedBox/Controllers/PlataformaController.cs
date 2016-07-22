using ChannelMonitor.Models;
using CHM_Site_V3_RedBox.Models;
using ModelChannelMonitor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHM_Site_V3_RedBox.Controllers
{
    public class PlataformaController : Controller
    {
        //
        // GET: /Plataforma/

        static Repository rep = new Repository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void SendSite(tbl_RamalEmAnalise site)
        {
            Session["site"] = site;
        }

        [HttpPost]
        public bool SavePlataforma(string plataforma)
        {
            var _plataforma = JsonConvert.DeserializeObject<tbl_Plataforma>(plataforma);            
            var site = Session["site"];
            _plataforma.id_site = ((ModelChannelMonitor.tbl_Sites)(site)).id_site;

            return rep.SavePlataforma(_plataforma);
        }

        [HttpGet]
        public bool TestConnectionPlataforma(string instanciaSql, string usuarioSql, string senhaSql)
        {            
            return rep.TestConnectionPlataforma(instanciaSql, usuarioSql, senhaSql);
        }
    }
}
