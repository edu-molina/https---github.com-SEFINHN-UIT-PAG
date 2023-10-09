using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DTO;
using PAG_DA;
using PAG_MAPPERS;

namespace PAG_WCF
{
    public class EGA_PARTIDAS_RDN
    {
        public List<EGA_PARTIDAS_DTO> EGA_PARTIDAS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<EGA_PARTIDAS_DTO> ltEGA_PARTIDAS = new List<EGA_PARTIDAS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<EGA_PARTIDAS> query;
                    query = from rec in context.EGA_PARTIDAS
                            select rec;
                    foreach (var item in query)
                    {
                        ltEGA_PARTIDAS.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltEGA_PARTIDAS;
        }

        public List<EGA_PARTIDAS_DTO> EGA_PARTIDAS_filtrado(EGA_PARTIDAS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<EGA_PARTIDAS_DTO> ltEGA_PARTIDAS = new List<EGA_PARTIDAS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new EGA_PARTIDAS_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltEGA_PARTIDAS; };
                    var filteredCollection = context.EGA_PARTIDAS.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltEGA_PARTIDAS.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltEGA_PARTIDAS;
        }
    }
}