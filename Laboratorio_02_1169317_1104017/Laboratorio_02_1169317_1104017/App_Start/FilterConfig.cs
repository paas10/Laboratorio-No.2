using System.Web;
using System.Web.Mvc;

namespace Laboratorio_02_1169317_1104017
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
