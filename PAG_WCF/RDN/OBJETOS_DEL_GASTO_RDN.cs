using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

namespace PAG_WCF
{
    public class OBJETOS_DEL_GASTO_RDN
    {
        public List<OBJETOS_DEL_GASTO_DTO> OBJETOS_DEL_GASTO_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<OBJETOS_DEL_GASTO_DTO> ltOBJETOS_DEL_GASTO = new List<OBJETOS_DEL_GASTO_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<OBJETOS_DEL_GASTO> query;
                    query = from rec in context.OBJETOS_DEL_GASTO
                            select rec;
                    foreach (var item in query)
                    {
                        ltOBJETOS_DEL_GASTO.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltOBJETOS_DEL_GASTO;
        }

        public List<OBJETOS_DEL_GASTO_DTO> OBJETOS_DEL_GASTO_filtrado(OBJETOS_DEL_GASTO_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<OBJETOS_DEL_GASTO_DTO> ltOBJETOS_DEL_GASTO = new List<OBJETOS_DEL_GASTO_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new OBJETOS_DEL_GASTO_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltOBJETOS_DEL_GASTO; };
                    var filteredCollection = context.OBJETOS_DEL_GASTO.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltOBJETOS_DEL_GASTO.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltOBJETOS_DEL_GASTO;
        }
    }
}