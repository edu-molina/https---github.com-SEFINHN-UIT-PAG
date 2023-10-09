using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

namespace PAG_WCF
{
    public class MUNICIPIOS_RDN
    {
        public List<MUNICIPIOS_DTO> MUNICIPIOS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<MUNICIPIOS_DTO> ltMUNICIPIOS = new List<MUNICIPIOS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<MUNICIPIOS> query;
                    query = from rec in context.MUNICIPIOS
                            select rec;
                    foreach (var item in query)
                    {
                        ltMUNICIPIOS.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltMUNICIPIOS;
        }

        public List<MUNICIPIOS_DTO> MUNICIPIOS_filtrado(MUNICIPIOS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<MUNICIPIOS_DTO> ltMUNICIPIOS = new List<MUNICIPIOS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new MUNICIPIOS_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltMUNICIPIOS; };
                    var filteredCollection = context.MUNICIPIOS.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltMUNICIPIOS.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltMUNICIPIOS;
        }
    }
}