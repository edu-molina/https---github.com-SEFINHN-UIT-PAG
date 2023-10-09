using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PAG_DTO;
using PAG_INTERFACES;
using Sefin.Security;

namespace PAG.Controllers
{
    [Authorize]
    public class LibBolsonFteController : BaseController
    {
        /// <summary>
        /// codigo de operaciones que solo tienen acceso a este controller.
        /// </summary>
        /// 
        iPAG_Services _service;
        public Models.Funciones fRef = new Models.Funciones();
        public ISecurityManager Security { get; set; }
        public LibBolsonFteController()
        {

        }
        public LibBolsonFteController(iPAG_Services service)
        {
            this._service = service;
        }
        public int[] idFlujosOperacionesController
        {
            get { return new int[] { 243, 244, 245 }; }
        }
        // GET: LibBolsonFte
        [HttpGet]
        public ActionResult Index()
        {
            // verificaPerfiles();           
            return View("AngularShared");
        }

        [HttpGet]
        public ActionResult LibBolsonFte()
        {
            // verificaPerfiles();           
            return PartialView("");
        }
        [HttpGet]
        public JsonResult LibBolsonFteList()
        {
            //verificaPerfiles();
            List<PRG_LIBRETAS_BOLSON_DTO> LibBolsonFte = new List<PRG_LIBRETAS_BOLSON_DTO>();
            //try
            //{
                var seguridad = ((SAS_DTO.AUX_SEGURIDAD_DTO)System.Web.HttpContext.Current.Session["Permisos"]);
                var gestion = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_GESTION"]).VALOR.ToString());
                var institucion = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_INSTITUCION"]).VALOR.ToString());
                var ga = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_GA"]).VALOR.ToString());
                LibBolsonFte = _service.qry_PRG_LIBRETAS_BOLSON_listado();
                if (LibBolsonFte.Count != 0) { LibBolsonFte = LibBolsonFte.Where(col => col.API_ESTADO != "ELIMINADO" && col.GESTION == gestion
                                                                                 && col.INSTITUCION == institucion && col.GA == ga).ToList(); }
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(LibBolsonFte, JsonRequestBehavior.AllowGet);
        }
    }
}