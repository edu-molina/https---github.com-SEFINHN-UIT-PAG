using System;

using PAG_DA;
using PAG_DTO;
namespace PAG_WCF
{
    public class LIBRETAS_FILTER : ExpressionBuilder<LIBRETAS>
    {
        public override void build(LIBRETAS da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (da.GESTION > 0) and(col => col.GESTION == da.GESTION);
            if (da.BANCO > 0) and(col => col.BANCO == da.BANCO);
            if (String.IsNullOrEmpty(da.CUENTA) == false) and(col => col.CUENTA == da.CUENTA);
            if (String.IsNullOrEmpty(da.LIBRETA) == false) and(col => col.LIBRETA == da.LIBRETA);
            if (String.IsNullOrEmpty(da.DESC_LIBRETA) == false) and(col => col.DESC_LIBRETA.Contains(da.DESC_LIBRETA));
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO == da.API_ESTADO);
        }
    }
}
