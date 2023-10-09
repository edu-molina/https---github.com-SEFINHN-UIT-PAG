using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Castle.DynamicProxy;
using Serilog;

namespace PAG.Helpers
{
    public class HelperActionMethods
    {
        public static string ActionMethods(Type type, MethodInfo methodInfo)
        {
            var url = "";
            var method = CustomAttributeData.GetCustomAttributes(methodInfo);

            if (methodInfo.Name == "Equals") return url;

            var nameAction = (method.Count == 0) ? "GET" : (method.FirstOrDefault().AttributeType.Name == "HttpPostAttribute") ? "POST" : "GET";
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.RollingFile(@"\logs\PAG-Actions-{Date}.txt")
                    .CreateLogger();
            url = string.Format("[{0}]/{1}/{2}", nameAction.ToUpper(), type.Name.Replace("Controller", "").ToUpper(), methodInfo.Name.ToUpper());
            Log.Information(url);
            Log.CloseAndFlush();
            return url;
        }
    }

    public class HelperHandlerException
    {
        //private static readonly ILog log = LogManager.GetLogger("LoggerError");
        public static string trackingLog(Exception exception)
        {
            var id = DateTime.Now.ToString("hh-mmss");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile(@"\logs\PAG-{Date}-" + id + ".txt")
                .CreateLogger();

            Log.Information("Error Controlado!!!");
            Log.Error(exception, "Algo ha salido mal");
            Log.CloseAndFlush();

            var mensaje = "Ocurrio un problema, referencia " + id;
            //log.Error("id->" + id, exception);
            return mensaje;
        }

        public static void handleException(ExceptionContext filterContext, string url, string mensaje)
        {
            var action = filterContext.RouteData.Values["action"].ToString();
            var type = filterContext.Controller.GetType();
            var method = type.GetMethod(action);
            var returnType = method.ReturnType;

            if (returnType == typeof(ActionResult))
            {
                filterContext.Result = getReturnValueWith(url);
                filterContext.ExceptionHandled = true;
            }
            else if (returnType == typeof(JsonResult))
            {
                var controller = filterContext.Controller as Controller;

                controller.HttpContext.Response.Clear();
                filterContext.ExceptionHandled = true;
                controller.HttpContext.Response.TrySkipIisCustomErrors = true;
                var errCode = ((HttpException) filterContext.Exception).GetHttpCode();
                if (errCode >= 400)
                {
                    controller.HttpContext.Response.StatusCode = 399; // System.Net.HttpStatusCode.InternalServerError;
                    controller.HttpContext.Response.StatusDescription = filterContext.Exception.Message + " " + mensaje;
                }
                else
                {
                    controller.HttpContext.Response.StatusCode = (int) errCode;
                    controller.HttpContext.Response.StatusDescription = filterContext.Exception.Message;
                }

                filterContext.Result = filterContext.Result = new JsonResult()
                {
                    ContentType = "application/json",
                    ContentEncoding = System.Text.Encoding.UTF8,
                    Data = controller.ActionInvoker.json(),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                filterContext.Result.ExecuteResult(filterContext);
            }
            else
            {
                var controller = filterContext.Controller as Controller;
                controller.HttpContext.Response.Clear();
                controller.HttpContext.Response.TrySkipIisCustomErrors = true;
                controller.HttpContext.Response.ContentType = "text/html";

                controller.HttpContext.Response.Write(
                    string.Format("<script type='text/javascript'>window.parent.location.href = '{0}';</script>", getUrl(mensaje)));
            }

        }
        public static ContentResult getReturnValueWith(string partialUrl)
        {

            var address = getUrl(partialUrl);
            return new ContentResult
            {
                Content = string.Format("<script type='text/javascript'>window.parent.location.href = '{0}';</script>", address),
                ContentType = "text/html"
            };
        }

        public static string getUrl(string partialUrl)
        {
            var url = HelperPathUrl.getUrl();
            return string.Format("{0}" + partialUrl, url);
        }
    }
}