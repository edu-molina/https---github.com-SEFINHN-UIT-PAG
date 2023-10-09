using System;
using PAG_DA;
using PAG_DTO;


namespace PAG_WCF
{
    public class BENEFICIARIOS_FILTER : ExpressionBuilder<BENEFICIARIOS>
    {
        public override void build(BENEFICIARIOS da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (String.IsNullOrEmpty(da.PAIS_ID) == false) and(col => col.PAIS_ID == da.PAIS_ID);
            if (String.IsNullOrEmpty(da.TIPO_ID) == false) and(col => col.TIPO_ID == da.TIPO_ID);
            if (String.IsNullOrEmpty(da.NRO_ID) == false) and(col => col.NRO_ID == da.NRO_ID);
            if (String.IsNullOrEmpty(da.DESC_OTRO_TIPO_ID) == false) and(col => col.DESC_OTRO_TIPO_ID == da.DESC_OTRO_TIPO_ID);
            if (String.IsNullOrEmpty(da.NOMBRE_BENEFICIARIO) == false) and(col => col.NOMBRE_BENEFICIARIO == da.NOMBRE_BENEFICIARIO);
            if (String.IsNullOrEmpty(da.TIPO_BENEFICIARIO) == false) and(col => col.TIPO_BENEFICIARIO == da.TIPO_BENEFICIARIO);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}
