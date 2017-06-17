using EvoucherBackOffice.Web.Infrastructure;
using System.Web.Mvc;

namespace EvoucherBackOffice.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());          
        }
    }
}
