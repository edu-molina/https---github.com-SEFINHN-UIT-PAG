using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR.Messaging;
using PAG.Helpers;
using Sefin.Security;
using Sefin.Security.Mvc;
using Message = System.ServiceModel.Channels.Message;

namespace PAG.Filters
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        //private readonly ISecurityManager _securityManager =  DependencyResolver.Current.GetService<ISecurityManager>();
        public ISecurityManager SecurityManager { get; set; }

       void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            var error = filterContext.Exception as FaultException;
            if (error != null)
            {
                var codeInt = 0;
                var s = int.TryParse(error.Code.Name, out codeInt);
                var mensajeError = error.Message;
                if (s)
                {
                    codeInt = codeInt < 0 ? codeInt * -1 : codeInt;
                    throw new HttpException(codeInt, mensajeError);
                }
                //else
                //{
                //    var codeString = error.Code.Name;
                //    throw new HttpException(500, mensajeError);
                //}
                ////code = code < 0 ? code*-1 : code;

            }
            filterContext.Controller.ViewBag.OnActionExecuted = "IActionFilter.OnActionExecuted filter called";
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            var validate = SecurityManager.configureWith(new UserMvc(controller)).validate(new ActionMvc(controller));

            if (!validate)
            {

                throw new HttpException(401, "No autorizado");
            }
            filterContext.Controller.ViewBag.OnActionExecuting = "IActionFilter.OnActionExecuting filter called";
        }
    }
}