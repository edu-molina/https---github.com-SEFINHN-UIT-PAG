using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

//Agregado por DSA

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;
using PAG_INTERFACES;
using System.Reflection;
using System.Data;
using System.Transactions;
using System.Diagnostics;
using System.ServiceModel.Channels;
using System.Linq.Expressions;


namespace PAG_WCF
{
    #region SVC-API_LISTA_VALORES

    #endregion
    
    #region RDN-API_LISTA_VALORES
    public class RDN_API_LISTA_VALORES
    {
        public List<AUX_LOVS_DTO> AUX_LOVS_listado()
        {
            List<AUX_LOVS_DTO> ltv_PAG_REF_CODES = new List<AUX_LOVS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<CG_REF_CODES> query;
                    query = from rec in context.CG_REF_CODES
                            select rec;
                    foreach (var item in query)
                    {
                        ltv_PAG_REF_CODES.Add(item.ToLovDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltv_PAG_REF_CODES;
        }

        public List<AUX_LOVS_DTO> AUX_LOVS_filtrado(AUX_LOVS_DTO precLovs)
        {
            List<AUX_LOVS_DTO> ltv_PAG_REF_CODES = new List<AUX_LOVS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    //Aplicar pFilter Dinamico
                    var entity = new CG_REF_CODES() { RV_DOMAIN = precLovs.LOV_NOMBRE, RV_LOW_VALUE = precLovs.LOV_CODIGO, RV_MEANING = precLovs.LOV_DESCRIPCION };
                    var delegates = new API_LISTA_VALORES_FILTERS().GetExpression(entity);
                    var filteredCollection = context.CG_REF_CODES.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection)
                    {
                        ltv_PAG_REF_CODES.Add(item.ToLovDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltv_PAG_REF_CODES;
        }
    }
    #endregion

    #region FILTERS-API_LISTA_VALORES
    public class API_LISTA_VALORES_FILTERS : PAG_DTO.ExpressionBuilder<CG_REF_CODES>
    {
        public override void build(CG_REF_CODES da)
        {
            //Generar pFilter: Equals
            if (String.IsNullOrEmpty(da.RV_DOMAIN) == false) and(col => col.RV_DOMAIN == da.RV_DOMAIN);
            if (String.IsNullOrEmpty(da.RV_LOW_VALUE) == false) and(col => col.RV_LOW_VALUE == da.RV_LOW_VALUE);
            //Generar pFilter: Contains
            if (String.IsNullOrEmpty(da.RV_MEANING) == false) and(col => col.RV_MEANING.Contains(da.RV_MEANING));
        }
    }
    #endregion
}