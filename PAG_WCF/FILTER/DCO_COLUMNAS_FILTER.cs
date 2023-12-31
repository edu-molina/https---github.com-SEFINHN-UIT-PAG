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
    
    
    public class DCO_COLUMNAS_FILTER : ExpressionBuilder<DCO_COLUMNAS>
    {
        
        public override void build(DCO_COLUMNAS da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (da.ID_COLUMNA > 0) and(col => col.ID_COLUMNA == da.ID_COLUMNA);
            if (String.IsNullOrEmpty(da.DESC_COLUMNA) == false) and(col => col.DESC_COLUMNA == da.DESC_COLUMNA);
            if (String.IsNullOrEmpty(da.TABLA) == false) and(col => col.TABLA == da.TABLA);
            if (String.IsNullOrEmpty(da.TIPO_COLUMNA) == false) and(col => col.TIPO_COLUMNA == da.TIPO_COLUMNA);
            if (String.IsNullOrEmpty(da.COLUMNA) == false) and(col => col.COLUMNA == da.COLUMNA);
            if (String.IsNullOrEmpty(da.TABLA_ORIGEN) == false) and(col => col.TABLA_ORIGEN == da.TABLA_ORIGEN);
            if (String.IsNullOrEmpty(da.COLUMNA_ORIGEN) == false) and(col => col.COLUMNA_ORIGEN == da.COLUMNA_ORIGEN);
            if (String.IsNullOrEmpty(da.OTROS_VALORES) == false) and(col => col.OTROS_VALORES.Contains(da.OTROS_VALORES));
            if (String.IsNullOrEmpty(da.TIENE_LISTA) == false) and(col => col.TIENE_LISTA == da.TIENE_LISTA);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO == da.API_ESTADO);
        }
    }
}
