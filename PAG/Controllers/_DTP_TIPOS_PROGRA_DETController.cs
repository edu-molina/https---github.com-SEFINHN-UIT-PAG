using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;

using PAG_DTO;

namespace PAG.Controllers
{
    [Authorize]
    public partial class DocTiposProgramController : BaseController
    {
        
        [HttpPost]
        public JsonResult DocTiposProgramDetConsultaCargar(short idGestion, short idInstitucion, short idGa, short idNroDocumento)
        {
            List<DTP_TIPOS_PROGRA_DET_DTO> DocTipPrgDet = new List<DTP_TIPOS_PROGRA_DET_DTO>();
            //DTP_TIPOS_PROGRA_DET_DTO DocTipPrgDet = new DTP_TIPOS_PROGRA_DET_DTO();
            //try
            //{
                DocTipPrgDet = _service.qry_DTP_TIPOS_PROGRA_DET_filtrado(new DTP_TIPOS_PROGRA_DET_DTO { GESTION = idGestion, INSTITUCION = idInstitucion, GA = idGa, NRO_DOCUMENTO = idNroDocumento });
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(DocTipPrgDet, JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public JsonResult DocTiposProgramDetCrearCargar(short idGestion, short idInstitucion, short idGa, short idNroDocumento)
        {
            //Constantes
            DTP_TIPOS_PROGRA_DET_DTO DocTipPrgDet = inicializarDocTipPrgDet(new DTP_TIPOS_PROGRA_DET_DTO() { GESTION = idGestion, INSTITUCION = idInstitucion, GA = idGa, NRO_DOCUMENTO = idNroDocumento });
            return Json(DocTipPrgDet, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DocTiposProgramDetCrearSalvar(DTP_TIPOS_PROGRA_DET_DTO precDto)
        {
            //verificaPerfiles();

                //try
                //{
                    if (precDto.API_TRANSACCION == "CREAR")
                    {
                        precDto = _service.ins_DTP_TIPOS_PROGRA_DET_inserta(precDto);
                        
                    }
                    
                //}
                //catch (System.ServiceModel.FaultException ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
                //catch (Exception ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(precDto, JsonRequestBehavior.AllowGet);
        }
        

        [HttpGet]
        public JsonResult DocTiposProgramDetModifCargar(DTP_TIPOS_PROGRA_DET_DTO precDto)
        {
           // DTP_TIPOS_PROGRA_DET_DTO precDto = new DTP_TIPOS_PROGRA_DET_DTO();
            //try
            //{
                precDto = _service.qry_DTP_TIPOS_PROGRA_DET_filtrado(precDto).FirstOrDefault();
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(precDto, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DocTiposProgramDetModifSalvar(DTP_TIPOS_PROGRA_DET_DTO precDto)
        {
            //verificaPerfiles();

            DTP_TIPOS_PROGRA_DET_DTO DocTipPrgDet = new DTP_TIPOS_PROGRA_DET_DTO();
            List<DTP_TIPOS_PROGRA_DET_DTO> listaDet = new List<DTP_TIPOS_PROGRA_DET_DTO>();

           // if (ModelState.IsValid)
           // {
                //try
                //{
                    if (precDto.API_TRANSACCION == "MODIFICAR")
                    {
                        precDto = _service.upd_DTP_TIPOS_PROGRA_DET_actualiza(precDto);
                    }
                  //  ModelState.Clear();
                //}
                //catch (System.ServiceModel.FaultException ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
                //catch (Exception ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            return Json(precDto, JsonRequestBehavior.AllowGet);
        }
        public virtual JsonResult cargarInstituciones(string idInstitucion = null)
        {
            List<DropDownKeyValue> listInstituciones = null;
            //try
            //{
                var institucion = new INSTITUCIONES_DTO();
                if (idInstitucion != null)
                {
                    institucion.INSTITUCION = short.Parse(idInstitucion);
                }
                listInstituciones = _service.qry_INSTITUCIONES_filtrado(institucion)
                             .Select(x => new DropDownKeyValue()
                             {
                                 value = x.INSTITUCION.ToString(),
                                 label = x.DESC_INSTITUCION
                             }).ToList();
            //}
            //catch (System.ServiceModel.FaultException ex) { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex) { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            //
            return Json(listInstituciones, JsonRequestBehavior.AllowGet);
        }
        public virtual JsonResult cargarGA(string idGa, string idGestion = null, string idInstitucion = null)
        {
            List<DropDownKeyValue> listGA = null;
            var correcto = false;
            //try
            //{
                var ga = new GERENCIAS_ADMINISTRATIVAS_DTO();
                if (idGestion != null && idInstitucion != null && idGa != null)
                {
                    correcto = true; // con estos valores asignados se permite filtrar tambien con la GA
                    ga.GESTION = short.Parse(idGestion);
                    ga.INSTITUCION = short.Parse(idInstitucion);
                }
                if (correcto)
                {
                    ga.GA = short.Parse(idGa);
                }
                listGA = _service.qry_GERENCIAS_ADMINISTRATIVAS_filtrado(ga)
                             .Select(x => new DropDownKeyValue()
                             {
                                 value = x.GA.ToString(),
                                 label = x.DESC_GA
                             }).ToList();
            //}
            //catch (System.ServiceModel.FaultException ex) { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex) { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            //
            return Json(listGA, JsonRequestBehavior.AllowGet);
        }
        // Métodos privados
        private DTP_TIPOS_PROGRA_DET_DTO inicializarDocTipPrgDet(DTP_TIPOS_PROGRA_DET_DTO precDto)
        {
            var seguridad = ((SAS_DTO.AUX_SEGURIDAD_DTO)System.Web.HttpContext.Current.Session["Permisos"]);

            precDto.API_ESTADO = "INICIAL";
            precDto.API_TRANSACCION = "CREAR";
            precDto.USU_CRE = User.Identity.Name;
            precDto.FEC_CRE = DateTime.Now;
            precDto.ESPECIAL = "N";
            precDto.INSTITUCION_PROG = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_INSTITUCION"]).VALOR.ToString());
            precDto.GA_PROG = short.Parse(seguridad.detalleGrupo.Find(col => col.NIVEL == System.Configuration.ConfigurationManager.AppSettings["nivelGrupoDetalle_GA"]).VALOR.ToString());

            return precDto;
        }
        [HttpPost]
        public JsonResult DocTiposProgramEliminar(DTP_TIPOS_PROGRA_DET_DTO precDto) {
            var esCorrecto = false;
            //try
            //{
                if (precDto.API_TRANSACCION == "ELIMINAR")
                {
                    _service.del_DTP_TIPOS_PROGRA_DET_borrar(precDto);
                    esCorrecto = true;
                }
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); esCorrecto = false; }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); esCorrecto = false; }

            if (esCorrecto == true) { return Json("Correcto", JsonRequestBehavior.AllowGet); } else { return Json("No se pudo eliminar el registro", JsonRequestBehavior.AllowGet); }
            
        }

    }
}