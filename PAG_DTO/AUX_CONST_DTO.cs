using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAG_DTO
{
    /// <summary>
    /// Clase DTO de las Constantes SIRFIDE
    /// </summary>
    /// <history>
    /// FECHA               REPONSABLE              DESCRIPCION
    /// 01/Nov/2015         Danny Lainez            Creacion de Clase
    /// </history>
    public static class AUX_CONST_DTO
    {
        //Formato de Numericos
        public const string FormatoSecuencias1 = "{0:#}";
        public const string FormatoSecuencias2 = "{0:0#}";
        public const string FormatoSecuencias3 = "{0:00#}";
        public const string FormatoSecuencias4 = "{0:000#}";
        public const string FormatoSecuencias5 = "{0:0000#}";
        public const string FormatoSecuencias6 = "{0:00000#}";
        public const string FormatoMontos = "{0:#,###,###,##0.00}";
        public const string FormatoMontos16 = "{0:##,###,###,###,##0.00}";
        public const string FormatoTasa = "{0:00.00%}";
        //Formato de Fecha y Hora
        public const string FormatoHora = "{0:T}";                           //{0:T} => 17:10:48
        public const string FormatoFechaLarga = "{0:D}";                     //{0:D} => jueves, 17 de marzo de 2016
        public const string FormatoFechaLargayHora = "{0:F}";                //{0:F} => jueves, 17 de marzo de 2016 17:10:48
        public const string FormatoFechaCorta = "{0:dd/MM/yyyy}";            //{0:dd/MM/yyyy} => 17/03/2016
        public const string FormatoFechaCortayHora = "{0:dd/MM/yyyy} {0:T}"; //{0:dd/MM/yyyy} {0:T} => 17/03/2016 17:10:48

        public enum keysClaims
        {
            NAME,
            NICKNAME,
            NAMEIDENTIFIER,
            EMAILADDRESS,
            GIVENNAME,
            SURNAME,
            COUNTRY,
            RTN,
            HOMEPHONE,
            TIPODOCUMENTO,
            PUESTO,
            SYSTEM,
            AUTHENTICATIONMETHOD,
            AUTHENTICATIONINSTANT,
            APP_TOKEN,
            APP_IDSESSION,
            APP_IDSYSTEM,
            APP_IDFLUJO,
            APP_IDOPERACION,
            APP_IDPERFIL
        }

        public const string PAG_HEADER_NAMESPACE = "http://pagos.sefin.gob.hn";
    }
    
}
