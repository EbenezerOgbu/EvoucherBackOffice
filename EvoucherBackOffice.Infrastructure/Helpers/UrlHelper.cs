using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EvoucherBackOffice.Infrastructure.Helpers
{
    public static class UrlHelper
    {
        public static string Resolve(string resource)
        {
            return string.Format("{0}://{1}{2}{3}",
                  HttpContext.Current.Request.Url.Scheme,
                  HttpContext.Current.Request.ServerVariables["HTTP_HOST"],
                  (HttpContext.Current.Request.ApplicationPath.Equals("/")) ? string.Empty : HttpContext.Current.Request.ApplicationPath, resource);
        }
    }
}
