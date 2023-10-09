
using PAG_DA;
using PAG_DTO;
using PAG_INTERFACES;
using PAG_MAPPERS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
//
using System.Runtime.Serialization;
using System.Reflection;
using System.Diagnostics;
using System.ServiceModel.Channels;

namespace PAG_WCF
{
    public class INSTITUCIONES_RDN
    {
        public List<INSTITUCIONES_DTO> INSTITUCIONES_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<INSTITUCIONES_DTO> ltINSTITUCIONES = new List<INSTITUCIONES_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<INSTITUCIONES> query;
                    query = from rec in context.INSTITUCIONES
                            select rec;
                    foreach (var item in query)
                    {
                        ltINSTITUCIONES.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltINSTITUCIONES;
        }

        public List<INSTITUCIONES_DTO> INSTITUCIONES_filtrado(INSTITUCIONES_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<INSTITUCIONES_DTO> ltINSTITUCIONES = new List<INSTITUCIONES_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new INSTITUCIONES_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltINSTITUCIONES; };
                    var filteredCollection = context.INSTITUCIONES.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltINSTITUCIONES.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltINSTITUCIONES;
        }
    }
}