using PAG_DA;
using PAG_DTO;
using PAG_INTERFACES;
using PAG_MAPPERS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.ServiceModel;

/// <summary>
/// Clase EGA_BENEFICIARIOS_FILTER
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>

namespace PAG_WCF
{
    public class EGA_BENEFICIARIOS_FILTER : ExpressionBuilder<EGA_BENEFICIARIOS>
    {
        public override void build(EGA_BENEFICIARIOS da)
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
            if (String.IsNullOrEmpty(da.PAIS_ID) == false) and(col => col.PAIS_ID == da.PAIS_ID);
            if (String.IsNullOrEmpty(da.TIPO_ID) == false) and(col => col.TIPO_ID == da.TIPO_ID);
            if (String.IsNullOrEmpty(da.NRO_ID) == false) and(col => col.NRO_ID == da.NRO_ID);
            if (da.EJERCICIO > 0) and(col => col.EJERCICIO == da.EJERCICIO);
            if (String.IsNullOrEmpty(da.TIPOS_MOMENTOS) == false) and(col => col.TIPOS_MOMENTOS == da.TIPOS_MOMENTOS);
            if (da.BANCO > 0) and(col => col.BANCO == da.BANCO);
            if (String.IsNullOrEmpty(da.CUENTA) == false) and(col => col.CUENTA == da.CUENTA);
            if (da.MONTO > 0) and(col => col.MONTO == da.MONTO);
            if (da.MONTO_DC > 0) and(col => col.MONTO_DC == da.MONTO_DC);
            if (da.MONTO_ME > 0) and(col => col.MONTO_ME == da.MONTO_ME);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
        }
    }
}