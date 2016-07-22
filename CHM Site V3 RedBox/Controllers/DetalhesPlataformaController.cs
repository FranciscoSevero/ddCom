using ChannelMonitor.Models;
using CHM_Site_V3_RedBox.Models;
using ModelChannelMonitor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CHM_Site_V3_RedBox.Controllers
{
    public class DetalhesPlataformaController : Controller
    {
        //
        // GET: /DetalhesPlataforma/

        Model model = new Model();
        static Repository rep = new Repository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult FindRecorders(string versao)
        {
            var ctx = Session["plataforma"];
            var plataforma = ((tbl_Plataforma)(ctx));
            var listRecorders = rep.RecordersTipoPlataforma(plataforma, versao);
            var listRecordersCad = rep.RecordersCadastrados(plataforma);

            var listRecordersDispCad = listRecorders
                                .Where(s => !listRecordersCad.Contains(s))
                                .ToList();

            return Json(new
            {                
                recordersCadastrados = listRecordersCad,
                recordersDisponiveis = listRecordersDispCad,
                plataforma = plataforma
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool SaveRecorder(string recorder)
        {
            var _recorder = JsonConvert.DeserializeObject<tbl_Gravador>(recorder);
            var ctx = Session["plataforma"];
            var plataforma = ((ModelChannelMonitor.tbl_Plataforma)(ctx));
                                    
            _recorder.id_plataforma = plataforma.id_plataforma;

            return rep.SaveRecorder(_recorder);
        }

        [HttpPost]
        public bool RemovePlataforma(tbl_Plataforma plataforma)
        {
            return rep.RemovePlataforma(plataforma);
        }        

    }
}
