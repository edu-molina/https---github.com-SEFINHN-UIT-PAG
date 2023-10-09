using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

namespace PAG_WCF
{
    public class BENEFICIARIOS_RDN
    {
        public List<BENEFICIARIOS_DTO> BENEFICIARIOS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<BENEFICIARIOS_DTO> ltBENEFICIARIOS = new List<BENEFICIARIOS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<BENEFICIARIOS> query;
                    query = from rec in context.BENEFICIARIOS
                            select rec;
                    foreach (var item in query)
                    {
                        ltBENEFICIARIOS.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltBENEFICIARIOS;
        }

        public List<BENEFICIARIOS_DTO> BENEFICIARIOS_filtrado(BENEFICIARIOS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<BENEFICIARIOS_DTO> ltBENEFICIARIOS = new List<BENEFICIARIOS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new BENEFICIARIOS_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltBENEFICIARIOS; };
                    var filteredCollection = context.BENEFICIARIOS.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltBENEFICIARIOS.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltBENEFICIARIOS;
        }
    }
}