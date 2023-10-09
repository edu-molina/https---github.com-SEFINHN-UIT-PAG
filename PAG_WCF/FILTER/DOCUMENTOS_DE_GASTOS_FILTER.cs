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
/// Clase DOCUMENTOS_DE_GASTOS_FILTER
/// </summary>
/// <history>
/// FECHA               REPONSABLE              DESCRIPCION
/// 04/Abril/2017       Elia Enamorado          Creacion de Clase
/// </history>
namespace PAG_WCF
{
    public class DOCUMENTOS_DE_GASTOS_FILTER : ExpressionBuilder<DOCUMENTOS_DE_GASTOS>
    {
        public override void build(DOCUMENTOS_DE_GASTOS da)
        {
            // TODO: Desarrolle su Codigo Aqui.
            if (da.GESTION > 0) and(col => col.GESTION == da.GESTION);
            if (da.INSTITUCION > 0) and(col => col.INSTITUCION == da.INSTITUCION);
            if (da.GA > 0) and(col => col.GA == da.GA);
            if (da.NRO_PRECOMPROMISO > 0) and(col => col.NRO_PRECOMPROMISO == da.NRO_PRECOMPROMISO);
            if (da.NRO_COMPROMISO > 0) and(col => col.NRO_COMPROMISO == da.NRO_COMPROMISO);
            if (da.NRO_DEVENGADO > 0) and(col => col.NRO_DEVENGADO == da.NRO_DEVENGADO);
            if (da.NRO_SECUENCIA > 0) and(col => col.NRO_SECUENCIA == da.NRO_SECUENCIA);
            if (da.NRO_DEVENGADO_SIP > 0) and(col => col.NRO_DEVENGADO_SIP == da.NRO_DEVENGADO_SIP);
            if (da.UE > 0) and(col => col.UE == da.UE);
            if (String.IsNullOrEmpty(da.TIPO_FORMULARIO) == false) and(col => col.TIPO_FORMULARIO == da.TIPO_FORMULARIO);
            if (String.IsNullOrEmpty(da.TIPO_DOCUMENTO) == false) and(col => col.TIPO_DOCUMENTO == da.TIPO_DOCUMENTO);
            if (da.EJERCICIO > 0) and(col => col.EJERCICIO == da.EJERCICIO);
            if (da.LUGAR_DEP > 0) and(col => col.LUGAR_DEP == da.LUGAR_DEP);
            if (da.LUGAR_MUN > 0) and(col => col.LUGAR_MUN == da.LUGAR_MUN);
            if (String.IsNullOrEmpty(da.APLICACION) == false) and(col => col.APLICACION == da.APLICACION);
            if (da.FUENTE > 0) and(col => col.FUENTE == da.FUENTE);
            if (da.ORGANISMO > 0) and(col => col.ORGANISMO == da.ORGANISMO);
            if (String.IsNullOrEmpty(da.BIP) == false) and(col => col.BIP == da.BIP);
            if (String.IsNullOrEmpty(da.CONVENIO) == false) and(col => col.CONVENIO == da.CONVENIO);
            if (String.IsNullOrEmpty(da.SIGADE) == false) and(col => col.SIGADE == da.SIGADE);
            if (da.TRAMO > 0) and(col => col.TRAMO == da.TRAMO);
            if (String.IsNullOrEmpty(da.API_ESTADO) == false) and(col => col.API_ESTADO.Contains(da.API_ESTADO));
   
        }
    }
}