using System;

using PAG_DA;
using PAG_DTO;

namespace PAG_WCF
{
    public class DEDUCCIONES_FILTER : ExpressionBuilder<DEDUCCIONES>
    {

        public override void build(DEDUCCIONES da)
        {
            if (da.DEDUCCION > 0) and(col => col.DEDUCCION == da.DEDUCCION);
            if (da.TIPO > 0) and(col => col.TIPO == da.TIPO);
            if (da.SUB_TIPO > 0) and(col => col.SUB_TIPO == da.SUB_TIPO);
            if (String.IsNullOrEmpty(da.DESCRIPCION) == false) and(col => col.DESCRIPCION == da.DESCRIPCION);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}
