using System;
using PAG_DA;
using PAG_DTO;

namespace PAG_WCF
{
    public class GERENCIAS_ADMINISTRATIVAS_FILTER : ExpressionBuilder<GERENCIAS_ADMINISTRATIVAS>
    {
        public override void build(GERENCIAS_ADMINISTRATIVAS da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (da.GESTION > 0) and(col => col.GESTION == da.GESTION);
            if (da.INSTITUCION > 0) and(col => col.INSTITUCION == da.INSTITUCION);
            if (da.GA > 0) and(col => col.GA == da.GA);
            if (String.IsNullOrEmpty(da.DESC_GA) == false) and(col => col.DESC_GA == da.DESC_GA);
            if (String.IsNullOrEmpty(da.TIPO_GA) == false) and(col => col.TIPO_GA == da.TIPO_GA);
            if (String.IsNullOrEmpty(da.VIGENTE) == false) and(col => col.VIGENTE == da.VIGENTE);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}