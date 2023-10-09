using System;
using PAG_DA;
using PAG_DTO;


namespace PAG_WCF
{
    public class BEN_TIPOS_IDENTIFICACION_FILTER : ExpressionBuilder<BEN_TIPOS_IDENTIFICACION>
    {
        public override void build(BEN_TIPOS_IDENTIFICACION da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (String.IsNullOrEmpty(da.TIPO_DOCUMENTO) == false) and(col => col.TIPO_DOCUMENTO == da.TIPO_DOCUMENTO);
            if (String.IsNullOrEmpty(da.DESC_TIPO_DOCUMENTO) == false) and(col => col.DESC_TIPO_DOCUMENTO == da.DESC_TIPO_DOCUMENTO);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}
