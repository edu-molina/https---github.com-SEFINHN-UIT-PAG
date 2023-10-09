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
    public class DocLibBolsonFteController : BaseController
    {
        /// <summary>
        /// codigo de operaciones que solo tienen acceso a este controller.
        /// </summary>
        /// 
        iPAG_Services _service;
        public Models.Funciones fRef = new Models.Funciones();
        public ISecurityManager Security { get; set; }
        public DocLibBolsonFteController()
        {

        }
        public DocLibBolsonFteController(iPAG_Services service)
        {
            this._service = service;
        }
        public int[] idFlujosOperacionesController
        {
            get { return new int[] { 243, 244, 245 }; }
        }
        // GET: DocLibBolsonFte
        [HttpGet]
        public ActionResult Index()
        {
            // verificaPerfiles();           

            return View("AngularShared");
        }
        [HttpGet]
        public ActionResult DocLibBolsonFte()
        {
            //verificaPerfiles();
            
            return PartialView();
        }
        [HttpPost]
        public JsonResult DocLibBolsonFteList()
        {
            //verificaPerfiles();
            List<DLB_LIB_BOLSON_CAB_DTO> DocLibFte = new List<DLB_LIB_BOLSON_CAB_DTO>();
            //try
            //{
            var seguridad = ((SAS_DTO.AUX_SEGURIDAD_DTO)System.Web.HttpContext.Current.Session["Permisos"]);
                var gestion = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_GESTION"]).VALOR.ToString());
                var institucion = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_INSTITUCION"]).VALOR.ToString());
                var ga = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_GA"]).VALOR.ToString());

                var precDto = new DLB_LIB_BOLSON_CAB_DTO();
                precDto.GESTION = gestion;
                precDto.INSTITUCION = institucion;
                precDto.GA = ga;
                DocLibFte = _service.qry_DLB_LIB_BOLSON_CAB_filtrado(precDto);
                ViewBag.Operacion = operacionSeguridad();
            if (ViewBag.Operacion == "REGISTRAR")
                {
                    if (DocLibFte.Count != 0)
                    {
                        DocLibFte = DocLibFte.Where(col => col.API_ESTADO != "APROBADO" ).ToList();
                    }
                }
                if (ViewBag.Operacion == "APROBAR")
                {
                    if (DocLibFte.Count != 0)
                    {
                        DocLibFte = DocLibFte.Where(col => col.API_ESTADO == "VERIFICADO" ).ToList();
                    }
                }
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(DocLibFte, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DocLibBolsonFteConsulta()
        {
            //verificaPerfiles();

            return PartialView();
        }
        [HttpGet]
        public JsonResult DocLibBolsonFteConsultaCargar(short idGestion, short idInstitucion, short idGa, short idNroDocumento)
        {
            //verificaPerfiles();
            DLB_LIB_BOLSON_CAB_DTO DocLibFte = new DLB_LIB_BOLSON_CAB_DTO();
            //try
            //{
                DocLibFte = _service.qry_DLB_LIB_BOLSON_CAB_filtrado(new DLB_LIB_BOLSON_CAB_DTO { GESTION = idGestion, INSTITUCION = idInstitucion, GA = idGa, NRO_DOCUMENTO = idNroDocumento}).FirstOrDefault();
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(DocLibFte, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DocLibBolsonFteDetalle(short idGestion, short idInstitucion, short idGa, short idNroDocumento)
        {
            //verificaPerfiles();
            List<DLB_LIB_BOLSON_DET_DTO> DocLibFte = new List<DLB_LIB_BOLSON_DET_DTO>();
            //try
            //{
                DocLibFte = _service.qry_DLB_LIB_BOLSON_DET_filtrado(new DLB_LIB_BOLSON_DET_DTO { GESTION = idGestion, INSTITUCION = idInstitucion, GA = idGa, NRO_DOCUMENTO = idNroDocumento }).ToList(); 
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(DocLibFte, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DocLibBolsonFteCrear()
        {
            //verificaPerfiles();

            return PartialView();
        }
        public JsonResult DocLibBolsonFteCrearCargar(string idTipoOperacion = "")
        {
            DLB_LIB_BOLSON_CAB_DTO DocLibBolson = null;
            //try
            //{
                DocLibBolson = inicializarDocLibBol(new DLB_LIB_BOLSON_CAB_DTO() { TIPO_OPERACION = idTipoOperacion });
                //institucion
                INSTITUCIONES_DTO vrecInst = null;
                vrecInst = _service.qry_INSTITUCIONES_filtrado(new INSTITUCIONES_DTO { INSTITUCION = DocLibBolson.INSTITUCION }).FirstOrDefault();
                DocLibBolson.DESC_INSTITUCION = vrecInst.DESC_INSTITUCION;
                // GA
                GERENCIAS_ADMINISTRATIVAS_DTO vrecGA = null;
                vrecGA = _service.qry_GERENCIAS_ADMINISTRATIVAS_filtrado(new GERENCIAS_ADMINISTRATIVAS_DTO { GESTION = DocLibBolson.GESTION, INSTITUCION = DocLibBolson.INSTITUCION, GA = DocLibBolson.GA }).FirstOrDefault();
                DocLibBolson.DESC_GA = vrecGA.DESC_GA;
                // Lugar
                MUNICIPIOS_DTO vrecMun = null;
                vrecMun = _service.qry_MUNICIPIOS_filtrado(new MUNICIPIOS_DTO { DEPARTAMENTO = DocLibBolson.DPTO_LUGAR, MUNICIPIO = DocLibBolson.MUN_LUGAR }).FirstOrDefault();
                DocLibBolson.DESC_LUGAR = vrecMun.DESC_MUNICIPIO;
                DocLibBolson.NRO_DOCUMENTO = -1;
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(DocLibBolson, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DocLibBolsonFteCrearSalvar(DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            //verificaPerfiles();
            //try
            //{
                var regCabecera = _service.ins_DLB_LIB_BOLSON_CAB_inserta(precDto);
                return Json(regCabecera, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(ex, JsonRequestBehavior.AllowGet);
            //}
        }

        public JsonResult DocLibBolsonFteDetCrearSalvar(DLB_LIB_BOLSON_DET_DTO precDto)
        {
            //verificaPerfiles();
            //try
            //{
                var regDetalle = _service.ins_DLB_LIB_BOLSON_DET_inserta(precDto);
                return Json(regDetalle, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(ex, JsonRequestBehavior.AllowGet);
            //}
        }
        public JsonResult DocLibBolsonFteDetModifSalvar(DLB_LIB_BOLSON_DET_DTO precDto)
        {
            //verificaPerfiles();
            //try
            //{
                precDto.API_TRANSACCION = "MODIFICAR";
                var regDetalle = _service.upd_DLB_LIB_BOLSON_DET_actualiza(precDto);
                return Json(regDetalle, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(ex, JsonRequestBehavior.AllowGet);
            //}
        }

        [HttpPost]
        public JsonResult DocLibBolsonFteDetBorrar(DLB_LIB_BOLSON_DET_DTO precDto)
        {
            //verificaPerfiles();
            //try
            //{
                _service.del_DLB_LIB_BOLSON_DET_borrar(precDto);
                var mensaje = "Eliminación Exitosa";
                return Json(mensaje, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(ex, JsonRequestBehavior.AllowGet);
            //}
        }

        
        [HttpPost]
        public JsonResult DocLibBolsonFteEliminar(DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            //verificaPerfiles();
            //try
            //{
                precDto.API_TRANSACCION = "ELIMINAR";
                var regCabecera = _service.del_DLB_LIB_BOLSON_CAB_elimina(precDto);
                return Json(regCabecera, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(ex, JsonRequestBehavior.AllowGet);
            //}
        }
        [HttpPost]
        public JsonResult DocLibBolsonFteVerificar(DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            //verificaPerfiles();
            //try
            //{
                precDto.API_TRANSACCION = "VERIFICAR";
                var regCabecera = _service.upd_DLB_LIB_BOLSON_CAB_verifica(precDto);
                return Json(regCabecera, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(ex, JsonRequestBehavior.AllowGet);
            //}
        }

        [HttpPost]
        public JsonResult DocLibBolsonFteDesverificar(DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            //verificaPerfiles();
            //try
            //{
                precDto.API_TRANSACCION = "DESVERIFICAR";
                var regCabecera = _service.upd_DLB_LIB_BOLSON_CAB_desverifica(precDto);
                return Json(regCabecera, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(ex, JsonRequestBehavior.AllowGet);
            //}
        }

        [HttpPost]
        public JsonResult DocLibBolsonFteAprobar(DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            //verificaPerfiles();
            //try
            //{
                precDto.API_TRANSACCION = "APROBAR";
                var regCabecera = _service.upd_DLB_LIB_BOLSON_CAB_aprueba(precDto);
                return Json(regCabecera, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(ex, JsonRequestBehavior.AllowGet);
            //}
        }

        public virtual JsonResult cargarBancos()
        {
            List<DropDownKeyValue> listaBancos = null;
            BANCOS_DTO banco = new BANCOS_DTO { API_ESTADO = "APROBADO", BANCO = 1};
            //try
            //{
                listaBancos = _service.qry_BANCOS_filtrado(banco)
                    .Select(x => new DropDownKeyValue()
                    {
                        value = x.BANCO.ToString(),
                        label = x.DESC_BANCO
                    })
                    .ToList();
            //}
            //catch (System.ServiceModel.FaultException ex) { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex) { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            //
            return Json(listaBancos, JsonRequestBehavior.AllowGet);
        }
        public virtual JsonResult cargarDominio(String idDominio)
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
        public virtual JsonResult cargarFuentes()
        {
            List<DropDownKeyValue> listaFuentes = null;
            FUENTES_FINANCIAMIENTO_DTO fuente = new FUENTES_FINANCIAMIENTO_DTO { API_ESTADO= "ELABORADO", VIGENTE = "S" };
            //try
            //{
                listaFuentes = _service.qry_FUENTES_FINANCIAMIENTO_filtrado(fuente)
                    .Select(x => new DropDownKeyValue()
                    {
                        value = x.FUENTE.ToString(),
                        label = x.FUENTE.ToString() +"-"+ x.DESC_FUENTE
                    })
                    .ToList();
            //}
            //catch (System.ServiceModel.FaultException ex) { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex) { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            //
            return Json(listaFuentes, JsonRequestBehavior.AllowGet);
        }
        public virtual JsonResult cargarMonedas()
        {
            List<DropDownKeyValue> listaMonedas = null;
            MONEDAS_DTO moneda = new MONEDAS_DTO { API_ESTADO = "ELABORADO"};
            //try
            //{
                listaMonedas = _service.qry_MONEDAS_filtrado(moneda)
                    .Select(x => new DropDownKeyValue()
                    {
                        value = x.MONEDA,
                        label = x.MONEDA +"-"+ x.DESC_MONEDA
                    })
                    .ToList();
            //}
            //catch (System.ServiceModel.FaultException ex) { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex) { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            //
            return Json(listaMonedas, JsonRequestBehavior.AllowGet);
        }
        public virtual JsonResult cargarLibretas(short idGestion, short idBanco, string idcuenta)
        {
            List<DropDownKeyValue> listaLibretas = null;
            LIBRETAS_DTO libretas = new LIBRETAS_DTO { GESTION = idGestion, BANCO = idBanco, CUENTA = idcuenta,  API_ESTADO = "APROBADO"};
            //try
            //{
                listaLibretas = _service.qry_LIBRETAS_filtrado(libretas)
                    .Select(x => new DropDownKeyValue()
                    {
                        value = x.LIBRETA,
                        label = x.LIBRETA+"-"+x.DESC_LIBRETA
                    })
                    .ToList();
            //}
            //catch (System.ServiceModel.FaultException ex) { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex) { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            //
            return Json(listaLibretas, JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult cargarLibrosBanco(short idGestion, short idBanco, string idMoneda)
        {
            List<DropDownKeyValue> listaLibrosBanco = null;
            LIBROS_BANCO_DTO libros = new LIBROS_BANCO_DTO {GESTION = idGestion, BANCO = idBanco, API_ESTADO = "APROBADO", UTILIZA_LIBRETAS = "S", MONEDA = idMoneda};
            //try
            //{
                listaLibrosBanco = _service.qry_LIBROS_BANCO_filtrado(libros)
                    .Select(x => new DropDownKeyValue()
                    {
                        value = x.CUENTA,
                        label = x.CUENTA +"-"+x.DESC_CUENTA
                    })
                    .ToList();
                var y = true;
                var yy = true;
                if (y && yy) { yy = false; }
                else { y = false; }
            //}
            //catch (System.ServiceModel.FaultException ex) { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex) { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            //
            return Json(listaLibrosBanco, JsonRequestBehavior.AllowGet);
        }
        public string operacionSeguridad()
        {
            var seguridad = ((SAS_DTO.AUX_SEGURIDAD_DTO)System.Web.HttpContext.Current.Session ["Permisos"]);

             int operacion = seguridad.FlujosOperaciones[0].ID_OPERACION;

            string respuesta;

             switch (operacion)
             {
                case 243:
                   respuesta = "REGISTRAR";
                   break;
                case 244:
                   respuesta = "APROBAR";
                   break;
                case 245:
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

        private DLB_LIB_BOLSON_CAB_DTO inicializarDocLibBol(DLB_LIB_BOLSON_CAB_DTO precDto)
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

        // Programas relacionados al consolidado de libretas bolson

        [HttpPost]
        public JsonResult LibBolsonFteList(DLB_LIB_BOLSON_DET_DTO precDet)
        {
            //verificaPerfiles();
            List<PRG_LIBRETAS_BOLSON_DTO> LibBolsonFte = new List<PRG_LIBRETAS_BOLSON_DTO>();
            //try
            //{
                LibBolsonFte = _service.qry_PRG_LIBRETAS_BOLSON_filtradoDocto(precDet);
                if (LibBolsonFte.Count != 0) { LibBolsonFte = LibBolsonFte.Where(col => col.API_ESTADO != "ELIMINADO").ToList(); }
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(LibBolsonFte, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult LibBolsonFteSalvarArreglo(List<DLB_LIB_BOLSON_DET_DTO> precListDet)
        {
            //verificaPerfiles();
            List<DLB_LIB_BOLSON_DET_DTO> ListaLibBolsonFte = new List<DLB_LIB_BOLSON_DET_DTO>();
            //try
            //{
                ListaLibBolsonFte = _service.ins_DLB_LIB_BOLSON_DET_insertaArreglo(precListDet);
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(ListaLibBolsonFte, JsonRequestBehavior.AllowGet);
        }
    }
}