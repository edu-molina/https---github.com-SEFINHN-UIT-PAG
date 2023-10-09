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
    public class LIBROS_BANCO_RDN
    {
        public List<LIBROS_BANCO_DTO> LIBROS_BANCO_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<LIBROS_BANCO_DTO> ltLIBROS_BANCO = new List<LIBROS_BANCO_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<LIBROS_BANCO> query;
                    query = from rec in context.LIBROS_BANCO
                            select rec;
                    foreach (var item in query)
                    {
                        var pDto = item.ToDto();
                        obtenerDescripciones(ref pDto);
                        ltLIBROS_BANCO.Add(pDto);
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltLIBROS_BANCO;
        }

        public List<LIBROS_BANCO_DTO> LIBROS_BANCO_filtrado(LIBROS_BANCO_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<LIBROS_BANCO_DTO> ltLIBROS_BANCO = new List<LIBROS_BANCO_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new LIBROS_BANCO_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return ltLIBROS_BANCO; };
                    var filteredCollection = context.LIBROS_BANCO.OrderBy(x => x.CUENTA).Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) {
                        var pDto = item.ToDto();
                        obtenerDescripciones(ref pDto);
                        ltLIBROS_BANCO.Add(pDto);
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltLIBROS_BANCO;
        }
        public void obtenerDescripciones(ref LIBROS_BANCO_DTO precDto)
        {
            using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
            {
                var prec = precDto;
                // Descripción de Cuenta
                List<CUENTAS_BANCARIAS> lov_ctas = context.CUENTAS_BANCARIAS.Where(col => col.BANCO == prec.BANCO && col.CUENTA == prec.CUENTA).ToList();
                if (lov_ctas.Count > 0) { precDto.DESC_CUENTA = lov_ctas.FirstOrDefault().DESC_CUENTA; }
                // Descripción de GA
            }
        }
    }
}
