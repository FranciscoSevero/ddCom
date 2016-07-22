using ChannelMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHM_Site_V3_RedBox.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        readonly Repository rep = new Repository();

        public ActionResult Index()
        {
            return View();
        }

        public bool ValidUser(string username, string pwd)
        {
            //apagar qnd houver servidor e usuário AD no cliente
            Session["SessionName"] = "ddCom Systems";
            return true;

            var ret = rep.CheckUser(username, pwd);            

            if (ret)
            {
                Session["SessionName"] = username;
            }

            return ret;
        }
    }
}
