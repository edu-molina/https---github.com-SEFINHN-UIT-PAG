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

/// <summary>
/// Clase CG_REF_CODES_FILTER
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>
/// 
namespace PAG_WCF
{
    public class CG_REF_CODES_FILTER : ExpressionBuilder<CG_REF_CODES>
    {
        public override void build(CG_REF_CODES da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (String.IsNullOrEmpty(da.RV_DOMAIN) == false) and(col => col.RV_DOMAIN == da.RV_DOMAIN);
            if (String.IsNullOrEmpty(da.RV_LOW_VALUE) == false) and(col => col.RV_LOW_VALUE == da.RV_LOW_VALUE);
            // if (String.IsNullOrEmpty(da.RV_HIGH_VALUE) == false) and(col => col.RV_HIGH_VALUE == da.RV_HIGH_VALUE);
            //  if (String.IsNullOrEmpty(da.RV_ABBREVIATION) == false) and(col => col.RV_ABBREVIATION == da.RV_ABBREVIATION);
            if (String.IsNullOrEmpty(da.RV_MEANING) == false) and(col => col.RV_MEANING.Contains(da.RV_MEANING));

        }
    }
}
