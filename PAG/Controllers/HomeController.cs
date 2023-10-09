using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEFIN.FWK.STS.OWIN;
using Sefin.Security;
using FPE_INTERFACES;
using Sefin.Security.Mvc;
using FPE_DTO;
using PAG.Models;
using System.Diagnostics;

namespace PAG.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISecurityManager SecurityManager;
        public IFPE_Services ServicePhoto { get; private set; }

        public HomeController() { }
        public HomeController(IFPE_Services servicePhoto, ISecurityManager securityManager)
        {
            ServicePhoto = servicePhoto;
            SecurityManager = securityManager;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {            
            return View();
        }

        [Authorize]
        public ActionResult login()
        {
            SecurityManager.configureWith(new UserMvc(this));
            return View("Index");
        }
        public ActionResult logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            SecurityManager.logout();
            return View("Index");
        }
        [HttpPost]
        public ActionResult setPerfil(int ID_PERFIL, string retornoUrl, int? ID_OPERACION = null)
        {

            SecurityManager
                .configureWith(new UserMvc(this))
                .changeProfile(new Profile(User.Identity.Name, ID_PERFIL, User.Identity.IsAuthenticated));

            return RedirectToAction("Index");
            //return Redirect(retornoUrl);
        }
        [HttpGet]
        public ActionResult imageUser()
        {
            var path = Server.MapPath("~/Images/user.png");
            var picture = System.IO.File.ReadAllBytes(path);

            var id = string.Empty;

            if (User.Identity.IsAuthenticated)
            {
                id = User.Identity.Name;
            }

            var results =
                   ServicePhoto.qry_FPE_FOTOEMPLEADO_filtrado(new FPE_FOTOEMPLEADO_DTO()
                   {
                       Identidad = id
                   });

            if (results.Count != 0)
            {
                var foto = results.FirstOrDefault();
                picture = foto.FotoEmpleado;
            }

            return File(picture, "image/png", "imageUser.png");
        }
        public ActionResult GetMenu(object valor)
        {
            List<AUX_MENU_DTO> RID_Menus = new List<AUX_MENU_DTO>();
            if (User.Identity.IsAuthenticated)
            {
                return Json(consultarMenus(SecurityManager.securityInfo.Menus), JsonRequestBehavior.AllowGet);
            }
            return Json(RID_Menus, JsonRequestBehavior.AllowGet);
        }
        public List<AUX_MENU_DTO> consultarMenus(List<SAS_DTO.SAS_MENUS_DTO> menus)
        {
            List<AUX_MENU_DTO> RID_Menus = new List<AUX_MENU_DTO>();


                foreach (var menu in menus)
                {
                    string urlMetodo = "";
                    if (menu.METODO != null)
                    {
                        //Debug.WriteLine(menu.METODO.Split('/')[0] +"@"+ menu.METODO.Split('/')[1]);
                        var urlBuilder =
                        new System.UriBuilder(Request.Url.AbsoluteUri)
                        {
                            Path = Url.Action(menu.METODO.Split(',')[0], menu.METODO.Split(',')[1]),
                            Query = null,
                        };
                        Uri uri = urlBuilder.Uri;
                        urlMetodo = urlBuilder.ToString();
                    }

                    RID_Menus.Add(new AUX_MENU_DTO() { ID_MENU = menu.ID_MENU, ID_MENU_PADRE = menu.ID_MENU_PADRE, DESC_MENU = menu.DESC_MENU, ORDEN = menu.ORDEN, JERARQUIA = menu.JERARQUIA, METODO = urlMetodo.Replace("%3F", "?"), ICO_MENU = menu.ICO_MENU });
                }

            return RID_Menus;
        }
        public ActionResult InternalServerError(string mensaje = "", int codigoError = 0)
        {
            ViewBag.mensaje = string.IsNullOrEmpty(mensaje) ? "Ocurrio un problema" : mensaje;
            ViewBag.CodigoError = codigoError;
            return View();
        }
        public ActionResult NoAutorizado()
        {

            return View();
        }
    }
}