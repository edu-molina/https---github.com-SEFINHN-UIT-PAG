using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAG_DTO;
using System.ServiceModel;
using PAG_INTERFACES;
using Sefin.Security;

namespace PAG.Controllers
{
    [Authorize]
    public partial class DocTiposProgramController : BaseController
    {
        //IEnumerable<AUX_LOVS_DTO> listTipoOperacion = new List<AUX_LOVS_DTO>();

        /// <summary>
        /// codigo de operaciones que solo tienen acceso a este controller.
        /// </summary>
        /// 
        iPAG_Services _service;
        public Models.Funciones fRef = new Models.Funciones();
        public ISecurityManager Security { get; set; }
        public DocTiposProgramController()
        {
            
        }
        public DocTiposProgramController(iPAG_Services service)
        {
            this._service = service;
        }
        public int[] idFlujosOperacionesController
        {
            get { return new int[] { 243, 244, 245 }; }
        }
        // GET: DocTiposProgram
        [HttpGet]
        public ActionResult Index()
        {
           //verificaPerfiles();           

            return View("AngularShared");
        }
        [HttpGet]
        public ActionResult DocTiposProgram()
        {
            //verificaPerfiles();

            return PartialView();
        }
        [HttpPost]
        public JsonResult DocTiposProgramList()
        {
           // verificaPerfiles();
            List<DTP_TIPOS_PROGRA_CAB_DTO> DocTipPrg = new List<DTP_TIPOS_PROGRA_CAB_DTO>();
            //try
            //{
                var seguridad = ((SAS_DTO.AUX_SEGURIDAD_DTO)System.Web.HttpContext.Current.Session["Permisos"]);
                var gestion = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_GESTION"]).VALOR.ToString());
                var institucion = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_INSTITUCION"]).VALOR.ToString());
                var ga = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_GA"]).VALOR.ToString());

                var precDto = new DTP_TIPOS_PROGRA_CAB_DTO();
                precDto.GESTION = gestion;
                precDto.INSTITUCION = institucion;
                precDto.GA = ga;

                DocTipPrg = _service.qry_DTP_TIPOS_PROGRA_CAB_filtrado(precDto);
                ViewBag.Operaciones = operacionSeguridad();
                if (ViewBag.Operaciones == "REGISTRAR")
                {
                    if (DocTipPrg.Count != 0)
                    {
                        DocTipPrg = DocTipPrg.Where(col => col.API_ESTADO != "APROBADO" ).ToList();
                    }
                }
                if (ViewBag.Operaciones == "APROBAR")
                {
                    if (DocTipPrg.Count != 0)
                    {
                        DocTipPrg = DocTipPrg.Where(col => col.API_ESTADO == "VERIFICADO" ).ToList();
                    }
                }
                ViewBag._TipoOperacion = fRef.slDominios(Models.Dominios.TIPO_OPERACION);
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(DocTipPrg, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DocTiposProgramConsulta()
        {
            //verificaPerfiles();

            return PartialView();
        }
        [HttpGet]
        public ActionResult DocTiposProgramDetalle()
        {
            //verificaPerfiles();

            return PartialView();
        }
        [HttpGet]
        public JsonResult DocTiposProgramConsultaCargar(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
           // verificaPerfiles();
            DTP_TIPOS_PROGRA_CAB_DTO DocTipPrg = new DTP_TIPOS_PROGRA_CAB_DTO();
            //try
            //{
                DocTipPrg = _service.qry_DTP_TIPOS_PROGRA_CAB_filtrado(new DTP_TIPOS_PROGRA_CAB_DTO { GESTION = precDto.GESTION, INSTITUCION = precDto.INSTITUCION, GA = precDto.GA, NRO_DOCUMENTO = precDto.NRO_DOCUMENTO, DPTO_LUGAR = 0, MUN_LUGAR = 0 }).FirstOrDefault();
                ViewBag._TipoOperacion = fRef.slDominios(Models.Dominios.TIPO_OPERACION);
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(DocTipPrg, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DocTiposProgramCrear()
        {
           // verificaPerfiles();

            return PartialView();
        }
        [HttpGet]
        public JsonResult DocTiposProgramCrearCargar(string idTipoOperacion = "")
        {
        //    verificaPerfiles();
            DTP_TIPOS_PROGRA_CAB_DTO DocTipPrg = null;
            //try
            //{
               // if (string.IsNullOrEmpty(idTipoOperacion))
                    //idTipoOperacion = "A";
               // ViewBag._idTipoOperacion = string.IsNullOrEmpty(idTipoOperacion) ? "A" : idTipoOperacion;
                DocTipPrg = inicializarDocTipPrg(new DTP_TIPOS_PROGRA_CAB_DTO() { TIPO_OPERACION = idTipoOperacion });
                //institucion
                INSTITUCIONES_DTO vrecInst = null;
                vrecInst = _service.qry_INSTITUCIONES_filtrado(new INSTITUCIONES_DTO { INSTITUCION= DocTipPrg.INSTITUCION }).FirstOrDefault();
                DocTipPrg.DESC_INSTITUCION = vrecInst.DESC_INSTITUCION;
                // GA
                GERENCIAS_ADMINISTRATIVAS_DTO vrecGA = null;
                vrecGA = _service.qry_GERENCIAS_ADMINISTRATIVAS_filtrado(new GERENCIAS_ADMINISTRATIVAS_DTO { INSTITUCION = DocTipPrg.INSTITUCION, GA= DocTipPrg.GA }).FirstOrDefault();
                DocTipPrg.DESC_GA = vrecGA.DESC_GA;
                // Lugar
                MUNICIPIOS_DTO vrecMun = null;
                vrecMun = _service.qry_MUNICIPIOS_filtrado( new MUNICIPIOS_DTO { DEPARTAMENTO = DocTipPrg.DPTO_LUGAR, MUNICIPIO = DocTipPrg.MUN_LUGAR }).FirstOrDefault();
                DocTipPrg.DESC_LUGAR = vrecMun.DESC_MUNICIPIO;
                DocTipPrg.NRO_DOCUMENTO = -1;
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(DocTipPrg, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DocTiposProgramCrearSalvar(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
           // verificaPerfiles();
            //try
            //{
                var strR = _service.ins_DTP_TIPOS_PROGRA_CAB_inserta(precDto);
                return Json(strR, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(ex, JsonRequestBehavior.AllowGet);
            //}

        
        }
       
        [HttpPost]
        public JsonResult DocTiposProgramModifCargar(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
            DTP_TIPOS_PROGRA_CAB_DTO recDto = new DTP_TIPOS_PROGRA_CAB_DTO();
           // verificaPerfiles();
            //try
            //{
            recDto = _service.qry_DTP_TIPOS_PROGRA_CAB_filtrado(new DTP_TIPOS_PROGRA_CAB_DTO
                {
                    GESTION = precDto.GESTION,
                    INSTITUCION = precDto.INSTITUCION,
                    GA = precDto.GA,
                    NRO_DOCUMENTO = precDto.NRO_DOCUMENTO
                }).FirstOrDefault();
            //}            
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(recDto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DocTiposProgramVerificar(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {

            //verificaPerfiles();

            return PartialView();
        }
        [HttpGet]
        public JsonResult DocTiposProgramVerificarCargar(short idGestion, short idInstitucion, short idGA, short idNroDocumento)
        {
          //  verificaPerfiles();
            DTP_TIPOS_PROGRA_CAB_DTO precDto = new DTP_TIPOS_PROGRA_CAB_DTO();

            //try
            //{
                precDto = _service.qry_DTP_TIPOS_PROGRA_CAB_filtrado(new DTP_TIPOS_PROGRA_CAB_DTO
                {
                    GESTION = idGestion,
                    INSTITUCION = idInstitucion,
                    GA = idGA,
                    NRO_DOCUMENTO = idNroDocumento
                }).FirstOrDefault();
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(precDto, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DocTiposProgramVerificarSalvar(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
          //  verificaPerfiles();

            DTP_TIPOS_PROGRA_CAB_DTO DocTipPrg = new DTP_TIPOS_PROGRA_CAB_DTO();
            bool esCorrecto = true;

            //if (ModelState.IsValid)
            //{
                //try
                //{
                    if (precDto.API_TRANSACCION == "VERIFICAR")
                    {
                        precDto = _service.upd_DTP_TIPOS_PROGRA_CAB_verifica(precDto);
                    }
                 //   ModelState.Clear();
               //}
               // catch (System.ServiceModel.FaultException ex)
               // { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); esCorrecto = false; }
               // catch (Exception ex)
               // { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); esCorrecto = false; }
           // }

            return Json(precDto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DocTiposProgramDesverificarSalvar(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
        //    verificaPerfiles();

            DTP_TIPOS_PROGRA_CAB_DTO DocTipPrg = new DTP_TIPOS_PROGRA_CAB_DTO();
            bool esCorrecto = true;

           // if (ModelState.IsValid)
          //  {
                //try
                //{
                    if (precDto.API_TRANSACCION == "DESVERIFICAR")
                    {
                        precDto = _service.upd_DTP_TIPOS_PROGRA_CAB_desverifica(precDto);
                    }
              //      ModelState.Clear();
                //}
                //catch (System.ServiceModel.FaultException ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); esCorrecto = false; }
                //catch (Exception ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); esCorrecto = false; }
           // }

            return Json(precDto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DocTiposProgramEliminarSalvar(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
         //   verificaPerfiles();

            DTP_TIPOS_PROGRA_CAB_DTO DocTipPrg = new DTP_TIPOS_PROGRA_CAB_DTO();
            bool esCorrecto = true;

           // if (ModelState.IsValid)
          //  {
                //try
                //{
                    if (precDto.API_TRANSACCION == "ELIMINAR")
                    {
                      precDto = _service.del_DTP_TIPOS_PROGRA_CAB_elimina(precDto);
                    }
                   // ModelState.Clear();
                //}
                //catch (System.ServiceModel.FaultException ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); esCorrecto = false; }
                //catch (Exception ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); esCorrecto = false; }
           // }

            return Json(precDto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DocTiposProgramAprobar(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {

           // verificaPerfiles();
            return PartialView();
        }
        [HttpGet]
        public JsonResult DocTiposProgramAprobarCargar(short idGestion, short idInstitucion, short idGA, short idNroDocumento)
        {
            DTP_TIPOS_PROGRA_CAB_DTO precDto = new DTP_TIPOS_PROGRA_CAB_DTO();

            //try
            //{
                precDto = _service.qry_DTP_TIPOS_PROGRA_CAB_filtrado(new DTP_TIPOS_PROGRA_CAB_DTO
                {
                    GESTION = idGestion,
                    INSTITUCION = idInstitucion,
                    GA = idGA,
                    NRO_DOCUMENTO = idNroDocumento
                }).FirstOrDefault();
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(precDto, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DocTiposProgramAprobarSalvar(DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {
            //verificaPerfiles();

            DTP_TIPOS_PROGRA_CAB_DTO DocTipPrg = new DTP_TIPOS_PROGRA_CAB_DTO();
            bool esCorrecto = true;

          //  if (ModelState.IsValid)
          //  {
                //try
                //{
                    if (precDto.API_TRANSACCION == "APROBAR")
                    {
                        precDto = _service.upd_DTP_TIPOS_PROGRA_CAB_aprueba (precDto);
                    }
                    ModelState.Clear();
                //}
                //catch (System.ServiceModel.FaultException ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); esCorrecto = false; }
                //catch (Exception ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); esCorrecto = false; }
        //    }

            return Json(precDto, JsonRequestBehavior.AllowGet);
        }

        // Métodos privados
        private DTP_TIPOS_PROGRA_CAB_DTO inicializarDocTipPrg (DTP_TIPOS_PROGRA_CAB_DTO precDto)
        {   // inicializar formulario
            var seguridad = ((SAS_DTO.AUX_SEGURIDAD_DTO)System.Web.HttpContext.Current.Session["Permisos"]);

            if (seguridad.detalleGrupo == null) {
                precDto.GESTION = 2016;
                precDto.INSTITUCION = 449;
                precDto.GA = 1; 
            }
            else {
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
        public string operacionSeguridad()
        {
            var seguridad = ((SAS_DTO.AUX_SEGURIDAD_DTO)System.Web.HttpContext.Current.Session["Permisos"]);

            int operacion = seguridad.FlujosOperaciones[0].ID_OPERACION;

            string respuesta;

            switch (operacion)
            {
                case 246:
                    respuesta = "REGISTRAR";
                    break;
                case 247:
                    respuesta = "APROBAR";
                    break;
                case 248:
                    respuesta = "CONSULTAR";
                    break;
                default:
                    respuesta = "NINGUNA";
                    break;
            }
            return respuesta;
        }
        [HttpPost]
        public JsonResult operacionEntrada()
        {
            string respuesta = operacionSeguridad();
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
        public virtual JsonResult cargarDominio(String idDominio = null)
        {
            List<DropDownKeyValue> listTipoOperacion = null;
            //try
            //{
               listTipoOperacion = _service.qry_CG_REF_CODES_filtrado(new CG_REF_CODES_DTO { RV_DOMAIN = idDominio })
                            .Select(x => new DropDownKeyValue()
                             {
                                value = x.RV_LOW_VALUE,
                                label = x.RV_MEANING
                             }).ToList();
            //}
            //catch (System.ServiceModel.FaultException ex) { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex) { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            //
            return Json(listTipoOperacion, JsonRequestBehavior.AllowGet);
        }


        // Programas relacionados al consolidado de tipos_programación

        [HttpPost]
        public JsonResult TiposProgramList(DTP_TIPOS_PROGRA_DET_DTO precDet)
        {
            //verificaPerfiles();
            List<TPR_TIPOS_PROGRAMACION_DTO> listaTiposProgram = new List<TPR_TIPOS_PROGRAMACION_DTO>();
            //try
            //{
                listaTiposProgram = _service.qry_TPR_TIPOS_PROGRAMACION_filtradoDocto(precDet);
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(listaTiposProgram, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult TiposProgramSalvarArreglo(List<DTP_TIPOS_PROGRA_DET_DTO> precListDet)
        {
            //verificaPerfiles();
            List<DTP_TIPOS_PROGRA_DET_DTO> ListaTiposProgram = new List<DTP_TIPOS_PROGRA_DET_DTO>();
            //try
            //{
                ListaTiposProgram = _service.ins_DTP_TIPOS_PROGRA_DET_insertaArreglo(precListDet);
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString());
            //    return Json(ex, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(ListaTiposProgram, JsonRequestBehavior.AllowGet);
        }

    }
}
