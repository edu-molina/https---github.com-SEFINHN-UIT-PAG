using System;
using System.Web;

namespace PAG.Helpers
{
    public class HelperPathUrl
    {
        public static string getUrl()
        {
            var url = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                      HttpContext.Current.Request.ApplicationPath;
            if (url.EndsWith("/"))
            {
                url = url.Remove(url.Length - 1);
            }
            return url;
        }
    }
}