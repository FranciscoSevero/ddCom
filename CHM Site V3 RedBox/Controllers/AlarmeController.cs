using ChannelMonitor.Models;
using CHM_Site_V3_RedBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHM_Site_V3_RedBox.Controllers
{
    public class AlarmeController : Controller
    {
        //
        // GET: /Servidores/

        static Repository rep = new Repository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public bool TestConnection()
        {
            return rep.TestConnection();
        }

        [HttpPost]
        public JsonResult GetIdle()
        {           
            var error = -1;
            var msg = "Não foi possível conectar na base de dados";
            var connected = false;
            var ret = new List<SiteContext>();
            

            try
            {
                connected = rep.TestConnection();

                if (connected)
                {
                    error = 0;
                    msg = "Busca realizada com sucesso.";
                    ret = rep.Situacao();
                }
                else
                {
                    error = -1;
                    msg = "Não foi possível conectar na base.";                    
                }
            }
            catch (Exception ex)
            {
                error = -2;
                msg = ex.Message;
            }            

            return Json(new
            {
                error = error,
                message = msg,
                models = ret
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SendIdle(SiteContext site)
        {            
            Session["siteIdle"] = site;
        }

    }
}
