using PAG.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PAG.Filters
{
    public class CustomExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
            var mensaje = HelperHandlerException.trackingLog(filterContext.Exception);

            if(filterContext.Exception is HttpException)
                if (((HttpException)filterContext.Exception).GetHttpCode() == 401) {
                    Debug.WriteLine("Usted no esta autorizado");
                    HelperHandlerException.handleException(filterContext, "/Home/NoAutorizado", "Usted no esta autorizado");
                }else
                    HelperHandlerException.handleException(filterContext, "/Home/InternalServerError?mensaje=" + mensaje, mensaje);

            filterContext.Controller.ViewBag.OnException = mensaje;
        }
    }
}