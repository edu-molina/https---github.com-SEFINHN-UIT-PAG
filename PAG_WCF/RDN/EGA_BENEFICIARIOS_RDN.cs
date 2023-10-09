using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

/// <summary>
/// Clase EGA_BENEFICIARIOS_RDN
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>


namespace PAG_WCF
{
    public class EGA_BENEFICIARIOS_RDN
    {
        public List<EGA_BENEFICIARIOS_DTO> EGA_BENEFICIARIOS_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<EGA_BENEFICIARIOS_DTO> ltEGA_BENEFICIARIOS = new List<EGA_BENEFICIARIOS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<EGA_BENEFICIARIOS> query;
                    query = from rec in context.EGA_BENEFICIARIOS
                            select rec;
                    foreach (var item in query)
                    {
                        ltEGA_BENEFICIARIOS.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltEGA_BENEFICIARIOS;
        }

        public List<EGA_BENEFICIARIOS_DTO> EGA_BENEFICIARIOS_filtrado(EGA_BENEFICIARIOS_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<EGA_BENEFICIARIOS_DTO> ltEGA_BENEFICIARIOS = new List<EGA_BENEFICIARIOS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new EGA_BENEFICIARIOS_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltEGA_BENEFICIARIOS; };
                    var filteredCollection = context.EGA_BENEFICIARIOS.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { ltEGA_BENEFICIARIOS.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltEGA_BENEFICIARIOS;
        }
    }
}