using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

namespace PAG_WCF
{
    public class BEN_TIPOS_IDENTIFICACION_RDN
    {
        public List<BEN_TIPOS_IDENTIFICACION_DTO> BEN_TIPOS_IDENTIFICACION_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<BEN_TIPOS_IDENTIFICACION_DTO> ltBEN_TIPOS_IDENTIFICACION = new List<BEN_TIPOS_IDENTIFICACION_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<BEN_TIPOS_IDENTIFICACION> query;
                    query = from rec in context.BEN_TIPOS_IDENTIFICACION
                            select rec;
                    foreach (var item in query)
                    {
                        ltBEN_TIPOS_IDENTIFICACION.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltBEN_TIPOS_IDENTIFICACION;
        }

        public List<BEN_TIPOS_IDENTIFICACION_DTO> BEN_TIPOS_IDENTIFICACION_filtrado(BEN_TIPOS_IDENTIFICACION_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<BEN_TIPOS_IDENTIFICACION_DTO> ltBEN_TIPOS_IDENTIFICACION = new List<BEN_TIPOS_IDENTIFICACION_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new BEN_TIPOS_IDENTIFICACION_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltBEN_TIPOS_IDENTIFICACION; };
                    var filteredCollection = context.BEN_TIPOS_IDENTIFICACION.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltBEN_TIPOS_IDENTIFICACION.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltBEN_TIPOS_IDENTIFICACION;
        }
    }
}