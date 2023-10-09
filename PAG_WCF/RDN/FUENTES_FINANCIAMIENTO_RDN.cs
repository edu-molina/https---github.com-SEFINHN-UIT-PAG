using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

namespace PAG_WCF
{
    public class FUENTES_FINANCIAMIENTO_RDN
    {
            public List<FUENTES_FINANCIAMIENTO_DTO> FUENTES_FINANCIAMIENTO_listado()
            {
                // TODO: Desarrolle su Codigo Aqui.
                List<FUENTES_FINANCIAMIENTO_DTO> ltFUENTES_FINANCIAMIENTO = new List<FUENTES_FINANCIAMIENTO_DTO>();
                //try
                //{
                    using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                    {
                        IQueryable<FUENTES_FINANCIAMIENTO> query;
                        query = from rec in context.FUENTES_FINANCIAMIENTO
                                select rec;
                        foreach (var item in query)
                        {
                            ltFUENTES_FINANCIAMIENTO.Add(item.ToDto());
                        }
                    }
                //}
                //catch (Exception Ex)
                //{
                //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
                //}
                return ltFUENTES_FINANCIAMIENTO;
            }

            public List<FUENTES_FINANCIAMIENTO_DTO> FUENTES_FINANCIAMIENTO_filtrado(FUENTES_FINANCIAMIENTO_DTO precDto)
            {
                // TODO: Desarrolle su Codigo Aqui.
                List<FUENTES_FINANCIAMIENTO_DTO> ltFUENTES_FINANCIAMIENTO = new List<FUENTES_FINANCIAMIENTO_DTO>();
                //try
                //{
                    using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                    {
                        var entity = precDto.ToEntity();
                        var filters = new FUENTES_FINANCIAMIENTO_FILTER();
                        var delegates = filters.GetExpression(entity);
                        //Aplicar pFilters Dinamico
                        if (!filters.hasFilters) { return ltFUENTES_FINANCIAMIENTO; };
                        var filteredCollection = context.FUENTES_FINANCIAMIENTO.OrderBy(x => x.FUENTE).Where(delegates).ToList();
                        //Transformar pFilter Dinamico
                        foreach (var item in filteredCollection) { ltFUENTES_FINANCIAMIENTO.Add(item.ToDto()); }
                    }
                //}
                //catch (Exception Ex)
                //{
                //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
                //}
                return ltFUENTES_FINANCIAMIENTO;
            }
        }
}