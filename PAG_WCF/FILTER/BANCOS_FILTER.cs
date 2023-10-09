using System;

using PAG_DA;
using PAG_DTO;
namespace PAG_WCF
{
    public class BANCOS_FILTER : ExpressionBuilder<BANCOS>
    {
        public override void build(BANCOS da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (da.BANCO > 0) and(col => col.BANCO == da.BANCO);
            if (String.IsNullOrEmpty(da.DESC_BANCO) == false) and(col => col.DESC_BANCO.Contains(da.DESC_BANCO));
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO == da.API_ESTADO);
        }
    }
}
