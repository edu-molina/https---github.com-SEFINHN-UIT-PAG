using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

namespace PAG_WCF
{
    public class CLASES_DE_GASTO_CIP_RDN
    {
        public List<CLASES_DE_GASTO_CIP_DTO> CLASES_DE_GASTO_CIP_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<CLASES_DE_GASTO_CIP_DTO> ltCLASES_DE_GASTO_CIP = new List<CLASES_DE_GASTO_CIP_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<CLASES_DE_GASTO_CIP> query;
                    query = from rec in context.CLASES_DE_GASTO_CIP
                            select rec;
                    foreach (var item in query)
                    {
                        ltCLASES_DE_GASTO_CIP.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltCLASES_DE_GASTO_CIP;
        }

        public List<CLASES_DE_GASTO_CIP_DTO> CLASES_DE_GASTO_CIP_filtrado(CLASES_DE_GASTO_CIP_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<CLASES_DE_GASTO_CIP_DTO> ltCLASES_DE_GASTO_CIP = new List<CLASES_DE_GASTO_CIP_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new CLASES_DE_GASTO_CIP_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltCLASES_DE_GASTO_CIP; };
                    var filteredCollection = context.CLASES_DE_GASTO_CIP.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltCLASES_DE_GASTO_CIP.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltCLASES_DE_GASTO_CIP;
        }
    }
}