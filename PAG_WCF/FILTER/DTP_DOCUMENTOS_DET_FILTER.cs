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
    
    
    public class DTP_DOCUMENTOS_DET_FILTER : ExpressionBuilder<DTP_DOCUMENTOS_DET>
    {
        
        public override void build(DTP_DOCUMENTOS_DET da)
        {
            and(col => col.GESTION == da.GESTION);
            and(col => col.INSTITUCION == da.INSTITUCION);
            and(col => col.GA == da.GA);
            and(col => col.NRO_DOCUMENTO == da.NRO_DOCUMENTO);
            and(col => col.INSTITUCION_PROG == da.INSTITUCION_PROG);
            and(col => col.GA_PROG == da.GA_PROG);
            and(col => col.TIPO_PROGRAMACION == da.TIPO_PROGRAMACION);
            if (da.SECUENCIA_DOC > 0) and(col => col.SECUENCIA_DOC == da.SECUENCIA_DOC);
            if (String.IsNullOrEmpty(da.ID_DOCUMENTO) == false) and(col => col.ID_DOCUMENTO.Contains(da.ID_DOCUMENTO));
            if (String.IsNullOrEmpty(da.OBSERVACION) == false) and(col => col.OBSERVACION.Contains(da.OBSERVACION));
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}