using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using PAG_INTERFACES;
using System.ServiceModel.Channels;

namespace PAG.Models
{
    public class Funciones
    {
        /*//Referencia Nueva USAR - DCLM: 15/07/2016*/
        //protected iPAG_Services wRef = new SefinClaims.CreateChannelSefin(
        //                               new Uri(System.Configuration.ConfigurationManager.AppSettings["wcfFideicomisos"].ToString().Trim()),
        //                               new BasicHttpBinding("bindingWcfPAG")).Create<iPAG_Services>();

        protected iPAG_Services wRef = DependencyResolver.Current.GetService<iPAG_Services>();
        /*//Referencia Obsoleta NO USAR - DCLM: 15/07/2016
        protected IPAG_Services wRef = ChannelFactory<IPAG_Services>.CreateChannel(new BasicHttpBinding(),
              new EndpointAddress(System.Configuration.ConfigurationManager.AppSettings["wcfFideicomisos"].ToString().Trim()));*/


        /*public SelectList slSiNo() {
            List<Def.TipoGenerico> tipos = new List<Def.TipoGenerico>();
            tipos.Add(new Def.TipoGenerico { Codigo = "S", Descripcion = "Si" });
            tipos.Add(new Def.TipoGenerico { Codigo = "N", Descripcion = "No" });

            return new SelectList(tipos, "Codigo", "Descripcion");
        }*/
        //public List<Tuple<string, string>> listSiNo()
        public SelectList slSiNo()
        {
            /*List<Def.TipoGenerico> tipos = new List<Def.TipoGenerico>();
            tipos.Add(new Def.TipoGenerico { Codigo = "S", Descripcion = "Si" });
            tipos.Add(new Def.TipoGenerico { Codigo = "N", Descripcion = "No" });
            */
            var tupleList = new List<Tuple<string, string>>
                {
                    new Tuple<string, string>("S", "Si" ),
                    new Tuple<string, string>( "N", "No" ),
                    
                };

            return new SelectList(tupleList, "Item1", "Item2");
        }


        public SelectList slEstados(string EstadoActual)
        {
            
            var tupleList = new List<Tuple<string, string>>();

            
                    switch (EstadoActual)
                    {
                        case "EN_REGISTRO":
                            tupleList.Add(new Tuple<string, string>("EN_REGISTRO", "EN_REGISTRO" ));
                            tupleList.Add(new Tuple<string, string>( "REGISTRAR", "REGISTRAR" ));
                            tupleList.Add(new Tuple<string, string>( "ELIMINAR", "ELIMINAR" ));
                            break;
                        case "REGISTRADO":                            
                            tupleList.Add(new Tuple<string, string>( "REGISTRADO", "REGISTRAR" ));
                            tupleList.Add(new Tuple<string, string>("EN_REGISTRO", "EN_REGISTRO"));
                            tupleList.Add(new Tuple<string, string>("APROBAR", "APROBAR"));
                            break;
                        case "APROBADO":
                            tupleList.Add(new Tuple<string, string>("APROBADO", "APROBADO"));
                            break;
                    }
            

            return new SelectList(tupleList, "Item1", "Item2");
        }


        public SelectList slDominios(Dominios? NombreDominio, string FiltroValor=null) {
            var listDominios = lDominios(NombreDominio, FiltroValor).ToList();

            return new SelectList(listDominios, "LOV_CODIGO", "LOV_DESCRIPCION");
        }

        public List<PAG_DTO.AUX_LOVS_DTO> lDominios(Dominios? NombreDominio, string FiltroValor=null)
        {
            if (NombreDominio != null)
            {
                var resp = wRef.qry_AUX_LOVS_DTO_filtrado(new PAG_DTO.AUX_LOVS_DTO { LOV_NOMBRE = NombreDominio.ToString(),  LOV_CODIGO = FiltroValor });
                return wRef.qry_AUX_LOVS_DTO_filtrado(new PAG_DTO.AUX_LOVS_DTO { LOV_NOMBRE = NombreDominio.ToString(), LOV_CODIGO = FiltroValor }).Where(x => x.LOV_NOMBRE == NombreDominio.ToString() && x.LOV_CODIGO == (FiltroValor != null ? FiltroValor : x.LOV_CODIGO)).ToList();
            }
            else { return wRef.qry_AUX_LOVS_DTO_filtrado(new PAG_DTO.AUX_LOVS_DTO { LOV_NOMBRE = "",  LOV_CODIGO=FiltroValor }).ToList(); }
        }
    }
    public enum Dominios
    { 
        TIPO_OPERACION,
        BANDERA,
        PAG_TIPO_DOCRES,
        PAG_TIPO_FICHA_DETALLE,
        //PAG_TIPO_FINANCIAMIENTO, //drodriguez 20160310 - Pasa a ser Clasificador solicitado por Danny Lainez
        PAG_TIPO_FONDOS,
        PAG_TIPO_FUENTE,
        PAG_TIPO_IDENTIFICADOR,
        PAG_TIPO_NATURALEZA,
        PAG_TIPO_OPERACION,
        PAG_TIPO_REPRESENTANTE,
        PAG_TIPO_VALOR,
        PAG_DOCFIC_CAB_DTO,
        PAG_TIPO_RELACION,
        PAG_TIPO_INFORMACION,
        PAG_TIPO_MOMENTO,
        PAG_TIPO_REGISTRO,
        PAG_TIPO_CONCESION,
        PAG_TIPO_BANDERA,
        PAG_TIPO_ESTADO_FINANCIERO,
        //Agregados para el Nuevo Docto de LIBROS - DCLM: 04/07/2016
        PAG_TIPO_DOCUMENTO,
        PAG_TIPO_LIBRO,
        PAG_TIPO_PERIODO,
        PAG_TIPO_EJECUCION,
        PAG_TIPO_PROGRAMA
    }

    public enum DOCDET_TIPO_FICHA
    { 
        BANCO,
        BENEFICIARIO,
        COMITE,
        DOCLEGAL,
        FIDEICOMISARIO,
        FIDEICOMISO,
        FINANCIAMIENTO,
        INSTITUCION,
        OBJETIVO,
        RESULTADO,
    }
    public class Def
    {
        public class TipoGenerico
        {
            public string Codigo;
            public string Descripcion;
        }
    }
    
    }