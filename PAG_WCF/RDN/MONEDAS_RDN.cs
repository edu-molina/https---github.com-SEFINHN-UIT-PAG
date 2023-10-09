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
    public class MONEDAS_RDN
    {
        public List<MONEDAS_DTO> MONEDAS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<MONEDAS_DTO> ltMONEDAS = new List<MONEDAS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<MONEDAS> query;
                    query = from rec in context.MONEDAS
                            select rec;
                    foreach (var item in query)
                    {
                        ltMONEDAS.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltMONEDAS;
        }

        public List<MONEDAS_DTO> MONEDAS_filtrado(MONEDAS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<MONEDAS_DTO> ltMONEDAS = new List<MONEDAS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new MONEDAS_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltMONEDAS; };
                    var filteredCollection = context.MONEDAS.OrderBy(x => x.MONEDA).Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltMONEDAS.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltMONEDAS;
        }
    }
}
