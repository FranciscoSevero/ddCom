using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHM_Site_V3_RedBox.Controllers
{
    public class HelperController : Controller
    {
        //
        // GET: /Helper/

        public string GetSessionName()
        {
            return Session["SessionName"].ToString();
        }

    }
}
