using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.DynamicProxy;
using Microsoft.AspNet.SignalR.Hubs;
using PAG.App_Start;
using Sefin.Security;
using Sefin.Security.Mvc;
using System.Web.Http;
using PAG.Helpers;
using FilterProvider;
using System.Web.Optimization;

namespace PAG
{
    public class MvcApplication : System.Web.HttpApplication
    {
        void Session_Start(object sender, EventArgs e)
        {
            HttpContext.Current.Session["Permisos"] = null;
            System.Web.HttpContext.Current.Session["Claims"] = null;
            //System.Web.HttpContext.Current.Session["Estructura"] = null;

            //System.Web.Helpers.AntiForgeryConfig.UniqueClaimTypeIdentifier = System.IdentityModel.Claims.ClaimTypes.NameIdentifier;

            //Session["Permisos"] = "";
        }
        //void Application_Error(object sender, EventArgs e)
        //{

        //    var mensaje = HelperHandlerException.trackingLog(Server.GetLastError());
        //    var url = HelperHandlerException.getUrl("/Home/InternalServerError?mensaje=" + mensaje);
        //    Response.Redirect(url);



        //}
        protected void Application_Start()
        {

            AutoFacConfig.Config();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterProviders.Providers.Add(new ConfiguredFilterProvider());
        }
        //protected void Application_End()
        //{
        //    DependencyResolverConfig.Dispose();
        //}

    }
}
