using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using PAG_DA;
using PAG_DTO;
using PAG_MAPPERS;

namespace PAG_WCF
{
    public class VM_PAG_LISTA_VALORES_RDN
    {
        public List<VM_PAG_LISTA_VALORES_DTO> VM_PAG_LISTA_VALORES_listado()
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<VM_PAG_LISTA_VALORES_DTO> listaValores = new List<VM_PAG_LISTA_VALORES_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    IQueryable<VM_PAG_LISTA_VALORES> query;
                    query = from rec in context.VM_PAG_LISTA_VALORES
                            select rec;
                    foreach (var item in query)
                    {
                        listaValores.Add(item.ToDto());
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return listaValores;
        }

        public List<VM_PAG_LISTA_VALORES_DTO> VM_PAG_LISTA_VALORES_filtrado(VM_PAG_LISTA_VALORES_DTO precDto)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<VM_PAG_LISTA_VALORES_DTO> listaValores = new List<VM_PAG_LISTA_VALORES_DTO>();
            //try
            //{
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var entity = precDto.ToEntity();
                    var filters = new VM_PAG_LISTA_VALORES_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //Aplicar pFilters Dinamico
                    if (!filters.hasFilters) { return listaValores; };
                    var filteredCollection = context.VM_PAG_LISTA_VALORES.Where(delegates).ToList();
                    //Transformar pFilter Dinamico
                    foreach (var item in filteredCollection) { listaValores.Add(item.ToDto()); }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return listaValores;
        }
        public List<VM_PAG_LISTA_VALORES_DTO> VM_PAG_LISTA_VALORES_filtradoDocto(DTP_DETALLES_DET_DTO precDetalle)
        {
            // TODO: Desarrolle su Codigo Aqui.
            List<VM_PAG_LISTA_VALORES_DTO> listaValores = new List<VM_PAG_LISTA_VALORES_DTO>();
            //try
            //{
                VM_PAG_LISTA_VALORES_DTO registro = new VM_PAG_LISTA_VALORES_DTO { ID_COLUMNA = precDetalle.ID_COLUMNA};
                using (PAG_Entities context = new PAG_Entities(PAG_Security.DictionaryClaims))
                {
                    var tipo_columna = "NINGUNA";
                    var existeDocumento = false;
                    // se buscan todos los registros posibles para la columna
                    var entity = registro.ToEntity();
                    var filters = new VM_PAG_LISTA_VALORES_FILTER();
                    var delegates = filters.GetExpression(entity);
                    //
                    if (!filters.hasFilters) { return listaValores; };
                    var filteredCollection = context.VM_PAG_LISTA_VALORES.OrderBy(x => x.VALOR).Where(delegates).ToList();
                    // se veifica si la lista tiene valores, para obtener el tipo valor de la columna
                    if (filteredCollection.Count > 0) {
                        tipo_columna = filteredCollection[0].TIPO_VALOR;
                    }else {
                        return listaValores;
                    };

                    //se buscan los registros detalles el documento
                    if (precDetalle.GESTION > 0 && precDetalle.INSTITUCION > 0 && precDetalle.GA > 0 && precDetalle.NRO_DOCUMENTO > 0) {
                        var entityDet = precDetalle.ToEntity();
                        var filtersDet = new DTP_DETALLES_DET_FILTER();
                        var delegatesDet = filtersDet.GetExpression(entityDet);
                        var filteredCollectionDet = context.DTP_DETALLES_DET.Where(delegatesDet).ToList();
                        if (filteredCollectionDet.Count > 0)
                        {
                            existeDocumento = true;
                            if (tipo_columna == "NUMBER")
                            {
                                foreach (var item in filteredCollection)
                                {
                                    var detFound = filteredCollectionDet.Find(det => det.ID_COLUMNA == precDetalle.ID_COLUMNA &&
                                                                              item.VALOR == det.VALOR_NUMERO.ToString());
                                    if (detFound == null)
                                    {
                                        listaValores.Add(item.ToDto());
                                    }
                                }
                            }
                            else
                            {
                                foreach (var item in filteredCollection)
                                {
                                    var detFound = filteredCollectionDet.Find(det => det.ID_COLUMNA == precDetalle.ID_COLUMNA &&
                                                                              item.VALOR == det.VALOR_CADENA);
                                    if (detFound == null)
                                    {
                                        listaValores.Add(item.ToDto());
                                    }
                                }

                            }// if else
                        }
                    }// existe documento
                    // Si no se comparó con ningún documento, se carga la lista completa
                    if (!existeDocumento) {
                        foreach (var item in filteredCollection) { 
                           listaValores.Add(item.ToDto());
                        }
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    throw new FaultException(PAG_ServicesUtil.ErrorPAGDescDefecto, new FaultCode(PAG_ServicesUtil.ErrorPAGCodDefecto), Ex.InnerException.InnerException.Message);
            //}
            return listaValores;
        }
    }
}