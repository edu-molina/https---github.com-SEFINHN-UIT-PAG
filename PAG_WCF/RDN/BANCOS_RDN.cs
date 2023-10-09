using System;
using System.Collections.Generic;
using System.Linq;
using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;
using System.ServiceModel;


namespace PAG_WCF
{
    public class BANCOS_RDN
    {
        public List<BANCOS_DTO> BANCOS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<BANCOS_DTO> ltBANCOS = new List<BANCOS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<BANCOS> query;
                    query = from rec in context.BANCOS
                            select rec;
                    foreach (var item in query)
                    {
                        ltBANCOS.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltBANCOS;
        }

        public List<BANCOS_DTO> BANCOS_filtrado(BANCOS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<BANCOS_DTO> ltBANCOS = new List<BANCOS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new BANCOS_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltBANCOS; };
                    var filteredCollection = context.BANCOS.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltBANCOS.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltBANCOS;
        }
    }
}
