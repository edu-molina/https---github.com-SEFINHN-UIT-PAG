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
/// Clase UNIDADES_EJECUTORAS_FILTER
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>

namespace PAG_WCF
{
    public class UNIDADES_EJECUTORAS_FILTER : ExpressionBuilder<UNIDADES_EJECUTORAS>
    {
        public override void build(UNIDADES_EJECUTORAS da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (da.GESTION > 0) and(col => col.GESTION == da.GESTION);
            if (da.INSTITUCION > 0) and(col => col.INSTITUCION == da.INSTITUCION);
            if (da.UE > 0) and(col => col.UE == da.UE);
            if (String.IsNullOrEmpty(da.DESC_UE) == false) and(col => col.DESC_UE == da.DESC_UE);
            if (String.IsNullOrEmpty(da.VIGENTE) == false) and(col => col.VIGENTE == da.VIGENTE);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}