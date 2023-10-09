using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAG_DTO;
using PAG.Helpers;
using PAG_INTERFACES;
using Sefin.Security;

namespace PAG.Controllers
{
    [Authorize]
    public class TiposProgramController : BaseController
    {
        /// <summary>
        /// codigo de operaciones que solo tienen acceso a este controller.
        /// </summary>
        iPAG_Services _service;
        public Models.Funciones fRef = new Models.Funciones();
        public ISecurityManager Security { get; set; }
        public TiposProgramController()
        {

        }
        public TiposProgramController(iPAG_Services service)
        {
            this._service = service;
        }
        // GET: TiposProgram
        [HttpGet]
        public ActionResult Index()
        {
            // verificaPerfiles();           
            return View("AngularShared");
        }

        [HttpGet]
        public ActionResult TiposProgram()
        {
            return PartialView();
        }
        [HttpGet]
        public JsonResult TiposProgramList()
        {
            List<TPR_TIPOS_PROGRAMACION_DTO> TiposProgram = new List<TPR_TIPOS_PROGRAMACION_DTO>();
            //try
            //{
                var seguridad = ((SAS_DTO.AUX_SEGURIDAD_DTO)System.Web.HttpContext.Current.Session["Permisos"]);
                var gestion = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_GESTION"]).VALOR.ToString());
                var institucion = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_INSTITUCION"]).VALOR.ToString());
                var ga = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_GA"]).VALOR.ToString());

                TiposProgram = _service.qry_TPR_TIPOS_PROGRAMACION_listado();
                if (TiposProgram.Count != 0) { TiposProgram = TiposProgram.Where(col => col.API_ESTADO != "ELIMINADO" && col.INSTITUCION == institucion && col.GA == ga ).ToList(); }
                ViewBag._TipoOperacion = fRef.slDominios(Models.Dominios.TIPO_OPERACION);
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(TiposProgram, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult TprDocumentosConsulta(short idInstitucion, short idGa, short idTipoProgramacion)
        {
            List<TPR_DOCUMENTOS_DTO> tprDocumentos = new List<TPR_DOCUMENTOS_DTO>();
            //try
            //{
                tprDocumentos = _service.qry_TPR_DOCUMENTOS_filtrado(new TPR_DOCUMENTOS_DTO { INSTITUCION = idInstitucion, GA = idGa, TIPO_PROGRAMACION = idTipoProgramacion });
                if (tprDocumentos.Count != 0) { tprDocumentos = tprDocumentos.Where(col => col.API_ESTADO != "ELIMINADO" ).ToList(); }
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(tprDocumentos, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult TprDetallesConsulta(short idInstitucion, short idGa, short idTipoProgramacion, short idSecDocumento)
        {
            List<TPR_DETALLES_DTO> tprDetalles = new List<TPR_DETALLES_DTO>();
            //try
            //{
                var seguridad = ((SAS_DTO.AUX_SEGURIDAD_DTO)System.Web.HttpContext.Current.Session["Permisos"]);
                var gestion = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_GESTION"]).VALOR.ToString());

                tprDetalles = _service.qry_TPR_DETALLES_filtrado(new TPR_DETALLES_DTO { INSTITUCION = idInstitucion, GA = idGa, TIPO_PROGRAMACION = idTipoProgramacion, SECUENCIA_DOC = idSecDocumento });
                if (tprDetalles.Count != 0) { tprDetalles = tprDetalles.Where(col => col.API_ESTADO != "ELIMINADO" && col.GESTION == gestion).ToList(); }
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(tprDetalles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DocTiposProgramCrearCargar(string idTipoOperacion = "")
        {
           // verificaPerfiles();
            DTP_TIPOS_PROGRA_CAB_DTO DocTipPrg = new DTP_TIPOS_PROGRA_CAB_DTO();
            //try
            //{
            // if (string.IsNullOrEmpty(idTipoOperacion))
            //idTipoOperacion = "A";
            // ViewBag._idTipoOperacion = string.IsNullOrEmpty(idTipoOperacion) ? "A" : idTipoOperacion;
            DocTipPrg = inicializarDocTipPrg(new DTP_TIPOS_PROGRA_CAB_DTO() { TIPO_OPERACION = idTipoOperacion });
            //institucion
            INSTITUCIONES_DTO vrecInst = null;
            vrecInst = _service.qry_INSTITUCIONES_filtrado(new INSTITUCIONES_DTO { INSTITUCION = DocTipPrg.INSTITUCION }).FirstOrDefault();
            DocTipPrg.DESC_INSTITUCION = vrecInst.DESC_INSTITUCION;
            // GA
            GERENCIAS_ADMINISTRATIVAS_DTO vrecGA = null;
            vrecGA = _service.qry_GERENCIAS_ADMINISTRATIVAS_filtrado(new GERENCIAS_ADMINISTRATIVAS_DTO { INSTITUCION = DocTipPrg.INSTITUCION, GA = DocTipPrg.GA }).FirstOrDefault();
            DocTipPrg.DESC_GA = vrecGA.DESC_GA;
            // Lugar
            MUNICIPIOS_DTO vrecMun = null;
            vrecMun = _service.qry_MUNICIPIOS_filtrado(new MUNICIPIOS_DTO { DEPARTAMENTO = DocTipPrg.DPTO_LUGAR, MUNICIPIO = DocTipPrg.MUN_LUGAR }).FirstOrDefault();
            DocTipPrg.DESC_LUGAR = vrecMun.DESC_MUNICIPIO;
            DocTipPrg.NRO_DOCUMENTO = -1;
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(DocTipPrg, JsonRequestBehavior.AllowGet);
        }
        private DTP_TIPOS_PROGRA_CAB_DTO inicializarDocTipPrg(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {   // inicializar formulario
            var seguridad = ((SAS_DTO.AUX_SEGURIDAD_DTO)System.Web.HttpContext.Current.Session["Permisos"]);

            if (seguridad.detalleGrupo == null)
            {
                precDto.GESTION = 2016;
                precDto.INSTITUCION = 449;
                precDto.GA = 1;
            }
            else
            {
                precDto.GESTION = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_GESTION"]).VALOR.ToString());
                precDto.INSTITUCION = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_INSTITUCION"]).VALOR.ToString());
                precDto.GA = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_GA"]).VALOR.ToString());
            }
            precDto.DPTO_LUGAR = 8;
            precDto.MUN_LUGAR = 1;
            precDto.API_ESTADO = "INICIAL";
            precDto.API_TRANSACCION = "CREAR";
            precDto.USU_CRE = User.Identity.Name;
            precDto.FEC_CRE = DateTime.Now;
            return precDto;
        }
    }
}

