using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

namespace PAG_WCF
{
    public class DEDUCCIONES_RDN
    {
        public List<DEDUCCIONES_DTO> DEDUCCIONES_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<DEDUCCIONES_DTO> ltDEDUCCIONES = new List<DEDUCCIONES_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<DEDUCCIONES> query;
                    query = from rec in context.DEDUCCIONES
                            select rec;
                    foreach (var item in query)
                    {
                        ltDEDUCCIONES.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltDEDUCCIONES;
        }

        public List<DEDUCCIONES_DTO> DEDUCCIONES_filtrado(DEDUCCIONES_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<DEDUCCIONES_DTO> ltDEDUCCIONES = new List<DEDUCCIONES_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new DEDUCCIONES_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltDEDUCCIONES; };
                    var filteredCollection = context.DEDUCCIONES.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltDEDUCCIONES.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltDEDUCCIONES;
        }
    }
}
