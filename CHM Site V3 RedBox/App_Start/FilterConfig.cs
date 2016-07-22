using System.Web;
using System.Web.Mvc;

namespace CHM_Site_V3_RedBox
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}