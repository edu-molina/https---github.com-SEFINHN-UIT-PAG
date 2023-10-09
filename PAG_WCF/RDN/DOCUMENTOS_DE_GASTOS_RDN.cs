using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

/// <summary>
/// Clase DOCUMENTOS_DE_GASTOS_RDN
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>

namespace PAG_WCF
{
    public class DOCUMENTOS_DE_GASTOS_RDN
    {
        public List<DOCUMENTOS_DE_GASTOS_DTO> DOCUMENTOS_DE_GASTOS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<DOCUMENTOS_DE_GASTOS_DTO> ltDOCUMENTOS_DE_GASTOS = new List<DOCUMENTOS_DE_GASTOS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<DOCUMENTOS_DE_GASTOS> query;
                    query = from rec in context.DOCUMENTOS_DE_GASTOS
                            select rec;
                    foreach (var item in query)
                    {
                        ltDOCUMENTOS_DE_GASTOS.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltDOCUMENTOS_DE_GASTOS;
        }

        public List<DOCUMENTOS_DE_GASTOS_DTO> DOCUMENTOS_DE_GASTOS_filtrado(DOCUMENTOS_DE_GASTOS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<DOCUMENTOS_DE_GASTOS_DTO> ltDOCUMENTOS_DE_GASTOS = new List<DOCUMENTOS_DE_GASTOS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new DOCUMENTOS_DE_GASTOS_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltDOCUMENTOS_DE_GASTOS; };
                    var filteredCollection = context.DOCUMENTOS_DE_GASTOS.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltDOCUMENTOS_DE_GASTOS.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltDOCUMENTOS_DE_GASTOS;
        }
    }
}
