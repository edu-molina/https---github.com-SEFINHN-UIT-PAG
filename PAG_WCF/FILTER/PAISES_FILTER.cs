using System;

using PAG_DA;
using PAG_DTO;

namespace PAG_WCF
{
    public class PAISES_FILTER : ExpressionBuilder<PAISES>
    {
        public override void build(PAISES da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (String.IsNullOrEmpty(da.PAIS) == false) and(col => col.PAIS == da.PAIS);
            if (String.IsNullOrEmpty(da.DESC_PAIS) == false) and(col => col.DESC_PAIS == da.DESC_PAIS);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}