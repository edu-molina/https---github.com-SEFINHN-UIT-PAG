//------------------------------------------------------------------------------
//                         Secretaria de Finanzas
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using PAG_DA;
using PAG_DTO;
using PAG_INTERFACES;
using PAG_MAPPERS;
using SEFIN.FWK.ERRORHANDLER.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Transactions;

namespace PAG_WCF
{
    
    
    public class DLB_LIB_BOLSON_CAB_RDN
    {
        // Listado.
        public List<DLB_LIB_BOLSON_CAB_DTO> DLB_LIB_BOLSON_CAB_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<DLB_LIB_BOLSON_CAB_DTO> ltDLB_LIB_BOLSON_CAB = new List<DLB_LIB_BOLSON_CAB_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<DLB_LIB_BOLSON_CAB> query;
                    query = from rec in context.DLB_LIB_BOLSON_CAB
                            orderby rec.NRO_DOCUMENTO
                            select rec;
                    foreach (var item in query)
                    {
                        var prec = item.ToDto();
                        obtenerDescripciones(ref prec);
                        ltDLB_LIB_BOLSON_CAB.Add(prec);
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltDLB_LIB_BOLSON_CAB;
        }

        // Filtrado.
        public List<DLB_LIB_BOLSON_CAB_DTO> DLB_LIB_BOLSON_CAB_filtrado(DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<DLB_LIB_BOLSON_CAB_DTO> ltDLB_LIB_BOLSON_CAB = new List<DLB_LIB_BOLSON_CAB_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new DLB_LIB_BOLSON_CAB_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltDLB_LIB_BOLSON_CAB; };
                    var filteredCollection = context.DLB_LIB_BOLSON_CAB.OrderBy(x => x.NRO_DOCUMENTO).Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection)
                    {
                        var prec = item.ToDto();
                        obtenerDescripciones(ref prec);
                        ltDLB_LIB_BOLSON_CAB.Add(prec);
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltDLB_LIB_BOLSON_CAB;
        }

