using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using PAG.Helpers;
using PAG_DTO;

namespace PAG.Controllers
{
    public partial class DocTiposProgramController: BaseController
    {
        //DTP_DETALLES_DET
        [HttpPost]
        public JsonResult DocTiposProgramDetallesConsulta(short idGestion, short idInstitucion, short idGa, short idNroDocumento,
                                                          short idInstitucionProg, short idGaProg, short idTipoProgramacion, short secdocumento)
        {
            List<DTP_DETALLES_DET_DTO> DocTipPrgDocto = new List<DTP_DETALLES_DET_DTO>();
            //try
            //{
                DocTipPrgDocto = _service.qry_DTP_DETALLES_DET_filtrado(new DTP_DETALLES_DET_DTO
                {
                    GESTION = idGestion,
                    INSTITUCION = idInstitucion,
                    GA = idGa,
                    NRO_DOCUMENTO = idNroDocumento,
                    INSTITUCION_PROG = idInstitucionProg,
                    GA_PROG = idGaProg,
                    TIPO_PROGRAMACION = idTipoProgramacion,
                    SECUENCIA_DOC = secdocumento
                }).ToList() ;
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(DocTipPrgDocto, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DocTiposProgramDetallesCrear(short idGestion, short idInstitucion, short idGa, short idNroDocumento, 
                                                       short idInstitucionPorg, short idGaProg, short idTipoProgramacion,
                                                       short idSecuenciaDoc)
        {
            //Constantes
            DTP_DETALLES_DET_DTO DocTipPrgDetalles = inicializarDocTipPrgDetalles(new DTP_DETALLES_DET_DTO() { GESTION = idGestion, INSTITUCION = idInstitucion, GA = idGa, NRO_DOCUMENTO = idNroDocumento,
                                                                                                               INSTITUCION_PROG = idInstitucionPorg, GA_PROG = idGaProg, TIPO_PROGRAMACION = idTipoProgramacion,
                                                                                                               SECUENCIA_DOC = idSecuenciaDoc });

            return Json(DocTipPrgDetalles, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DocTiposProgramDetallesCrearSalvar(List<DTP_DETALLES_DET_DTO> precDto)
        {
            //verificaPerfiles();

            List<DTP_DETALLES_DET_DTO> listaDetalles = new List<DTP_DETALLES_DET_DTO>();
            //bool esCorrecto = false;

                //try
                //{
                    foreach (var item in precDto)
                    {
                        item.API_TRANSACCION = "CREAR";
                        DTP_DETALLES_DET_DTO salida = new DTP_DETALLES_DET_DTO();
                            if (item.API_TRANSACCION == "CREAR")
                            {
                                salida = _service.ins_DTP_DETALLES_DET_inserta(item);
                               // esCorrecto = true;
                            }   
                    // ModelState.Clear();
                        listaDetalles.Add(salida);
                    }
                // }
                //catch (System.ServiceModel.FaultException ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); esCorrecto = false; }
                //catch (Exception ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); esCorrecto = false; }
           // }
            //if (esCorrecto)
            //    ErrorControlado(TipoMensaje.Satisfactorio);
            
            return Json(JsonExtension.json(listaDetalles), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DocTiposProgramDetallesModif(short idGestion, short idInstitucion, short idGA, short idNroDocumento,
                                                        short idInstitucionProg, short idGaProg, short idTipoProgramacion, 
                                                        short idSecuenciaDoc, short idSecuenciaDet)
        {
            DTP_DETALLES_DET_DTO precDto = new DTP_DETALLES_DET_DTO();
            //try
            //{
                precDto = _service.qry_DTP_DETALLES_DET_filtrado(new DTP_DETALLES_DET_DTO
                {
                    GESTION = idGestion,
                    INSTITUCION = idInstitucion,
                    GA = idGA,
                    NRO_DOCUMENTO = idNroDocumento,
                    INSTITUCION_PROG = idInstitucionProg,
                    GA_PROG = idGaProg,
                    TIPO_PROGRAMACION = idTipoProgramacion,
                    SECUENCIA_DOC = idSecuenciaDoc,
                    SECUENCIA_DET = idSecuenciaDet
                }).FirstOrDefault();
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(precDto, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DocTiposProgramDetallesModifSalvar(DTP_DETALLES_DET_DTO precDto)
        {
            //verificaPerfiles();

            List<DTP_DETALLES_DET_DTO> listaDetalles = new List<DTP_DETALLES_DET_DTO>();
           // bool esCorrecto = false;

            //if (ModelState.IsValid)
            //{
                //try
                //{
                    if (precDto.API_TRANSACCION == "CREAR")
                    {
                        precDto = _service.upd_DTP_DETALLES_DET_actualiza(precDto);
                        //esCorrecto = true;
                    }
                    //ModelState.Clear();
                //}
                //catch (System.ServiceModel.FaultException ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); esCorrecto = false; }
                //catch (Exception ex)
                //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); esCorrecto = false; }
            //}
            //if (esCorrecto)
            //    ErrorControlado(TipoMensaje.Satisfactorio);

            //try
            //{
                listaDetalles = _service.qry_DTP_DETALLES_DET_filtrado(new DTP_DETALLES_DET_DTO
                {
                    GESTION = precDto.GESTION,
                    INSTITUCION = precDto.INSTITUCION,
                    GA = precDto.GA,
                    NRO_DOCUMENTO = precDto.NRO_DOCUMENTO,
                    INSTITUCION_PROG = precDto.INSTITUCION_PROG,
                    GA_PROG = precDto.GA_PROG,
                    TIPO_PROGRAMACION = precDto.TIPO_PROGRAMACION,
                    SECUENCIA_DOC = precDto.SECUENCIA_DOC
                });
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(listaDetalles, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DocTiposProgramDetallesEliminar(DTP_DETALLES_DET_DTO precDto) {
            //try {
                _service.del_DTP_DETALLES_DET_borrar(precDto);
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            return Json(precDto, JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult cargarColumnas(string especial, string idDocumento = null)
        {
            List<DropDownKeyValue> listCol = null;
            //try
            //{
                var col = new DCO_DOCUMENTOS_COLUMNAS_DTO();
                col.API_ESTADO = "APROBADO";
                if (idDocumento != null)
                {
                    col.ID_DOCUMENTO = idDocumento;
                    if (especial == "N") { // solo carga las columnas  que no son especiales, caso contrario carga todas las columnas del documento
                        col.ESPECIAL = especial;
                    }
                }
                listCol = _service.qry_DCO_DOCUMENTOS_COLUMNAS_filtrado(col)
                             .Select(x => new DropDownKeyValue()
                             {
                                 value = x.ID_COLUMNA.ToString(),
                                 label = x.DESC_COLUMNA
                             }).ToList();
            //}
            //catch (System.ServiceModel.FaultException ex) { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex) { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            //
            return Json(listCol, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public virtual JsonResult cargarValorColumnaSeleccionada(string idColumna = null)
        {
            DCO_COLUMNAS_DTO regColumna = null;
            //try
            //{
                var columna = new DCO_COLUMNAS_DTO();
                columna.API_ESTADO = "APROBADO";
                if (idColumna != null)
                {
                    columna.ID_COLUMNA = short.Parse(idColumna);
                }
                regColumna = _service.qry_DCO_COLUMNAS_filtrado(columna).FirstOrDefault();
            //}
            //catch (System.ServiceModel.FaultException ex) { ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex) { ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }
            //
            return Json(regColumna, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public virtual JsonResult cargarValoresColumnas(DTP_DETALLES_DET_DTO precDetalle)
        {
            // Se recuperan todos los posibles valores relacionados a una columna
            List<VM_PAG_LISTA_VALORES_DTO> lista = null;
            //try
            //{
                lista = _service.qry_VM_PAG_LISTA_VALORES_filtradoDocto(precDetalle).ToList();
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString()); }
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(lista, JsonRequestBehavior.AllowGet);          
        }
        // Métodos privados
        private DTP_DETALLES_DET_DTO inicializarDocTipPrgDetalles(DTP_DETALLES_DET_DTO precDto)
        {
            precDto.API_ESTADO = "INICIAL";
            precDto.API_TRANSACCION = "CREAR";
            precDto.USU_CRE = User.Identity.Name;
            precDto.FEC_CRE = DateTime.Now;
            return precDto;
        }
        [HttpPost]
        public JsonResult SalvarValorDetalle(DTP_DETALLES_DET_DTO precDto)
        {
            //verificaPerfiles();
            DTP_DETALLES_DET_DTO regDetalle = new DTP_DETALLES_DET_DTO();
            //try
            //{
                precDto.API_TRANSACCION = "CREAR";
                regDetalle = _service.ins_DTP_DETALLES_DET_inserta(precDto);                
            //}
            //catch (System.ServiceModel.FaultException ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, ex.Code.Name.ToString(), ex.Message.ToString());}
            //catch (Exception ex)
            //{ ErrorControlado(TipoMensaje.Advertencia, "ExApp", ex.Message.ToString()); }

            return Json(regDetalle, JsonRequestBehavior.AllowGet);
        }
    }
}