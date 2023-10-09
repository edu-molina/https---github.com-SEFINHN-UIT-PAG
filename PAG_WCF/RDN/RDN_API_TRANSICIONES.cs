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

namespace PAG_WCF
{
    #region SVC-API_TRANSACCIONES

    #endregion

    #region RDN-API_TRANSACCIONES
    public class RDN_API_TRANSICIONES
    {
        public List<AUX_LOVS_DTO> API_TRANSICIONES_listado()
        {
            List<AUX_LOVS_DTO> ltv_API_TRANSICIONES = new List<AUX_LOVS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<API_TRANSICIONES> query;
                    query = from rec in context.API_TRANSICIONES
                            select rec;
                    foreach (var item in query)
                    {
                        ltv_API_TRANSICIONES.Add(item.ToTRANSIDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltv_API_TRANSICIONES;
        }

        public List<AUX_LOVS_DTO> API_TRANSICIONES_filtrado(AUX_LOVS_DTO precLovs)
        {
            List<AUX_LOVS_DTO> ltv_API_TRANSICIONES = new List<AUX_LOVS_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    //Aplicar pFilter Dinamico
                    var entity = new API_TRANSICIONES() { TABLA = precLovs.LOV_NOMBRE, ESTADO_INICIAL = precLovs.LOV_CODIGO };
                    var delegates = new API_TRANSICIONES_FILTERS().GetExpression(entity);
                    var filteredCollection = context.API_TRANSICIONES.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    bool contar = new bool() { };
                    foreach (var item in filteredCollection)
                    {
                        if (item.ESTADO_FINAL == precLovs.LOV_CODIGO) { contar = true; };
                        ltv_API_TRANSICIONES.Add(item.ToTRANSIDto());
                    }
                    if (contar == false) { ltv_API_TRANSICIONES.Add(new AUX_LOVS_DTO { LOV_NOMBRE = precLovs.LOV_NOMBRE, LOV_CODIGO = precLovs.LOV_CODIGO, LOV_DESCRIPCION = "DESPLEGAR", LOV_VALOR_01 = precLovs.LOV_CODIGO }); };
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return ltv_API_TRANSICIONES;
        }
    }
    #endregion

    #region FILTERS-API_TRANSACCIONES
    public class API_TRANSICIONES_FILTERS : PAG_DTO.ExpressionBuilder<API_TRANSICIONES>
    {
        public override void build(API_TRANSICIONES da)
        {
            //Generar pFilter: Equals
            if (String.IsNullOrEmpty(da.TABLA) == false) and(col => col.TABLA == da.TABLA);
            if (String.IsNullOrEmpty(da.ESTADO_INICIAL) == false) and(col => col.ESTADO_INICIAL == da.ESTADO_INICIAL);
        }
    }
    #endregion

}