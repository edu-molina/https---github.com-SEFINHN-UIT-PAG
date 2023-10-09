using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Agregado por DSA

using PAG_DA;
using SAS_DTO;
using SAS_INTERFACES;
using System.Text.RegularExpressions;
using System.ServiceModel;
using System.Reflection;
using System.IO;
using System.Linq.Expressions;

namespace PAG_WCF
{
    class PAG_Message
    {
        private static MENSAJES_DE_ERROR _vpMENSAJES_DE_ERROR = new MENSAJES_DE_ERROR();

        private static List<MENSAJES_DE_ERROR> _ltMENSAJES_DE_ERROR = new List<MENSAJES_DE_ERROR>();

        static PAG_Message()
        {
            try
            {
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<MENSAJES_DE_ERROR> query;
                    query = from rec in context.MENSAJES_DE_ERROR
                            select rec;
                    foreach (var item in query)
                    {
                        _ltMENSAJES_DE_ERROR.Add(item);
                    }
                }
                _vpMENSAJES_DE_ERROR = (new MENSAJES_DE_ERROR
                {
                    TIPO_MENSAJE_ERROR = "PAG",
                    CODIGO_MENSAJE_ERROR = 0,
                    ORIGEN = "PAG  WCF",
                    TEXTO = "Fallo al Construir Clasificador Mensajes de Error.",
                    CAUSA = "Problemas Tecnicos NO Controlados.",
                    ACCION = "Notifique a Tecnicos de PAG."
                });
            }
            catch (Exception Ex)
            {
                _vpMENSAJES_DE_ERROR = (new MENSAJES_DE_ERROR
                {
                    TIPO_MENSAJE_ERROR = "PAG",
                    CODIGO_MENSAJE_ERROR = 0,
                    ORIGEN = "PAG WCF",
                    TEXTO = "Fallo al Construir Clasificador Mensajes de Error.",
                    CAUSA = "Problemas Tecnicos NO Controlados.",
                    ACCION = "Notifique a Tecnicos de PAG.",
                    COMENTARIO = Ex.InnerException.InnerException.Message
                });
            }
        }
        public static List<MENSAJES_DE_ERROR> ltMENSAJES_DE_ERROR { private set { } get { return _ltMENSAJES_DE_ERROR; } }
        public static MENSAJES_DE_ERROR vpMENSAJES_DE_ERROR { private set { } get { return _vpMENSAJES_DE_ERROR; } }
    }

    public static class PAG_ServicesUtil
    {
        //Error ORA
        private static readonly string _ErrorORA = "ORA-20000: ";
        public static string ErrorORA { get { return _ErrorORA; } }

        //Errores WCF
        public static MENSAJES_DE_ERROR ErrorWCPAGfecto { private set { } get { return PAG_Message.vpMENSAJES_DE_ERROR; } }
        public static List<MENSAJES_DE_ERROR> ListaWCFExcepciones { private set { } get { return PAG_Message.ltMENSAJES_DE_ERROR; } }

        //Formato Error PAG
        private static readonly string _ErrorPAG = "XYZ-#####";
        public static string ErrorPAG { get { return _ErrorPAG; } }

        //Codigo Error PAG Default
        private static readonly string _ErrorPAGCodDefecto = "PAG-00000";
        public static string ErrorPAGCodDefecto { get { return _ErrorPAGCodDefecto; } }

        //Descripcion Error PAG Default
        private static readonly string _ErrorPAGDescDefecto = "Error SIAFI NO Definido.";
        public static string ErrorPAGDescDefecto { get { return _ErrorPAGDescDefecto; } }

        //Es Error BDD
        public static Boolean EsErrorORA(Exception Excepcion)
        {
            if (Excepcion.InnerException != null)
            {
                try
                {
                    if (Excepcion.InnerException.InnerException.Message.Split('\n')[0].Contains(ErrorORA)) { return true; }
                }
                catch { return false; }
            }
            return false;
        }
        public static Boolean EsErrorORAFault(Exception Excepcion)
        {
            Regex RegEx = new Regex("^[A-Z]{3}-[0-9]{5}: ");
            if (RegEx.IsMatch(Excepcion.InnerException.InnerException.Message)) { return true; }
            return false;
        }

        public static string ObtCodExcepcion(Exception Excepcion)
        {
            string Raise = Excepcion.InnerException.InnerException.Message.Split('\n')[0];
            if (Excepcion != null)
            {
                if (Raise.Contains(ErrorORA))
                {
                    return Raise.Substring(ErrorORA.Length, ErrorPAG.Length);
                }
            };
            return "";
        }

        public static string ObtDescExcepcion(Exception Excepcion, Boolean soloMensaje = false)
        {
            string Raise = Excepcion.InnerException.InnerException.Message.Split('\n')[0];
            if (Excepcion != null)
            {
                if (Raise.Contains(ErrorORA))
                {
                    return (!soloMensaje) ? Raise.Substring(ErrorORA.Length) : Raise.Substring(ErrorORA.Length + ErrorPAG.Length);
                }
            };
            return "";
        }

        public static string ObtCodWFCExcepcion(string Sigla, Int32 Codigo)
        {
            if (string.IsNullOrEmpty(Sigla) == false && string.IsNullOrEmpty(Codigo.ToString()) == false)
            {
                if (PAG_ServicesUtil.ListaWCFExcepciones.Count == 0) { return Sigla.Trim() + "-" + "00000"; };
                if (PAG_ServicesUtil.ListaWCFExcepciones.Count >= 1) { return Sigla.Trim() + "-" + Codigo.ToString().PadLeft(5, '0'); };
            }
            return Sigla + "-" + Codigo;
        }

        public static string ObtDescWFCExcepcion(string Sigla, Int32 Codigo, string Parametros = null, Boolean soloMensaje = false)
        {
            if (string.IsNullOrEmpty(Sigla) == false && string.IsNullOrEmpty(Codigo.ToString()) == false)
            {
                if (PAG_ServicesUtil.ListaWCFExcepciones.Count == 0)
                {
                    MENSAJES_DE_ERROR item = PAG_ServicesUtil.ErrorWCPAGfecto;
                    return (!soloMensaje) ?
                           item.TIPO_MENSAJE_ERROR + "-" +
                           item.CODIGO_MENSAJE_ERROR.ToString().PadLeft(5, '0') + " " +
                           item.TEXTO : item.TEXTO;
                };
                if (PAG_ServicesUtil.ListaWCFExcepciones.Count >= 1)
                {
                    List<MENSAJES_DE_ERROR> items = PAG_ServicesUtil.ListaWCFExcepciones.Where(col => col.TIPO_MENSAJE_ERROR == Sigla.Trim() &&
                                                                                              col.CODIGO_MENSAJE_ERROR == Codigo).ToList();
                    if (items.Count == 0)
                    {
                        string Error = "El Codigo(" + Codigo + ") del Mensaje de Error NO Existe.";
                        return (!soloMensaje) ? Sigla.Trim() + "-00000 " + Error : Error;
                    }
                    else if (items.Count > 1)
                    {
                        string Error = "Existen Mas de Un(1) Mensaje de Error (" + Sigla.Trim() + "-" + Codigo + ").";
                        return (!soloMensaje) ? Sigla.Trim() + "-00000 " + Error : Error;
                    };
                    if (items.Count == 1)
                    {
                        MENSAJES_DE_ERROR item = items.FirstOrDefault();
                        if (string.IsNullOrEmpty(Parametros) == false)
                        {
                            if (Parametros.StartsWith("##") && Parametros.EndsWith("##"))
                            {
                                string MensajeErrorWCF = item.TEXTO.Replace("%S", "%s");
                                foreach (string param in Parametros.Split(new string[] { "##" }, StringSplitOptions.RemoveEmptyEntries).ToArray())
                                {
                                    if (MensajeErrorWCF.Contains("%s"))
                                    {
                                        MensajeErrorWCF = MensajeErrorWCF.Insert(MensajeErrorWCF.IndexOf("%s"), param);
                                        MensajeErrorWCF = MensajeErrorWCF.Remove(MensajeErrorWCF.IndexOf("%s"), 2);
                                    };
                                };
                                MensajeErrorWCF = MensajeErrorWCF.Replace("%s", "...");
                                return (!soloMensaje) ?
                                       item.TIPO_MENSAJE_ERROR + "-" +
                                       item.CODIGO_MENSAJE_ERROR.ToString().PadLeft(5, '0') + " " +
                                       MensajeErrorWCF.Trim() : MensajeErrorWCF.Trim();
                            };
                        };
                        return (!soloMensaje) ?
                               item.TIPO_MENSAJE_ERROR + "-" +
                               item.CODIGO_MENSAJE_ERROR.ToString().PadLeft(5, '0') + " " +
                               item.TEXTO.Replace("%s", "...").Replace("%S", "...") : item.TEXTO.Replace("%s", "...").Replace("%S", "...");
                    };
                };
            };
            return "(" + Sigla + "-" + Codigo + ": " + Parametros + ")";
        }

        private static string _tokenPAG = "D9F072E7928070B5E0440017084C78DE";

        public static string tokenPAG { private set { } get { return _tokenPAG; } }

        public static bool ValidarTOKEN(string TokenAPP)
        {
            if (TokenAPP == tokenPAG) { return true; }
            return false;
        }

        private static string _usuarioPAG = "AUTOGENERAR";

        public static string usuarioPAG { private set { } get { return _usuarioPAG; } }

        //Variables Autorizacion
        private static readonly string _PrefijoMetodo = "PAG.PAG.WCF.";
        public static string PrefijoMetodo { get { return _PrefijoMetodo; } }
        public static string UsuarioAutorizadoWCF { set; get; }

        public static void AutorizadoMetodoUsuario(string pMetodo)
        {
            try
            {
                PAG_Seguridad.DictionaryClaims.Clear();
                var headers = System.ServiceModel.OperationContext.Current.IncomingMessageHeaders;
                foreach (var header in headers)
                {
                    if (Enum.GetNames(typeof(PAG_DTO.AUX_CONST_DTO.keysClaims)).ToList().Exists(col => col == header.Name))
                    {
                        PAG_Seguridad.DictionaryClaims.Add(header.Name, headers.GetHeader<string>(header.Name, PAG_DTO.AUX_CONST_DTO.PAG_HEADER_NAMESPACE));
                    }
                }
                //
                PAG_Seguridad.DictionaryClaims.Add("APP_SETVPD", "S");
                if (System.Configuration.ConfigurationManager.AppSettings["SASMetodosSinVPD"].ToUpper().Split(',').ToList().Contains(pMetodo.ToUpper()))
                    PAG_Seguridad.DictionaryClaims["APP_SETVPD"] = "N";
                //
                if (PAG_Seguridad.DictionaryClaims["APP_SETVPD"] == "S")
                {
                    string vMsgErr = "";
                    var vUsuario = PAG_Seguridad.DictionaryClaims.ContainsKey(keysClaims.NAME.ToString()) ? PAG_Seguridad.DictionaryClaims[keysClaims.NAME.ToString()] : "PAG";
                    int vSistema = PAG_Seguridad.DictionaryClaims.ContainsKey(keysClaims.APP_IDSYSTEM.ToString()) ? Convert.ToInt16(PAG_Seguridad.DictionaryClaims[keysClaims.APP_IDSYSTEM.ToString()]) : 0;
                    var vToken = PAG_Seguridad.DictionaryClaims.ContainsKey(keysClaims.APP_IDSESSION.ToString()) ? PAG_Seguridad.DictionaryClaims[keysClaims.APP_IDSESSION.ToString()] : "0";
                    int vFlujo = PAG_Seguridad.DictionaryClaims.ContainsKey(keysClaims.APP_IDFLUJO.ToString()) ? Convert.ToInt16(PAG_Seguridad.DictionaryClaims[keysClaims.APP_IDFLUJO.ToString()]) : 0;
                    int vOperacion = PAG_Seguridad.DictionaryClaims.ContainsKey(keysClaims.APP_IDOPERACION.ToString()) ? Convert.ToInt16(PAG_Seguridad.DictionaryClaims[keysClaims.APP_IDOPERACION.ToString()]) : 0;

                    if (!PAG_ServicesUtil.AutorizadoMetodoUsuario(pSistema: vSistema, pUsuario: vUsuario, pToken: vToken, pMetodo: pMetodo, pFlujo: vFlujo, pOperacion: vOperacion, pMensajeError: vMsgErr))
                        throw new FaultException(vMsgErr, new FaultCode("PAG-20000"));
                }
            }
            catch (Exception Ex)
            {
                throw new FaultException("Usuario NO Autorizado para WCF-PAG.",
                      new FaultCode("PAG-20000"), Ex.InnerException.InnerException.Message);
            }
            return;
        }
        public static bool AutorizadoMetodoUsuario(int pSistema, string pUsuario, string pToken, string pMetodo, int pFlujo, int pOperacion, string pMensajeError = null)
        {
            if (pUsuario == null)
            { pUsuario = UsuarioAutorizadoWCF; };
            if (System.Configuration.ConfigurationManager.
                AppSettings["ActivarValidacionAutorizacionMetodoWCF"].ToString().Trim() == "false") { return true; }
            else
            {
                if (pMetodo.StartsWith("QRY"))
                {
                    if (System.Configuration.ConfigurationManager.
                      AppSettings["ActivarValidacionAutorizacionMetodoQRYWCF"].ToString().Trim() == "false") { return true; };
                };
                if (pMetodo.StartsWith("INS"))
                {
                    if (System.Configuration.ConfigurationManager.
                      AppSettings["ActivarValidacionAutorizacionMetodoINSWCF"].ToString().Trim() == "false") { return true; };
                };
                if (pMetodo.StartsWith("UPD"))
                {
                    if (System.Configuration.ConfigurationManager.
                      AppSettings["ActivarValidacionAutorizacionMetodoUPDWCF"].ToString().Trim() == "false") { return true; };
                };
                if (pMetodo.StartsWith("DEL"))
                {
                    if (System.Configuration.ConfigurationManager.
                      AppSettings["ActivarValidacionAutorizacionMetodoDELWCF"].ToString().Trim() == "false") { return true; };
                };
            }
            try
            {
                var vMensaje = "";
                string vMetodo = PrefijoMetodo + pMetodo;
                return PAG_Seguridad.Autorizado(pSistema: pSistema, pUsuario: pUsuario, pToken: pToken, pMetodo: vMetodo, pFlujo: pFlujo, pOperacion: pOperacion, pMsgErr: vMensaje);
            }
            catch (Exception Ex) { pMensajeError = Ex.InnerException.InnerException.Message; return false; }
        }
    }

    public static class PAG_Seguridad
    {
        public static Dictionary<string, string> DictionaryClaims = new Dictionary<string, string>();

        private static ISAS_Services SASwRef = ChannelFactory<ISAS_Services>.CreateChannel(new BasicHttpBinding("BasicHttpBinding_ISAS_Services"),
              new EndpointAddress(System.Configuration.ConfigurationManager.AppSettings["wcfSeguridad"].ToString().Trim()));

        public static bool Autorizado(int pSistema, string pUsuario, string pToken, string pMetodo, int pFlujo, int pOperacion, string pMsgErr)
        {
            bool Autoriza = false;
            try { Autoriza = SASwRef.autenticarWCFMetodo(pSistema, pUsuario, pToken, pMetodo, pFlujo, pOperacion, ref pMsgErr); }
            catch (Exception ex) { pMsgErr = ex.InnerException == null ? "ExWCF. No Genero Error." : ex.InnerException.Message; return false; };
            return Autoriza;
        }
        public static List<SAS_DTO.SAS_MENUS_DTO> MenuListado()
        {
            return SASwRef.qry_SAS_MENUS_listado();
        }
        public static List<SAS_DTO.SAS_MENUS_DTO> MenuFiltrado(SAS_DTO.SAS_MENUS_DTO precMenu)
        {
            return SASwRef.qry_SAS_MENUS_filtrado(precSASMENU: precMenu);
        }
    }


    //public static class Seguridad
    //{
    //    public static Dictionary<string, string> DictionaryClaims = new Dictionary<string, string>();

    //    private static ISAS_Services SASwRef = ChannelFactory<ISAS_Services>.CreateChannel(new BasicHttpBinding("BasicHttpBinding_ISAS_Services"),
    //          new EndpointAddress(System.Configuration.ConfigurationManager.AppSettings["wcfSeguridad"].ToString().Trim()));

    //    public static bool Autorizado(int pSistema, string pUsuario, string pToken, string pMetodo, int pFlujo, int pOperacion, string pMsgErr)
    //    {
    //        bool Autoriza = false;
    //        try { Autoriza = SASwRef.autenticarWCFMetodo(pSistema, pUsuario, pToken, pMetodo, pFlujo, pOperacion, ref pMsgErr); }
    //        catch (Exception ex) { pMsgErr = ex.InnerException == null ? "ExWCF. No Genero Error." : ex.InnerException.Message; return false; };
    //        return Autoriza;
    //    }

    //    public static bool AutorizadoMetodoUsuario(string pUsuario, string pMetodo, string pMensajeError = null)
    //    {
    //        AutorizadoMetodoUsuario(pMetodo);
    //        return true;
    //    }

    //    public static void AutorizadoMetodoUsuario(string pMetodo)
    //    {

    //        try
    //        {
    //            if (System.Configuration.ConfigurationManager.
    //                AppSettings["ActivarValidacionAutorizacionMetodoWCF"].ToString().Trim() == "false") { return; }

    //            Seguridad.DictionaryClaims.Clear();
    //            var headers = System.ServiceModel.OperationContext.Current.IncomingMessageHeaders;
    //            foreach (var header in headers)
    //            {
    //                if (Enum.GetNames(typeof(PAG_DTO.AUX_CONST_DTO.keysClaims)).ToList().Exists(col => col == header.Name))
    //                {
    //                    Seguridad.DictionaryClaims.Add(header.Name, headers.GetHeader<string>(header.Name, PAG_DTO.AUX_CONST_DTO.PAG_HEADER_NAMESPACE));
    //                }
    //            }
    //            //
    //            string vMsgErr = "";
    //            var Usuario = Seguridad.DictionaryClaims.ContainsKey(keysClaims.NAME.ToString()) ? Seguridad.DictionaryClaims[keysClaims.NAME.ToString()] : "PAG";
    //            var TOKEN = Seguridad.DictionaryClaims.ContainsKey(keysClaims.APP_TOKEN.ToString().ToUpper()) ? Seguridad.DictionaryClaims[keysClaims.APP_IDSESSION.ToString().ToUpper()] : "SIN_TOKEN";
    //            var Flujo = Seguridad.DictionaryClaims.ContainsKey(keysClaims.APP_IDFLUJO.ToString()) ? Seguridad.DictionaryClaims[keysClaims.APP_IDFLUJO.ToString()] : "0";
    //            var Operacion = Seguridad.DictionaryClaims.ContainsKey(keysClaims.APP_IDOPERACION.ToString()) ? Seguridad.DictionaryClaims[keysClaims.APP_IDOPERACION.ToString()] : "0";

    //            //if (TOKEN.ToString() == System.Configuration.ConfigurationManager.AppSettings["TokenLinkwcfSTSServices"].ToString().Trim()) { return; }

    //            //var seg = new SAS_SEGURIDAD_RDN();
    //            //if (!seg.autenticarWCFMetodo(4, Usuario.ToString(), TOKEN.ToString().ToUpper(), PrefijoMetodo + pMetodo, 0, 0, ref vMsgErr))
    //            //{
    //            //    throw new Exception("Usuario NO Autorizado para WCF-SAS.  " + vMsgErr);
    //            //}

    //        }
    //        catch (Exception Ex)
    //        {
    //            throw new FaultException("Usuario NO Autorizado para WCF-SAS.",
    //                  new FaultCode("SAS-20000"), Ex.InnerException.InnerException.Message);
    //        }
    //        return;
    //    }


    //    public static List<SAS_DTO.SAS_MENUS_DTO> MenuListado()
    //    {
    //        return SASwRef.qry_SAS_MENUS_listado();
    //    }
    //    public static List<SAS_DTO.SAS_MENUS_DTO> MenuFiltrado(SAS_DTO.SAS_MENUS_DTO precMenu)
    //    {
    //        return SASwRef.qry_SAS_MENUS_filtrado(precSASMENU: precMenu);
    //    }
    //}

    public static class PAG_Auditoria
    {
        public static bool Auditar(string nombreArchivo, string datosArchivo)
        {
            return false;/*
            UriBuilder uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
            var assemblyPath = Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path));
            File.WriteAllText(Path.Combine(assemblyPath, nombreArchivo).ToString(), datosArchivo);
            return true;*/
        }
    }
}