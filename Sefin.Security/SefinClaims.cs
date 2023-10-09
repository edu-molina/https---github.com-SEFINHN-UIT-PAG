using System.Collections.Generic;

namespace Sefin.Security
{
    public class SefinClaims
    {
    

        public UsuarioClaim setClaims(IEnumerable<System.Security.Claims.Claim> claimsSTS)
        {
         
            var respuesta = new UsuarioClaim();

            //respuesta.RTN = formarClaim(claimsSTS, "rtn");
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
            return respuesta;

        }
        private List<string> formarClaimList(IEnumerable<System.Security.Claims.Claim> item, string Tipo)
        {
            List<string> resp = new List<string>();

            int largoTipo = Tipo.Length;
            foreach (var x in item)
            {

                int largoType = x.Type.Length;
                string nombreTipo = x.Type; //.Substring(largoType - largoTipo - 1, largoTipo + 1);
                if (nombreTipo == Tipo)
                {
                    foreach (var system in x.Value.Split(','))
                    {
                        resp.Add(system);
                    }
                }
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
                string nombreTipo = x.Type; //.Substring(largoType - largoTipo - 1, largoTipo + 1);
                if (nombreTipo == Tipo)
                    resp = x.Value;
            }

            return resp;



        }

       
    }
}