        // Inserta.
        public DLB_LIB_BOLSON_CAB_DTO DLB_LIB_BOLSON_CAB_inserta(DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            //try
            //{
                // TODO: Desarrolle su Codigo Aqui.
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    precDto.API_TRANSACCION = "CREAR";
                    precDto.USU_CRE = PAG_ServicesUtil.usuarioPAG;
                    //Insert NewRow Client
                    DLB_LIB_BOLSON_CAB entity = new DLB_LIB_BOLSON_CAB();
                    //try
                    //{
                    //Begin SavePoint
                    using (TransactionScope SavePoint = new TransactionScope())
                    {
                        entity = precDto.ToEntity();
                        context.DLB_LIB_BOLSON_CAB.Add(entity);
                        context.SaveChanges();
                        SavePoint.Complete(); //Commit SavePoint
                    }//End SavePoint
                     //Retuning NewRow DataBase
                    precDto.GESTION = entity.GESTION;
                    precDto.INSTITUCION = entity.INSTITUCION;
                    precDto.GA = entity.GA;
                    precDto.NRO_DOCUMENTO = entity.NRO_DOCUMENTO;
                    precDto.DPTO_LUGAR = entity.DPTO_LUGAR;
                    precDto.MUN_LUGAR = entity.MUN_LUGAR;
                    precDto.TIPO_OPERACION = entity.TIPO_OPERACION;
                    //Retuning NewAudit DataBase
                    precDto.API_ESTADO = entity.API_ESTADO;
                    precDto.API_TRANSACCION = entity.API_TRANSACCION;
                    precDto.USU_CRE = entity.USU_CRE;
                    precDto.FEC_CRE = entity.FEC_CRE;
                    precDto.USU_MOD = null;
                    precDto.FEC_MOD = null;
                    //}
                    //catch (Exception ex)
                    //{
                    //    if (PAG_ServicesUtil.EsErrorORA(ex))
                    //    { throw new FaultException(PAG_ServicesUtil.ObtDescExcepcion(ex, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodExcepcion(ex))); };
                    //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), ex.InnerException.Message);
                    //}
                }
          //  }
            //catch (Exception Ex)
            //{
            //    throw new ApiException(new ApiAttribute() { typeMessage = "PAG", codeMessage = 0, auditMessage = false }, "Error No Controlados de PAGOS.");
            //}
            ////
            return precDto;
        }

        // Actualiza.
        public DLB_LIB_BOLSON_CAB_DTO DLB_LIB_BOLSON_CAB_actualiza(DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
            {
                //Validate RDN
                var entity = context.DLB_LIB_BOLSON_CAB.Find(precDto.GESTION, precDto.INSTITUCION, precDto.GA, precDto.NRO_DOCUMENTO);
                if (entity == null) { throw new FaultException(PAG_ServicesUtil.ObtDescWFCExcepcion("PAG", 2, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodWFCExcepcion("PAG", 2))); } /*"Registro NO Encontrado."*/
                List<API_TRANSICIONES> transicion = context.API_TRANSICIONES.Where(col => col.TABLA == "DLB_LIB_BOLSON_CAB" && col.ESTADO_INICIAL == entity.API_ESTADO && col.TRANSACCION == precDto.API_TRANSACCION).ToList();
                if (transicion.Count == 0) { throw new FaultException(PAG_ServicesUtil.ObtDescWFCExcepcion("PAG", 4, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodWFCExcepcion("PAG", 4))); } /*"Transición NO Definida en Flujo del Registro."*/
                //Assign Data NewRow
                var pEntity = precDto.ToEntity();
                entity.DPTO_LUGAR = pEntity.DPTO_LUGAR;
                entity.MUN_LUGAR = pEntity.MUN_LUGAR;
                entity.TIPO_OPERACION = pEntity.TIPO_OPERACION;
                entity.USU_VERIFICACION = pEntity.USU_VERIFICACION;
                entity.FEC_VERIFICACION = pEntity.FEC_VERIFICACION;
                entity.USU_APROBACION = pEntity.USU_APROBACION;
                entity.FEC_APROBACION = pEntity.FEC_APROBACION;
                entity.API_TRANSACCION = pEntity.API_TRANSACCION;
                entity.USU_MOD = PAG_ServicesUtil.usuarioPAG;
                //Update NewRow Cliente
                //try
                //{
                    //Begin SavePoint
                    using (TransactionScope SavePoint = new TransactionScope())
                    {
                        context.DLB_LIB_BOLSON_CAB.Attach(entity);
                        var entry = context.Entry(entity);
                        entry.State = EntityState.Modified;
                        context.SaveChanges();
                        context.Entry(entity).Reload();
                        SavePoint.Complete(); //Commit SavePoint
                    }//End SavePoint
                     //Retuning NewAudit DataBase
                    precDto.USU_VERIFICACION = entity.USU_VERIFICACION;
                    precDto.FEC_VERIFICACION = entity.FEC_VERIFICACION;
                    precDto.USU_APROBACION = entity.USU_APROBACION;
                    precDto.FEC_APROBACION = entity.FEC_APROBACION;
                    precDto.API_ESTADO = entity.API_ESTADO;
                    precDto.API_TRANSACCION = entity.API_TRANSACCION;
                    precDto.USU_MOD = entity.USU_MOD;
                    precDto.FEC_MOD = entity.FEC_MOD;
                //}
                //catch (Exception ex)
                //{
                //    if (PAG_ServicesUtil.EsErrorORA(ex))
                //    { throw new FaultException(PAG_ServicesUtil.ObtDescExcepcion(ex, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodExcepcion(ex))); };
                //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), ex.InnerException.Message);
                //}
            }
            return precDto;
        }

        // Elimina.
        public DLB_LIB_BOLSON_CAB_DTO DLB_LIB_BOLSON_CAB_elimina(DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            DLB_LIB_BOLSON_CAB_DTO vrecDto = new DLB_LIB_BOLSON_CAB_DTO();
            using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
            {
                //Validate RDN
                var entity = context.DLB_LIB_BOLSON_CAB.Find(precDto.GESTION, precDto.INSTITUCION, precDto.GA, precDto.NRO_DOCUMENTO);
                if (entity == null) { throw new FaultException(PAG_ServicesUtil.ObtDescWFCExcepcion("PAG", 2, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodWFCExcepcion("PAG", 2))); } ///"Registro NO Encontrado."
                entity.API_TRANSACCION = "ELIMINAR";
                entity.USU_MOD = PAG_ServicesUtil.usuarioPAG;
                List<API_TRANSICIONES> transicion = context.API_TRANSICIONES.Where(col => col.TABLA == "DLB_LIB_BOLSON_CAB" && col.ESTADO_INICIAL == entity.API_ESTADO && col.TRANSACCION == entity.API_TRANSACCION).ToList();
                if (transicion.Count == 0) { throw new FaultException(PAG_ServicesUtil.ObtDescWFCExcepcion("PAG", 4, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodWFCExcepcion("PAG", 4))); } //"Transición NO Definida en Flujo del Registro."
                //Update NewRow Cliente
                //try
                //{
                    //Begin SavePoint
                    using (TransactionScope SavePoint = new TransactionScope())
                    {
                        context.DLB_LIB_BOLSON_CAB.Attach(entity);
                        var entry = context.Entry(entity);
                        entry.Property(col => col.API_TRANSACCION).IsModified = true;
                        context.SaveChanges();
                        SavePoint.Complete(); //Commit SavePoint
                    }//End SavePoint
                    vrecDto = entity.ToDto();
                //}
                //catch (Exception ex)
                //{
                //    if (PAG_ServicesUtil.EsErrorORA(ex))
                //    { throw new FaultException(PAG_ServicesUtil.ObtDescExcepcion(ex, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodExcepcion(ex))); };
                //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), ex.InnerException.Message);
                //}
            }
            return vrecDto;
        }
        public DLB_LIB_BOLSON_CAB_DTO DLB_LIB_BOLSON_CAB_verifica(DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
            {
                //try
                //{
                    var entity = context.DLB_LIB_BOLSON_CAB.Find(precDto.GESTION, precDto.INSTITUCION, precDto.GA, precDto.NRO_DOCUMENTO);
                    if (entity == null) { throw new FaultException(PAG_ServicesUtil.ObtDescWFCExcepcion("PAG", 2, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodWFCExcepcion("PAG", 2))); } /*"Registro NO Encontrado."*/
                    List<API_TRANSICIONES> transicion = context.API_TRANSICIONES.Where(col => col.TABLA == "DLB_LIB_BOLSON_CAB" && col.ESTADO_INICIAL == entity.API_ESTADO && col.TRANSACCION == precDto.API_TRANSACCION).ToList();
                    if (transicion.Count == 0) { throw new FaultException(PAG_ServicesUtil.ObtDescWFCExcepcion("PAG", 4, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodWFCExcepcion("PAG", 4))); } /*"Transición NO Definida en Flujo del Registro."*/
                                                                                                                                                                                                              //Assign Data NewRow
                    var pEntity = precDto.ToEntity();
                    entity.USU_VERIFICACION = PAG_ServicesUtil.usuarioPAG;
                    entity.FEC_VERIFICACION = pEntity.FEC_VERIFICACION;
                    entity.API_TRANSACCION = "VERIFICAR";
                    entity.USU_MOD = PAG_ServicesUtil.usuarioPAG;
                    //Begin SavePoint
                    using (TransactionScope SavePoint = new TransactionScope())
                    {
                        context.DLB_LIB_BOLSON_CAB.Attach(entity);
                        var entry = context.Entry(entity);
                        entry.State = EntityState.Modified;
                        context.SaveChanges();
                        context.Entry(entity).Reload();
                        SavePoint.Complete(); //Commit SavePoint
                    }//End SavePoint
                     //Retuning NewAudit DataBase
                    precDto.USU_VERIFICACION = entity.USU_VERIFICACION;
                    precDto.FEC_VERIFICACION = entity.FEC_VERIFICACION;
                    precDto.API_ESTADO = entity.API_ESTADO;
                    precDto.API_TRANSACCION = entity.API_TRANSACCION;
                    precDto.USU_MOD = entity.USU_MOD;
                    precDto.FEC_MOD = entity.FEC_MOD;
                //}
                //catch (Exception ex)
                //{
                //    if (PAG_ServicesUtil.EsErrorORA(ex))
                //    { throw new FaultException(PAG_ServicesUtil.ObtDescExcepcion(ex, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodExcepcion(ex))); };
                //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), ex.InnerException.Message);
                //}
            }
            return precDto;
        }
        public DLB_LIB_BOLSON_CAB_DTO DLB_LIB_BOLSON_CAB_desverifica(DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
            {
                //try
                //{
                    var entity = context.DLB_LIB_BOLSON_CAB.Find(precDto.GESTION, precDto.INSTITUCION, precDto.GA, precDto.NRO_DOCUMENTO);
                    if (entity == null) { throw new FaultException(PAG_ServicesUtil.ObtDescWFCExcepcion("PAG", 2, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodWFCExcepcion("PAG", 2))); } /*"Registro NO Encontrado."*/
                    List<API_TRANSICIONES> transicion = context.API_TRANSICIONES.Where(col => col.TABLA == "DLB_LIB_BOLSON_CAB" && col.ESTADO_INICIAL == entity.API_ESTADO && col.TRANSACCION == precDto.API_TRANSACCION).ToList();
                    if (transicion.Count == 0) { throw new FaultException(PAG_ServicesUtil.ObtDescWFCExcepcion("PAG", 4, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodWFCExcepcion("PAG", 4))); } /*"Transición NO Definida en Flujo del Registro."*/
                                                                                                                                                                                                              //Assign Data NewRow
                    var pEntity = precDto.ToEntity();
                    entity.USU_VERIFICACION = null;
                    entity.FEC_VERIFICACION = null;
                    entity.API_TRANSACCION = "DESVERIFICAR";
                    entity.USU_MOD = PAG_ServicesUtil.usuarioPAG;
                    //Begin SavePoint
                    using (TransactionScope SavePoint = new TransactionScope())
                    {
                        context.DLB_LIB_BOLSON_CAB.Attach(entity);
                        var entry = context.Entry(entity);
                        entry.State = EntityState.Modified;
                        context.SaveChanges();
                        context.Entry(entity).Reload();
                        SavePoint.Complete(); //Commit SavePoint
                    }//End SavePoint
                     //Retuning NewAudit DataBase
                    precDto.USU_VERIFICACION = entity.USU_VERIFICACION;
                    precDto.FEC_VERIFICACION = entity.FEC_VERIFICACION;
                    precDto.API_ESTADO = entity.API_ESTADO;
                    precDto.API_TRANSACCION = entity.API_TRANSACCION;
                    precDto.USU_MOD = entity.USU_MOD;
                    precDto.FEC_MOD = entity.FEC_MOD;
                //}
                //catch (Exception ex)
                //{
                //    if (PAG_ServicesUtil.EsErrorORA(ex))
                //    { throw new FaultException(PAG_ServicesUtil.ObtDescExcepcion(ex, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodExcepcion(ex))); };
                //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), ex.InnerException.Message);
                //}
            }
            return precDto;
        }
        public DLB_LIB_BOLSON_CAB_DTO DLB_LIB_BOLSON_CAB_aprueba(DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
            {
                //try
                //{
                    var entity = context.DLB_LIB_BOLSON_CAB.Find(precDto.GESTION, precDto.INSTITUCION, precDto.GA, precDto.NRO_DOCUMENTO);
                    if (entity == null) { throw new FaultException(PAG_ServicesUtil.ObtDescWFCExcepcion("PAG", 2, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodWFCExcepcion("PAG", 2))); } /*"Registro NO Encontrado."*/
                    List<API_TRANSICIONES> transicion = context.API_TRANSICIONES.Where(col => col.TABLA == "DLB_LIB_BOLSON_CAB" && col.ESTADO_INICIAL == entity.API_ESTADO && col.TRANSACCION == precDto.API_TRANSACCION).ToList();
                    if (transicion.Count == 0) { throw new FaultException(PAG_ServicesUtil.ObtDescWFCExcepcion("PAG", 4, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodWFCExcepcion("PAG", 4))); } /*"Transición NO Definida en Flujo del Registro."*/
                                                                                                                                                                                                              //Assign Data NewRow
                    var pEntity = precDto.ToEntity();
                    entity.USU_APROBACION = PAG_ServicesUtil.usuarioPAG;
                    entity.FEC_APROBACION = pEntity.FEC_APROBACION;
                    entity.API_TRANSACCION = "APROBAR";
                    entity.USU_MOD = PAG_ServicesUtil.usuarioPAG;
                    //Begin SavePoint
                    using (TransactionScope SavePoint = new TransactionScope())
                    {
                        context.DLB_LIB_BOLSON_CAB.Attach(entity);
                        var entry = context.Entry(entity);
                        entry.State = EntityState.Modified;
                        context.SaveChanges();
                        context.Entry(entity).Reload();
                        SavePoint.Complete(); //Commit SavePoint
                    }//End SavePoint
                     //Retuning NewAudit DataBase
                    precDto.USU_APROBACION = entity.USU_APROBACION;
                    precDto.FEC_APROBACION = entity.FEC_APROBACION;
                    precDto.API_ESTADO = entity.API_ESTADO;
                    precDto.API_TRANSACCION = entity.API_TRANSACCION;
                    precDto.USU_MOD = entity.USU_MOD;
                    precDto.FEC_MOD = entity.FEC_MOD;
                //}
                //catch (Exception ex)
                //{
                //    if (PAG_ServicesUtil.EsErrorORA(ex))
                //    { throw new FaultException(PAG_ServicesUtil.ObtDescExcepcion(ex, soloMensaje: true), new FaultCode(PAG_ServicesUtil.ObtCodExcepcion(ex))); };
                //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), ex.InnerException.Message);
                //}
            }
            return precDto;
        }
        // DESCRIPCIONES.
        private void obtenerDescripciones(ref DLB_LIB_BOLSON_CAB_DTO precDto)
        {
            using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
            {
                var prec = precDto;
                // Descripción de institución
                List<INSTITUCIONES> lov_ins = context.INSTITUCIONES.Where(col => col.INSTITUCION == prec.INSTITUCION).ToList();
                if (lov_ins.Count > 0) { precDto.DESC_INSTITUCION = lov_ins.FirstOrDefault().DESC_INSTITUCION; }
                // Descripción de GA
                var entityGA = new GERENCIAS_ADMINISTRATIVAS();
                entityGA.GESTION = prec.GESTION;
                entityGA.INSTITUCION = prec.INSTITUCION;
                entityGA.GA = prec.GA;
                var filterGA = new GERENCIAS_ADMINISTRATIVAS_FILTER();
                var delegatesGA = filterGA.GetExpression(entityGA);
                List<GERENCIAS_ADMINISTRATIVAS> lov_ga = context.GERENCIAS_ADMINISTRATIVAS.Where(delegatesGA).ToList();
                if (lov_ga.Count > 0) { precDto.DESC_GA = lov_ga.FirstOrDefault().DESC_GA; }
                // Descripcion de Lugar
                var entityLUGAR = new MUNICIPIOS();
                entityLUGAR.DEPARTAMENTO = prec.DPTO_LUGAR;
                entityLUGAR.MUNICIPIO = prec.MUN_LUGAR;
                var filterLUGAR = new MUNICIPIOS_FILTER();
                var delegatesLUGAR = filterLUGAR.GetExpression(entityLUGAR);
                List<MUNICIPIOS> lov_lugar = context.MUNICIPIOS.Where(delegatesLUGAR).ToList();
                if (lov_lugar.Count > 0) { precDto.DESC_LUGAR = lov_lugar.FirstOrDefault().DESC_MUNICIPIO; }
                //Descripción Tipo Operación
                var entityCG_REF_CODES = new CG_REF_CODES();
                entityCG_REF_CODES.RV_DOMAIN = "TIPO_OPERACION";
                entityCG_REF_CODES.RV_LOW_VALUE = prec.TIPO_OPERACION;
                var filterCG_REF_CODES = new CG_REF_CODES_FILTER();
                var delegatesCG_REF_CODES = filterCG_REF_CODES.GetExpression(entityCG_REF_CODES);
                List<CG_REF_CODES> lov_CG_REF_CODES = context.CG_REF_CODES.Where(delegatesCG_REF_CODES).ToList();
                if (lov_CG_REF_CODES.Count > 0) { precDto.DESC_TIPO_OPERACION = lov_CG_REF_CODES.FirstOrDefault().RV_MEANING; }

            }
        }

    }
}