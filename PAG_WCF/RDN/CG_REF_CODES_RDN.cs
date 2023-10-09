using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

/// <summary>
/// Clase CG_REF_CODES_RDN
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>


namespace PAG_WCF
{
    public class CG_REF_CODES_RDN
    {
        public List<CG_REF_CODES_DTO> CG_REF_CODES_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<CG_REF_CODES_DTO> ltCG_REF_CODES = new List<CG_REF_CODES_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<CG_REF_CODES> query;
                    query = from rec in context.CG_REF_CODES
                            select rec;
                    foreach (var item in query)
                    {
                        ltCG_REF_CODES.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltCG_REF_CODES;
        }

        public List<CG_REF_CODES_DTO> CG_REF_CODES_filtrado(CG_REF_CODES_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<CG_REF_CODES_DTO> ltCG_REF_CODES = new List<CG_REF_CODES_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new CG_REF_CODES_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltCG_REF_CODES; };
                    var filteredCollection = context.CG_REF_CODES.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltCG_REF_CODES.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltCG_REF_CODES;
        }
    }
}