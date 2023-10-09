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
        public JsonResult DocTiposProgramDoctosConsultaCargar(short idGestion, short idInstitucion, short idGa, short idNroDocumento,
                                                              short idInstitucionProg, short idGaProg, short idTipoProgramacion)
        {
            List<DTP_DOCUMENTOS_DET_DTO> DocTipPrgDocto = new List<DTP_DOCUMENTOS_DET_DTO>();
            //try
            //{
                DocTipPrgDocto = _service.qry_DTP_DOCUMENTOS_DET_filtrado(new DTP_DOCUMENTOS_DET_DTO { GESTION = idGestion, INSTITUCION = idInstitucion,
                                                                        GA = idGa, NRO_DOCUMENTO = idNroDocumento,
                                                                        INSTITUCION_PROG = idInstitucionProg, GA_PROG = idGaProg,
                                                                        TIPO_PROGRAMACION = idTipoProgramacion});
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(DocTipPrgDocto, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult DocTiposProgramDoctosCrear(short idGestion, short idInstitucion, short idGa, short idNroDocumento)
        {
            //Constantes
            DTP_DOCUMENTOS_DET_DTO DocTipPrgDoctos = inicializarDocTipPrgDoctos(new DTP_DOCUMENTOS_DET_DTO() { GESTION = idGestion, INSTITUCION = idInstitucion, GA = idGa, NRO_DOCUMENTO = idNroDocumento });

            return Json(DocTipPrgDoctos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DocTiposProgramDoctosCrearSalvar(DTP_DOCUMENTOS_DET_DTO precDto)
        {
            //verificaPerfiles();

          //  List<DTP_DOCUMENTOS_DET_DTO> listaDoctos = new List<DTP_DOCUMENTOS_DET_DTO>();
            bool esCorrecto = false;

            //if (ModelState.IsValid)
            //{
            //try
            //{
                if (precDto.API_TRANSACCION == "CREAR")
                {
                    precDto = _service.ins_DTP_DOCUMENTOS_DET_inserta(precDto);
                    esCorrecto = true;
                }
                else
                {
                    esCorrecto = false;
                }
                if (esCorrecto == false)
                {
                    throw new Exception("La transacción es incorrecta");
                }

                //ModelState.Clear();
            //}
            //    catch (System.ServiceModel.FaultException ex)
            //    { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); esCorrecto = false; }
            //    catch (Exception ex)
            //    { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); esCorrecto = false; }
            //  }

            return Json(precDto, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult DocTiposProgramDoctosModif(short idGestion, short idInstitucion, short idGA, short idNroDocumento,
                                                           short idInstitucionProg, short idGaProg, short idTipoProgramacion, short idSecuenciaDoc)
        {
            DTP_DOCUMENTOS_DET_DTO precDto = new DTP_DOCUMENTOS_DET_DTO();
            //try
            //{
                precDto = _service.qry_DTP_DOCUMENTOS_DET_filtrado(new DTP_DOCUMENTOS_DET_DTO
                {
                    GESTION = idGestion,
                    INSTITUCION = idInstitucion,
                    GA = idGA,
                    NRO_DOCUMENTO = idNroDocumento,
                    INSTITUCION_PROG = idInstitucionProg,
                    GA_PROG = idGaProg,
                    TIPO_PROGRAMACION = idTipoProgramacion,
                    SECUENCIA_DOC = idSecuenciaDoc
                }).FirstOrDefault();
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(precDto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DocTiposProgramDoctosModifSalvar(DTP_DOCUMENTOS_DET_DTO precDto)
        {
            //verificaPerfiles();

            List<DTP_DOCUMENTOS_DET_DTO> listaDoctos = new List<DTP_DOCUMENTOS_DET_DTO>();

            //if (ModelState.IsValid)
            //{
                //try
                //{
                    if (precDto.API_TRANSACCION == "MODIFICAR")
                    {
                        precDto = _service.upd_DTP_DOCUMENTOS_DET_actualiza(precDto);
                    }
                   // ModelState.Clear();
                //}
                //catch (System.ServiceModel.FaultException ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
                //catch (Exception ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            return Json(listaDoctos, JsonRequestBehavior.AllowGet);
        }
        public virtual JsonResult cargarTiposDocumentos(string idDocumento = null)
        {
            List<DropDownKeyValue> listDoc = null;
            //try
            //{
                var doc = new DCO_DOCUMENTOS_DTO();
                doc.API_ESTADO = "APROBADO";
                if (idDocumento != null )
                {
                    doc.ID_DOCUMENTO = idDocumento;
                }
                listDoc = _service.qry_DCO_DOCUMENTOS_filtrado(doc)
                             .Select(x => new DropDownKeyValue()
                             {
                                 value = x.ID_DOCUMENTO,
                                 label = x.DESC_DOCUMENTO
                             }).ToList();
            //}
            //catch (System.ServiceModel.FaultException ex) { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex) { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            //
            return Json(listDoc, JsonRequestBehavior.AllowGet);
        }

        // Métodos privados
        [HttpGet]
        public DTP_DOCUMENTOS_DET_DTO inicializarDocTipPrgDoctos(DTP_DOCUMENTOS_DET_DTO preDto)
        {
            DTP_DOCUMENTOS_DET_DTO precDto = new DTP_DOCUMENTOS_DET_DTO();
            precDto.GA = 0;
            precDto.INSTITUCION = 0;
           
            precDto.API_ESTADO = "INICIAL";
            precDto.API_TRANSACCION = "CREAR";
            precDto.USU_CRE = User.Identity.Name;
            precDto.FEC_CRE = DateTime.Now;
            return precDto;
        }
        //public JsonResult CargarColumnas() {

        //}
        [HttpPost]
        public JsonResult DocTiposProgramDoctosEliminar(DTP_DOCUMENTOS_DET_DTO precDto)
        {
            var esCorrecto = false;
            //try
            //{
                if (precDto.API_TRANSACCION == "ELIMINAR")
                {
                    _service.del_DTP_DOCUMENTOS_DET_borrar(precDto);
                    esCorrecto = true;
                }
                //  ModelState.Clear();
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); esCorrecto = false; }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); esCorrecto = false; }

            if (esCorrecto == true) { return Json("Correcto", JsonRequestBehavior.AllowGet); } else { return Json("No se pudo eliminar el registro", JsonRequestBehavior.AllowGet); }
        }
    }
}