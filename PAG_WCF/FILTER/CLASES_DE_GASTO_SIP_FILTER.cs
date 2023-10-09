using System;
using PAG_DA;
using PAG_DTO;

namespace PAG_WCF
{
    public class CLASES_DE_GASTO_SIP_FILTER : ExpressionBuilder<CLASES_DE_GASTO_SIP>
    {
        public override void build(CLASES_DE_GASTO_SIP da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (da.GESTION > 0) and(col => col.GESTION == da.GESTION);
            if (da.CLASE_DE_GASTO > 0) and(col => col.CLASE_DE_GASTO == da.CLASE_DE_GASTO);
            if (String.IsNullOrEmpty(da.DESC_CLASE_DE_GASTO) == false) and(col => col.DESC_CLASE_DE_GASTO == da.DESC_CLASE_DE_GASTO);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}