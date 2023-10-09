using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SefinMvcHelpers.Helpers
{
    public static class HelperExtension
    {
        public static MyHelper<T> AdditionalHelper<T>(this HtmlHelper<T> helper)
        {
            return new MyHelper<T>(helper);
        }
    }
}