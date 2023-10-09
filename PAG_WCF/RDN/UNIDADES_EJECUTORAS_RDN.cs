using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

/// <summary>
/// Clase UNIDADES_EJECUTORAS_RDN
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>


namespace PAG_WCF
{
  
        public class UNIDADES_EJECUTORAS_RDN
    {
            public List<UNIDADES_EJECUTORAS_DTO> UNIDADES_EJECUTORAS_listado()
            {
                // TODO: Desarrolle su Codigo Aqui.
                List<UNIDADES_EJECUTORAS_DTO> ltUNIDADES_EJECUTORAS = new List<UNIDADES_EJECUTORAS_DTO>();
                //try
                //{
                    using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                    {
                        IQueryable<UNIDADES_EJECUTORAS> query;
                        query = from rec in context.UNIDADES_EJECUTORAS
                                select rec;
                        foreach (var item in query)
                        {
                            ltUNIDADES_EJECUTORAS.Add(item.ToDto());
                        }
                    }
                //}
                //catch (Exception Ex)
                //{
                //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
                //}
                return ltUNIDADES_EJECUTORAS;
            }

            public List<UNIDADES_EJECUTORAS_DTO> UNIDADES_EJECUTORAS_filtrado(UNIDADES_EJECUTORAS_DTO precDto)
            {
                // TODO: Desarrolle su Codigo Aqui.
                List<UNIDADES_EJECUTORAS_DTO> ltUNIDADES_EJECUTORAS = new List<UNIDADES_EJECUTORAS_DTO>();
                //try
                //{
                    using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                    {
                        var entity = precDto.ToEntity();
                        var filters = new UNIDADES_EJECUTORAS_FILTER();
                        var delegates = filters.GetExpression(entity);
                        //Aplicar pFilters Dinamico
                        if (!filters.hasFilters) { return ltUNIDADES_EJECUTORAS; };
                        var filteredCollection = context.UNIDADES_EJECUTORAS.Where(delegates).ToList();
                        //Transformar pFilter Dinamico
                        foreach (var item in filteredCollection) { ltUNIDADES_EJECUTORAS.Add(item.ToDto()); }
                    }
                //}
                //catch (Exception Ex)
                //{
                //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
                //}
                return ltUNIDADES_EJECUTORAS;
            }
        }
    }
