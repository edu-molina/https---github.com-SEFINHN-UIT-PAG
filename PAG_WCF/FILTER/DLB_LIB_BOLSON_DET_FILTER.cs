//------------------------------------------------------------------------------
//                         Secretaria de Finanzas
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using PAG_DA;
using PAG_DTO;
using PAG_INTERFACES;
using PAG_MAPPERS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.ServiceModel;


namespace PAG_WCF
{
    
    
    public class DLB_LIB_BOLSON_DET_FILTER : ExpressionBuilder<DLB_LIB_BOLSON_DET>
    {
        
        public override void build(DLB_LIB_BOLSON_DET da)
        {
            and(col => col.GESTION == da.GESTION);
            and(col => col.INSTITUCION == da.INSTITUCION);
            and(col => col.GA == da.GA);
            and(col => col.NRO_DOCUMENTO == da.NRO_DOCUMENTO);
            if (da.SECUENCIA > 0) and(col => col.SECUENCIA == da.SECUENCIA);
            if (da.PAG_INSTITUCION > 0) and(col => col.PAG_INSTITUCION == da.PAG_INSTITUCION);
            if (da.PAG_GA > 0) and(col => col.PAG_GA == da.PAG_GA);
            if (da.LIB_GESTION > 0) and(col => col.LIB_GESTION == da.LIB_GESTION);
            if (da.LIB_BANCO > 0) and(col => col.LIB_BANCO == da.LIB_BANCO);
            if (String.IsNullOrEmpty(da.LIB_CUENTA) == false) and(col => col.LIB_CUENTA.Contains(da.LIB_CUENTA));
            if (String.IsNullOrEmpty(da.LIB_LIBRETA) == false) and(col => col.LIB_LIBRETA.Contains(da.LIB_LIBRETA));
            if (String.IsNullOrEmpty(da.MONEDA) == false) and(col => col.MONEDA.Contains(da.MONEDA));
            if (da.FUENTE > 0) and(col => col.FUENTE == da.FUENTE);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));

        }
    }
}
