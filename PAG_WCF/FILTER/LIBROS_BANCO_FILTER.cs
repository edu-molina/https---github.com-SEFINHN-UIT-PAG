using System;

using PAG_DA;
using PAG_DTO;
namespace PAG_WCF
{
    public class LIBROS_BANCO_FILTER : ExpressionBuilder<LIBROS_BANCO>
    {
        public override void build(LIBROS_BANCO da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (da.GESTION > 0) and(col => col.GESTION == da.GESTION);
            if (da.BANCO > 0) and(col => col.BANCO == da.BANCO);
            if (String.IsNullOrEmpty(da.CUENTA) == false) and(col => col.CUENTA == da.CUENTA);
            if (String.IsNullOrEmpty(da.MONEDA) == false) and(col => col.MONEDA == da.MONEDA);
            if (String.IsNullOrEmpty(da.UTILIZA_LIBRETAS) == false) and(col => col.UTILIZA_LIBRETAS == da.UTILIZA_LIBRETAS);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO == da.API_ESTADO);
        }
    }
}
