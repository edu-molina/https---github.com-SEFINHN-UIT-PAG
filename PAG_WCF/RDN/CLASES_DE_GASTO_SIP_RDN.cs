using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

namespace PAG_WCF
{
    public class CLASES_DE_GASTO_SIP_RDN
    {
        public List<CLASES_DE_GASTO_SIP_DTO> CLASES_DE_GASTO_SIP_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<CLASES_DE_GASTO_SIP_DTO> ltCLASES_DE_GASTO_SIP = new List<CLASES_DE_GASTO_SIP_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<CLASES_DE_GASTO_SIP> query;
                    query = from rec in context.CLASES_DE_GASTO_SIP
                            select rec;
                    foreach (var item in query)
                    {
                        ltCLASES_DE_GASTO_SIP.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltCLASES_DE_GASTO_SIP;
        }

        public List<CLASES_DE_GASTO_SIP_DTO> CLASES_DE_GASTO_SIP_filtrado(CLASES_DE_GASTO_SIP_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<CLASES_DE_GASTO_SIP_DTO> ltCLASES_DE_GASTO_SIP = new List<CLASES_DE_GASTO_SIP_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new CLASES_DE_GASTO_SIP_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltCLASES_DE_GASTO_SIP; };
                    var filteredCollection = context.CLASES_DE_GASTO_SIP.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltCLASES_DE_GASTO_SIP.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltCLASES_DE_GASTO_SIP;
        }
    }
}