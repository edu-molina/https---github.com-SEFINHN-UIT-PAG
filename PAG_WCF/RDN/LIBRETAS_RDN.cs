using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;
using System.ServiceModel;


namespace PAG_WCF
{
    public class LIBRETAS_RDN
    {
        public List<LIBRETAS_DTO> LIBRETAS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<LIBRETAS_DTO> ltLIBRETAS = new List<LIBRETAS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<LIBRETAS> query;
                    query = from rec in context.LIBRETAS
                            select rec;
                    foreach (var item in query)
                    {
                        ltLIBRETAS.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltLIBRETAS;
        }

        public List<LIBRETAS_DTO> LIBRETAS_filtrado(LIBRETAS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<LIBRETAS_DTO> ltLIBRETAS = new List<LIBRETAS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new LIBRETAS_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltLIBRETAS; };
                    var filteredCollection = context.LIBRETAS.OrderBy(x => x.LIBRETA).Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltLIBRETAS.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltLIBRETAS;
        }
    }
}
