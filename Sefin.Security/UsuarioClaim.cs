using System.Collections.Generic;

namespace Sefin.Security
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
}