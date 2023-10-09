using System;

using PAG_DA;
using PAG_DTO;
namespace PAG_WCF
{
    public class MONEDAS_FILTER : ExpressionBuilder<MONEDAS>
    {
        public override void build(MONEDAS da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (String.IsNullOrEmpty(da.MONEDA) == false) and(col => col.MONEDA == da.MONEDA);
            if (String.IsNullOrEmpty(da.DESC_MONEDA) == false) and(col => col.DESC_MONEDA.Contains(da.DESC_MONEDA));
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO == da.API_ESTADO);
        }
    }
}
