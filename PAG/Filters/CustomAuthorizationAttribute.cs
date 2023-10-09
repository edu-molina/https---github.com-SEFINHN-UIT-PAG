using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAG.Filters
{
    public class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            bool isValid = !(controller.User.Identity == null);

            if (isValid)
            {
                if (!controller.User.Identity.IsAuthenticated)
                {
                    throw new HttpException(401, "No autenticado");
                }
            }
            else
            {
                throw new HttpException(403, "No autorizado");
            }

            filterContext.Controller.ViewBag.OnAuthorization = "IAuthorizationFilter.OnAuthorization filter called";
        }
    }
}