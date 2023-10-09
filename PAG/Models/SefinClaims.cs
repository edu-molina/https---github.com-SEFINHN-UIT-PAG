using System.Collections.Generic;

namespace PAG.Models
{
    public partial class SefinClaims
    {
        public class UsuarioClaim
        {
            public string USUARIO { get; set; }
            public string NICKNAME { get; set; }
            public string NOMBRES { get; set; }
            public string APELLIDOS { get; set; }
            public string DIRECCION { get; set; }
            public string TELEFONO { get; set; }
            public string CELULAR { get; set; }
            public string TIPO_DOCUMENTO { get; set; }
            public string PAIS { get; set; }
            public string IDENTIDAD { get; set; }
            public string ESTADO { get; set; }
            public string PUESTO { get; set; }
            public string EMAIL { get; set; }
            public string RTN { get; set; }
            public string NIVEL_USUARIO { get; set; }
            public string PASSWORD { get; set; }
            public string PASSWORD_SALT { get; set; }
            public string FECHA_ACTIVO { get; set; }
            public string FECHA_INACTIVO { get; set; }
            public string ES_TEMPORAL { get; set; }
            public string NUMERO_ACTA { get; set; }
            public string ULT_FEC_CAMBIO_CLAVE { get; set; }
            public string FEC_ULT_LOGIN { get; set; }
            public string ESTADO_LOGIN { get; set; }
            public string VIGENTE { get; set; }
            public string SESION_MULTIPLE { get; set; }
            public string CAMBIA_CLAVE { get; set; }
            public string USUARIO_CREACION { get; set; }
            public string FECHA_CREACION { get; set; }
            public string USUARIO_MODIFICA { get; set; }
            public string FECHA_MODIFICA { get; set; }
            public List<string> SISTEMAS { get; set; }
            public List<string> ROLES { get; set; }
        }

        public UsuarioClaim setClaims(IEnumerable<System.Security.Claims.Claim> claimsSTS)
        {
            string bSefin = "http://sefin.com.hn/ws/2015/01/identity/claims/";
            string bEstandard = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/";

            UsuarioClaim respuesta = new UsuarioClaim();

            respuesta.RTN = formarClaim(claimsSTS, "rtn");
            respuesta.USUARIO = formarClaim(claimsSTS, "nameidentifier");
            respuesta.NICKNAME = formarClaim(claimsSTS, "nickname");
            respuesta.NOMBRES = formarClaim(claimsSTS, "givenname");

            respuesta.APELLIDOS = formarClaim(claimsSTS, "surname");
            //respuesta.DIRECCION = formarClaim(claimsSTS, bEstandard + "surname");
            respuesta.TELEFONO = formarClaim(claimsSTS, "homephone");
            //respuesta.CELULAR= formarClaim(claimsSTS, bEstandard + "homephone");
            respuesta.TIPO_DOCUMENTO = formarClaim(claimsSTS, "tipoDocumento");
            respuesta.PAIS = formarClaim(claimsSTS, "country");
            respuesta.EMAIL = formarClaim(claimsSTS, "emailaddress");
            respuesta.SISTEMAS = formarClaimList(claimsSTS, "system");
            respuesta.PUESTO = formarClaim(claimsSTS, "puesto");

            return respuesta;
        }

        private List<string> formarClaimList(IEnumerable<System.Security.Claims.Claim> item, string Tipo)
        {
            List<string> resp = new List<string>();

            int largoTipo = Tipo.Length;
            foreach (var x in item)
            {
                int largoType = x.Type.Length;
                string nombreTipo = x.Type.Substring(largoType - largoTipo - 1, largoTipo + 1);
                if (nombreTipo == "/" + Tipo)
                    resp.Add(x.Value);
            }

            return resp;
        }

        private string formarClaim(IEnumerable<System.Security.Claims.Claim> item, string Tipo)
        {
            string resp = "";

            int largoTipo = Tipo.Length;
            foreach (var x in item)
            {
                int largoType = x.Type.Length;
                string nombreTipo = x.Type.Substring(largoType - largoTipo - 1, largoTipo + 1);
                if (nombreTipo == "/" + Tipo)
                    resp = x.Value;
            }

            return resp;
        }

        public class EstructuraAdministrativa
        {
            public int codigoGA;
            public int codigoInstitucion;
            public int codigoUE;
            public string descripcionGA;
            public string descripcionInstitucion;
            public string descripcionUE;
            public string GA;
            public decimal GESTION;
            public string INSTITUCION;
            public string UE;
        }

        public class EstructuraFlujosOperaciones
        {
            public int ID_FLUJO;
            public int ID_OPERACION;
            public string DESC_FLUJO;
            public string DESC_OPERACION;
            public char OPERACION; //Operacion por Defecto
        }

    }

}