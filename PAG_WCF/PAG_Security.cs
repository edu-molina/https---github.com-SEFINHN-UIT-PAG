using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Reflection;
using System.Configuration;

using PAG_INTERFACES;
using SAS_INTERFACES;
using PAG_DA;
using SEFIN.FWK.ERRORHANDLER.Exceptions;

namespace PAG_WCF
{
    public static class PAG_Security
    {
        public static ISAS_Services SASwRef = ChannelFactory<ISAS_Services>.CreateChannel(new BasicHttpBinding("BasicHttpBinding_ISAS_Services"),
                                                new EndpointAddress(System.Configuration.ConfigurationManager.AppSettings["wcfSeguridad"].ToString().Trim()));

        public static Dictionary<string, string> DictionaryClaims = new Dictionary<string, string>();
        public static dynamic ToDictionary<T>(this T value)
        {

            FieldInfo[] allFields = typeof(T).GetFields();

            var allProperties = typeof(T).GetProperties().Where(x => x.CanRead && x.CanWrite);
            Dictionary<string, string> expando = new Dictionary<string, string>();

            foreach (var pi in allFields.Where(x => x.FieldType.Namespace != typeof(ICollection<>).Namespace))
            {
                var valor = pi.GetValue(value);
                if (valor != null) { expando.Add(pi.Name, valor.ToString()); }

            }

            return expando;
        }
        public static class Llenado
        {

            public static void LlenadoSeg(string namespaces, string pMetodo)
            {
                DictionaryClaims.Add("APP_SETVPD", "S");
                if (validaciones.MetodosSinSAS(pMetodo.ToUpper()))
                    DictionaryClaims["APP_SETVPD"] = "N";
                //
                if (DictionaryClaims["APP_SETVPD"] == "S")
                {
                    string mensaje = "";
                    var vUsuario = DictionaryClaims.ContainsKey(KeysHeadersClaims.Usuario.ToString()) ? DictionaryClaims[KeysHeadersClaims.Usuario.ToString()] : System.Configuration.ConfigurationManager.AppSettings["SisAbrv"].ToUpper();
                    int vSistema = DictionaryClaims.ContainsKey(KeysHeadersClaims.Sistema.ToString()) ? Convert.ToInt16(DictionaryClaims[KeysHeadersClaims.Sistema.ToString()]) : 0;
                    var vToken = DictionaryClaims.ContainsKey(KeysHeadersClaims.TOKEN.ToString()) ? DictionaryClaims[KeysHeadersClaims.TOKEN.ToString()] : "0";
                    //int vFlujo = DictionaryClaims.ContainsKey(KeysHeadersClaims.APP_IDFLUJO.ToString()) ? Convert.ToInt16(DictionaryClaims[KeysHeadersClaims.APP_IDFLUJO.ToString()]) : 0;
                    //int vOperacion = DictionaryClaims.ContainsKey(KeysHeadersClaims.APP_IDOPERACION.ToString()) ? Convert.ToInt16(DictionaryClaims[KeysHeadersClaims.APP_IDOPERACION.ToString()]) : 0;
                    var isValid = SASwRef.autenticarWCFMetodo(pSistema: vSistema, pUsuario: vUsuario, pToken: vToken, pMetodo: namespaces + pMetodo.ToUpper(), pFlujo: 0, pOperacion: 0, pMsgErr: ref (mensaje));
                    if (!isValid && !validaciones.MetodosSinSAS(pMetodo))
                    {
                        throw new ApiException(new ApiAttribute() { typeMessage = "PAG", codeMessage = 0 }, mensaje);

                    }
                }
            }

        }
        public static class validaciones
        {
            public static Boolean MetodosSinSAS(string pMetodo)
            {
                var metodos = (ConfigurationManager.AppSettings["SASMetodosSinVPD"]).ToString().Split(',');
                foreach (var item in metodos)
                {
                    if (item.ToUpper().Equals(pMetodo))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

    }
}