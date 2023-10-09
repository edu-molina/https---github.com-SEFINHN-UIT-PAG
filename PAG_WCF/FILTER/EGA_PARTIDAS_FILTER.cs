using System;

using PAG_DA;
using PAG_DTO;

namespace PAG_WCF
{
    public class EGA_PARTIDAS_FILTER : ExpressionBuilder<EGA_PARTIDAS>
    {
        public override void build(EGA_PARTIDAS da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (da.GESTION > 0) and(col => col.GESTION == da.GESTION);
            if (da.INSTITUCION > 0) and(col => col.INSTITUCION == da.INSTITUCION);
            if (da.GA > 0) and(col => col.GA == da.GA);
            if (da.NRO_PRECOMPROMISO > 0) and(col => col.NRO_PRECOMPROMISO == da.NRO_PRECOMPROMISO);
            if (da.NRO_COMPROMISO > 0) and(col => col.NRO_COMPROMISO == da.NRO_COMPROMISO);
            if (da.NRO_DEVENGADO > 0) and(col => col.NRO_DEVENGADO == da.NRO_DEVENGADO);
            if (da.NRO_SECUENCIA > 0) and(col => col.NRO_SECUENCIA == da.NRO_SECUENCIA);
            if (da.SEC_PAGO > 0) and(col => col.SEC_PAGO == da.SEC_PAGO);
            if (da.UE > 0) and(col => col.UE == da.UE);
            if (da.PROGRAMA > 0) and(col => col.PROGRAMA == da.PROGRAMA);
            if (da.SUB_PROGRAMA > 0) and(col => col.SUB_PROGRAMA == da.SUB_PROGRAMA);
            if (da.PROYECTO > 0) and(col => col.PROYECTO == da.PROYECTO);
            if (da.ACTIVIDAD_OBRA > 0) and(col => col.ACTIVIDAD_OBRA == da.ACTIVIDAD_OBRA);
            if (da.FUENTE > 0) and(col => col.FUENTE == da.FUENTE);
            if (da.ORGANISMO > 0) and(col => col.ORGANISMO == da.ORGANISMO);
            if (String.IsNullOrEmpty(da.OBJETO) == false) and(col => col.OBJETO == da.OBJETO);
            if (da.TRF_BENEFICIARIO > 0) and(col => col.TRF_BENEFICIARIO == da.TRF_BENEFICIARIO);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}
