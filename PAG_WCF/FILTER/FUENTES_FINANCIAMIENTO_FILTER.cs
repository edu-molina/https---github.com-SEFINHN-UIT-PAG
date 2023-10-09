using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAG_DA;
using PAG_DTO;

namespace PAG_WCF
{
    public class FUENTES_FINANCIAMIENTO_FILTER : ExpressionBuilder<FUENTES_FINANCIAMIENTO>
    {
        public override void build(FUENTES_FINANCIAMIENTO da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (da.FUENTE > 0) and(col => col.FUENTE == da.FUENTE);
            if (da.GRUPO_FUENTE > 0) and(col => col.GRUPO_FUENTE == da.GRUPO_FUENTE);
            if (da.SUB_GRUPO_FUENTE > 0) and(col => col.SUB_GRUPO_FUENTE == da.SUB_GRUPO_FUENTE);
            if (String.IsNullOrEmpty(da.DESC_FUENTE) == false) and(col => col.DESC_FUENTE == da.DESC_FUENTE);
            if (String.IsNullOrEmpty(da.VIGENTE) == false) and(col => col.VIGENTE == da.VIGENTE);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}