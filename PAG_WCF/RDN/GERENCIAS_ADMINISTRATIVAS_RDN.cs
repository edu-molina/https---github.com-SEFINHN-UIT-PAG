using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

namespace PAG_WCF
{
    public class GERENCIAS_ADMINISTRATIVAS_RDN
    {
        public List<GERENCIAS_ADMINISTRATIVAS_DTO> GERENCIAS_ADMINISTRATIVAS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<GERENCIAS_ADMINISTRATIVAS_DTO> ltGERENCIAS_ADMINISTRATIVAS = new List<GERENCIAS_ADMINISTRATIVAS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<GERENCIAS_ADMINISTRATIVAS> query;
                    query = from rec in context.GERENCIAS_ADMINISTRATIVAS
                            select rec;
                    foreach (var item in query)
                    {
                        ltGERENCIAS_ADMINISTRATIVAS.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltGERENCIAS_ADMINISTRATIVAS;
        }

        public List<GERENCIAS_ADMINISTRATIVAS_DTO> GERENCIAS_ADMINISTRATIVAS_filtrado(GERENCIAS_ADMINISTRATIVAS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<GERENCIAS_ADMINISTRATIVAS_DTO> ltGERENCIAS_ADMINISTRATIVAS = new List<GERENCIAS_ADMINISTRATIVAS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new GERENCIAS_ADMINISTRATIVAS_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltGERENCIAS_ADMINISTRATIVAS; };
                    var filteredCollection = context.GERENCIAS_ADMINISTRATIVAS.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltGERENCIAS_ADMINISTRATIVAS.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltGERENCIAS_ADMINISTRATIVAS;
        }
    }
}