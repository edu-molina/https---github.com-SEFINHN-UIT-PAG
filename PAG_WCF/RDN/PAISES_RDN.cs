using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;


namespace PAG_WCF
{
    public class PAISES_RDN
    {
        public List<PAISES_DTO> PAISES_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<PAISES_DTO> ltPAISES = new List<PAISES_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<PAISES> query;
                    query = from rec in context.PAISES
                            select rec;
                    foreach (var item in query)
                    {
                        ltPAISES.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltPAISES;
        }

        public List<PAISES_DTO> PAISES_filtrado(PAISES_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<PAISES_DTO> ltPAISES = new List<PAISES_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new PAISES_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltPAISES; };
                    var filteredCollection = context.PAISES.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltPAISES.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltPAISES;
        }
    }
}