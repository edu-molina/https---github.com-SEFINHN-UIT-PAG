using System;
using System.Security.Claims;
using System.Web.Mvc;
using Sefin.Security.Interfaces;
using System.Configuration;

namespace Sefin.Security.Mvc
{
    public class ActionMvc:IAction
    {
        private readonly Controller _controller;

        public ActionMvc(Controller controller )
        {
            _controller = controller;
        }

        public string getName()
        {
            return buildActionFrom(_controller);
        }
        private static string buildActionFrom(Controller controller)
        {
            var request = controller.Request;

            var nameBase = getNameBase(controller);
            var url = createUrl(controller);
            var method = request.HttpMethod;
            var nameSpaces = Constantes.SeguridadMVC.PAGOS + '.' + nameBase + '.' + Constantes.SeguridadMVC.APP;

            return String.Format("{2}.{1}[{0}]", method, url, nameSpaces);
        }

        private static string getNameBase(Controller controller)
        {
            var getFullName = controller.GetType().BaseType.FullName;
            var baseName = getFullName.Substring(0, getFullName.IndexOf('.'));
            return baseName;
        }


        private static string createUrl(Controller controller)
        {
            var routeData = controller.RouteData;
            var nameController = routeData.Values["controller"].ToString().ToUpper();
            var action = routeData.Values["action"].ToString().ToUpper();
            {
                return string.Format("{0}.{1}", nameController, action);
            }
        }
    }

    public class UserMvc : IUser
    {
        private readonly Controller _controller;
        private SefinClaims sefinClaims = new SefinClaims();

        public UserMvc(Controller controller)
        {
            _controller = controller;
        }


        public bool IsAuthenticated { get { return _controller.User.Identity.IsAuthenticated; } }
        public string Name { get { return _controller.User.Identity.Name; } }
        public UsuarioClaim getClaims()
        {
            return sefinClaims.setClaims(((ClaimsPrincipal)_controller.User).Claims);
        }
    }
}
