using ChannelMonitor.Models;
using CHM_Site_V3_RedBox.Models;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CHM_Site_V3_RedBox.Controllers
{
    public class DetalhesSiteController : Controller
    {
        //
        // GET: /DetalhesSite/

        static Repository rep = new Repository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetIdle()
        {
            var siteIdle = Session["siteIdle"];
            var siteConext = new SiteContext
            {
                id_site = ((SiteContext) (siteIdle)).id_site,
                id_plataforma = ((SiteContext) (siteIdle)).id_plataforma,
                id_gravador = ((SiteContext) (siteIdle)).id_gravador,
                id_status = ((SiteContext) (siteIdle)).id_status,
                site = ((SiteContext) (siteIdle)).site
            };



            return Json(new
            {
                model = rep.GetIdle(siteConext)
        }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool ChangeStatus(string context)
        {
            var _context = new JavaScriptSerializer().Deserialize<NewStatus>(context);
            return rep.ChangeStatus(_context);
        }

    }
}
