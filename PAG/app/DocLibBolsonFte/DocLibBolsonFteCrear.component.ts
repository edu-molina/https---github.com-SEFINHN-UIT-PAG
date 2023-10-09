import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core'
import { NgForm } from '@angular/forms'
import { Http } from '@angular/http'
//import { Router } from '@angular/router';

//import { SharedModule, DropdownModule, SelectItem, DataTableModule, DialogModule, ButtonModule } from 'primeng/primeng';

import { SelectItem} from 'primeng/primeng';

//import { FormBuilder, FormGroup, Validators } from '@angular/forms';

//import { DropdownModule, SelectItem, DataTableModule, SharedModule, DialogModule, ButtonModule, InputTextModule } from 'primeng/primeng';

import { NotificacionesService } from '../Services/NotificacionesService';
import { DocLibBolsonFteService } from './DocLibBolsonFte.service';

import { DocLibBolsonFteComponent } from './DocLibBolsonFte.component';

import { DLB_LIB_BOLSON_CAB_DTO } from '../Clases/DLB_LIB_BOLSON_CAB_DTO';
import { DLB_LIB_BOLSON_DET_DTO } from '../Clases/DLB_LIB_BOLSON_DET_DTO';
import { PRG_LIBRETAS_BOLSON_DTO } from '../Clases/PRG_LIBRETAS_BOLSON_DTO';
import { COLA_PARAMETROS_REPORTES_DTO } from '../Clases/COLA_PARAMETROS_REPORTES_DTO';


@Component({
    selector: 'doc-DocLibBolsonFteCrear',
    templateUrl: './DocLibBolsonFte/DocLibBolsonFteCrear'
})

export class DocLibBolsonFteCrearComponent implements OnInit {

    @Input() dlb_lib_bolson_cab: DLB_LIB_BOLSON_CAB_DTO;             
    @Input() tipo_operacion: String;
    @Output() notificar: EventEmitter<boolean> = new EventEmitter<boolean>();

    operaciones: SelectItem[];
    fuentes: SelectItem[];
    bancos: SelectItem[];
    libretas: SelectItem[];
    librosbanco: SelectItem[];
    monedas: SelectItem[];
    opcionDialogo: string;

    dlb_lib_bolson_det: DLB_LIB_BOLSON_DET_DTO[];
    registroDetalle: DLB_LIB_BOLSON_DET_DTO;

    consolidado_bolson_det: PRG_LIBRETAS_BOLSON_DTO[];

    listaSeleccionados: PRG_LIBRETAS_BOLSON_DTO[];

    mostrar: string = "";
    reporte: COLA_PARAMETROS_REPORTES_DTO = new COLA_PARAMETROS_REPORTES_DTO();
    habilitaReporte: boolean = false;
     
    // ----------------------para control de la pantalla
    // Indica si la cabecera ya fue creada
    cabeceraCreada: boolean = false;
    // esta variable indica si es necesario refrescar la lista de documentos
    refrescarLista: boolean = false;
    // esta varibale indica si el dropdown de tipo operacion debe estar activo o no
    desactivarTipoOperacion: boolean = false;
    // visualizan el dialogo de relaciones que corresponde para creación o modificación
    mostrarDialogoCrear: boolean ;
    mostrarDialogoModificar: boolean;
    registroDialogo: DLB_LIB_BOLSON_DET_DTO; 

    fuenteDialogo: string;
    // Control de listas en el dialogo
    bancoCargado: boolean = false; // para controlas la lista de Cuentas
    cuentaCargada: boolean = false; // para controlar la lista de Libretas


    constructor(private compLista: DocLibBolsonFteComponent,
        private _servicio: DocLibBolsonFteService,
        private Notificacion: NotificacionesService) {
        
    }

    ngOnInit() {   
        this._servicio.GetDominios("TIPO_OPERACION").then(data => {
            this.operaciones = <SelectItem[]>data;
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
        if (this.dlb_lib_bolson_cab.NRO_DOCUMENTO > 0) {
            this.desactivarTipoOperacion = true;
            this.cabeceraCreada = true;
        }        
        this.llenadoRelaciones(this.dlb_lib_bolson_cab);
        if (this.dlb_lib_bolson_cab.NRO_DOCUMENTO > 0) { this.habilitaReporte = true; }
    }

    borrarRelacion(dlb_lib_bolson_det: DLB_LIB_BOLSON_DET_DTO) {
        if (this.registroDetalle) {
            this._servicio.borrarDetalle(this.registroDetalle).subscribe(data => {
                this.registroDetalle = null;
                this.Notificacion.Success("");
                this.llenadoRelaciones(this.dlb_lib_bolson_cab);
            }, (error: any) => {
                this.Notificacion.Warning(error);
            });
        }
        else { this.Notificacion.Warning("Seleccione un registro");}
    }

    cerrarDialog() {
        if (this.mostrarDialogoModificar) this.mostrarDialogoModificar = false;
        if (this.mostrarDialogoCrear) this.mostrarDialogoCrear = false;
    }

    clickFila(evento: any) {
        this.registroDetalle = evento.data;
    }
    extraerFecha(dato: string): string {
        if (dato) {
            let miDato = dato.substring(dato.indexOf('(', 0) + 1, dato.length - 2);
            return miDato;
        }
        else return null;
    }

    habilitarBoton(boton: string, estado: string): boolean {
        switch (boton) {
            case "CONSULTAR":
                return true;
            case "CREAR":
                if (this.compLista.operacionPerfil == "REGISTRAR") { return true; }
            case "MODIFICAR":
                if (this.compLista.operacionPerfil == "REGISTRAR" && estado == "ELABORADO" && this.dlb_lib_bolson_cab.TIPO_OPERACION != "B") { return true; }
                break;
            case "VERIFICAR":
                if (this.compLista.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
                break;
            case "DESVERIFICAR":
                if (this.compLista.operacionPerfil == "REGISTRAR" && estado == "VERIFICADO") { return true; }
                break;
            case "ELIMINAR":
                if (this.compLista.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
                break;
            case "AGREGAR":
                if (this.compLista.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
                break;
            case "BORRAR":
                if (this.compLista.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
                break;
            case "APROBAR":
                if (this.compLista.operacionPerfil == "APROBAR" && estado == "VERIFICADO") { return true; }
                break;
            default:
                break;
        }
        return false;
    }

    llenadoAcumulado(dlb_lib_bolson_det: DLB_LIB_BOLSON_DET_DTO) {
        this._servicio.GetConsolidado(dlb_lib_bolson_det).subscribe(data => {
            this.consolidado_bolson_det = data;
        }, (error: any) => {
            this.Notificacion.Error(error);
        });
    }

    llenadoRelaciones(dlb_lib_bolson_cab: DLB_LIB_BOLSON_CAB_DTO) {
        this._servicio.GetDetalle(dlb_lib_bolson_cab).subscribe(data => {
            this.dlb_lib_bolson_det = data;
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }

    modificarRelacion(dlb_lib_bolson_det: DLB_LIB_BOLSON_DET_DTO) {

        if (this.registroDetalle) {
            this.registroDialogo = new DLB_LIB_BOLSON_DET_DTO();
            this.registroDialogo.GESTION = this.dlb_lib_bolson_cab.GESTION;
            this.registroDialogo.INSTITUCION = this.dlb_lib_bolson_cab.INSTITUCION;
            this.registroDialogo.GA = this.dlb_lib_bolson_cab.GA;
            this.registroDialogo.NRO_DOCUMENTO = this.dlb_lib_bolson_cab.NRO_DOCUMENTO;
            this.registroDialogo.SECUENCIA = dlb_lib_bolson_det.SECUENCIA;
            this.registroDialogo.PAG_INSTITUCION = dlb_lib_bolson_det.PAG_INSTITUCION;
            this.registroDialogo.PAG_GA = dlb_lib_bolson_det.PAG_GA;
            this.registroDialogo.LIB_GESTION = dlb_lib_bolson_det.LIB_GESTION;
            this.registroDialogo.LIB_BANCO = dlb_lib_bolson_det.LIB_BANCO;
            this.registroDialogo.LIB_CUENTA = dlb_lib_bolson_det.LIB_CUENTA;
            this.registroDialogo.LIB_LIBRETA = dlb_lib_bolson_det.LIB_LIBRETA;
            this.registroDialogo.FUENTE = dlb_lib_bolson_det.FUENTE;
            this.registroDialogo.MONEDA = dlb_lib_bolson_det.MONEDA;
            this.showDialogToMod();
        }
        else { this.Notificacion.Warning("Seleccione un registro"); }

    }

    nodeChangeBancos(event: any) {
        this.registroDialogo.LIB_BANCO = event.value;
        this.bancoCargado = false;
        // se carga la lista de cuentas bancarias
        this._servicio.GetLibrosBanco(this.dlb_lib_bolson_cab.GESTION.toString(),
            this.registroDialogo.LIB_BANCO.toString(), this.registroDialogo.MONEDA).then(data => {
                this.librosbanco = <SelectItem[]>data;
                this.bancoCargado = true;
            }, (error: any) => {
                this.Notificacion.Warning(error);
            });

    }
    nodeChangeCuentas(event: any) {
        this.registroDialogo.LIB_CUENTA = event.value;
        this.cuentaCargada = false;
        this._servicio.GetLibretas(this.dlb_lib_bolson_cab.GESTION.toString(),
            this.registroDialogo.LIB_BANCO.toString(),
            this.registroDialogo.LIB_CUENTA).then(data => {
                this.libretas = <SelectItem[]>data;
                this.cuentaCargada = true;
            }, (error: any) => {
                this.Notificacion.Warning(error);
            });
    }

    nodeChangeFuentes(event: any) {
        this.registroDialogo.FUENTE = event.value;
    }

    nodeChangeLibretas(event: any) {
        this.registroDialogo.LIB_LIBRETA = event.value;
    }

    nodeChangeMonedas(event: any) {
        this.registroDialogo.MONEDA = event.value;
    }
    nodeChangeoperacion(event: any) {
        this.dlb_lib_bolson_cab.TIPO_OPERACION = event.value;
    }
    saveCab() {
        let continuar: boolean = true;
        if (this.dlb_lib_bolson_cab.TIPO_OPERACION == "") { this.Notificacion.Warning("Debe selecionar el tipo de operación"); continuar = false; }
        //

        if (continuar) {
            this.refrescarLista = true; // para que al volver se refresque el listado de documentos
            this._servicio.salvarCabecera(this.dlb_lib_bolson_cab).subscribe(data => {
                this.dlb_lib_bolson_cab = data;
                this.desactivarTipoOperacion = true;
                this.cabeceraCreada = true;
                this.Notificacion.Success("");
                this.habilitaReporte = true;
            }, (error: any) => {
                this.Notificacion.Warning(error);
            }); 
        }
    }

    salvarListaModificar() {
            let continuar = true;

            if (this.listaSeleccionados == null) {
                this.Notificacion.Warning("Debe seleccionar algún valor");
                continuar = false;
            }
            if (continuar) {
                let x: number = this.listaSeleccionados.length
                // alert(x);
                var salida: DLB_LIB_BOLSON_DET_DTO[] = [];
                var nuevo: DLB_LIB_BOLSON_DET_DTO;

                for (var i = 0; i < this.listaSeleccionados.length; i++) {
                    nuevo = new DLB_LIB_BOLSON_DET_DTO();
                    nuevo.GESTION = this.dlb_lib_bolson_cab.GESTION;
                    nuevo.INSTITUCION = this.dlb_lib_bolson_cab.INSTITUCION;
                    nuevo.GA = this.dlb_lib_bolson_cab.GA;
                    nuevo.NRO_DOCUMENTO = this.dlb_lib_bolson_cab.NRO_DOCUMENTO;
                    nuevo.PAG_INSTITUCION = this.listaSeleccionados[i].INSTITUCION;
                    nuevo.PAG_GA = this.listaSeleccionados[i].GA;
                    nuevo.LIB_GESTION = this.listaSeleccionados[i].GESTION;
                    nuevo.LIB_BANCO = this.listaSeleccionados[i].BANCO;
                    nuevo.LIB_CUENTA = this.listaSeleccionados[i].CUENTA;
                    nuevo.LIB_LIBRETA = this.listaSeleccionados[i].LIBRETA;
                    nuevo.MONEDA = this.listaSeleccionados[i].MONEDA;
                    nuevo.FUENTE = this.listaSeleccionados[i].FUENTE;

                    nuevo.API_ESTADO = 'CREADO';
                    nuevo.API_TRANSACCION = 'CREAR';
                    salida.push(nuevo);
                }

                this._servicio.SalvarArregloDetalles(salida).subscribe((data: any) => {
                    this.Notificacion.Success("");
                    this.mostrarDialogoModificar = false;
                    this.llenadoRelaciones(this.dlb_lib_bolson_cab);
                });
                (error: any) => { this.Notificacion.Error(error); }
                this.listaSeleccionados = null;
                this.consolidado_bolson_det = null;
            }
    }
    salvarRelacion() {
        //
        switch (this.dlb_lib_bolson_cab.TIPO_OPERACION) {
            case "A":
                this.salvarRelacionCrear();
                break;
            case "M":
                this.salvarRelacionModificar();
                break;
            case "B":
                this.salvarRelacionModificar();
                break;
            default:
                break;
        }
    }

    salvarRelacionCrear() {
        if (this.opcionDialogo == "CREAR") {
            this.registroDialogo.GESTION = this.dlb_lib_bolson_cab.GESTION;
            this.registroDialogo.INSTITUCION = this.dlb_lib_bolson_cab.INSTITUCION;
            this.registroDialogo.GA = this.dlb_lib_bolson_cab.GA;
            this.registroDialogo.NRO_DOCUMENTO = this.dlb_lib_bolson_cab.NRO_DOCUMENTO;
            this.registroDialogo.PAG_INSTITUCION = this.dlb_lib_bolson_cab.INSTITUCION;
            this.registroDialogo.PAG_GA = this.dlb_lib_bolson_cab.GA;
            this.registroDialogo.LIB_GESTION = this.dlb_lib_bolson_cab.GESTION;
            //
            this._servicio.salvarDetalle(this.registroDialogo).subscribe(data => {
                this.registroDialogo = data;
                this.mostrarDialogoCrear = false;
                this.Notificacion.Success("");
                this.llenadoRelaciones(this.dlb_lib_bolson_cab);
                this.opcionDialogo = "NINGUNO";
            }, (error: any) => {
                this.Notificacion.Warning(error);
            });
        } else {
            this._servicio.salvarDetalleModif(this.registroDialogo).subscribe(data => {
                this.registroDialogo = data;
                this.mostrarDialogoCrear = false;
                this.Notificacion.Success("");
                this.llenadoRelaciones(this.dlb_lib_bolson_cab);
                this.opcionDialogo = "NINGUNO";
            }, (error: any) => {
                this.Notificacion.Warning(error);
            });
        }
    }

    salvarRelacionModificar() {
        if (this.opcionDialogo == "CREAR") {
        } else {
            this._servicio.salvarDetalleModif(this.registroDialogo).subscribe(data => {
                this.registroDialogo = data;
                this.mostrarDialogoCrear = false;
                this.Notificacion.Success("");
                this.llenadoRelaciones(this.dlb_lib_bolson_cab);
                this.opcionDialogo = "NINGUNO";
            }, (error: any) => {
                this.Notificacion.Warning(error);
            });
        }
    }

    showDialogToAdd() {        
        switch (this.dlb_lib_bolson_cab.TIPO_OPERACION) {
            case "A":
                this.bancoCargado = false;
                this.cuentaCargada = false;
                this.dialogAddCrear();
                break;
            case "M":
                this.dialogAddModificar();
                break;
            case "B":
                this.dialogAddModificar();
                break;
            default:
                break;
        }
    }
    dialogAddCrear() {
        this.mostrarDialogoCrear = true;
        this.opcionDialogo = "CREAR";
        this.registroDialogo = new DLB_LIB_BOLSON_DET_DTO();
        this._servicio.GetFuentes().then(data => {
            this.fuentes = <SelectItem[]>data;
        });
        this._servicio.GetBancos().then(data => {
            this.bancos = <SelectItem[]>data;
        });
        this._servicio.GetMonedas().then(data => {
            this.monedas = <SelectItem[]>data;
        });
    }
    dialogAddModificar() {
        this.listaSeleccionados = null;
        this.mostrarDialogoModificar = true;
        this.opcionDialogo = "CREAR";
        // cargar la lista de relaciones desde el acumulado
        this.registroDialogo = new DLB_LIB_BOLSON_DET_DTO();
        this.registroDialogo.GESTION = this.dlb_lib_bolson_cab.GESTION;
        this.registroDialogo.INSTITUCION = this.dlb_lib_bolson_cab.INSTITUCION;
        this.registroDialogo.GA = this.dlb_lib_bolson_cab.GA;
        this.registroDialogo.NRO_DOCUMENTO = this.dlb_lib_bolson_cab.NRO_DOCUMENTO;
        this.registroDialogo.PAG_INSTITUCION = this.dlb_lib_bolson_cab.INSTITUCION;
        this.registroDialogo.PAG_GA = this.dlb_lib_bolson_cab.GA;
        this.llenadoAcumulado(this.registroDialogo);
    }
    showDialogToMod() {
        
        this.opcionDialogo = "MODIFICAR";

        this._servicio.GetMonedas().then(data => {
            this.monedas = <SelectItem[]>data;
        });

        this._servicio.GetFuentes().then(data => {
            this.fuentes = <SelectItem[]>data;
        });

        this._servicio.GetBancos().then(data => {
            this.bancos = <SelectItem[]>data;
            this.bancoCargado = true;
        });

        this._servicio.GetLibrosBanco(this.dlb_lib_bolson_cab.GESTION.toString(),
            this.registroDialogo.LIB_BANCO.toString(), this.registroDialogo.MONEDA).then(data => {
                this.librosbanco = <SelectItem[]>data;
                this.cuentaCargada = true;
            }, (error: any) => {
                this.Notificacion.Warning(error);
            });

        this._servicio.GetLibretas(this.dlb_lib_bolson_cab.GESTION.toString(),
            this.registroDialogo.LIB_BANCO.toString(),
            this.registroDialogo.LIB_CUENTA).then(data => {
                this.libretas = <SelectItem[]>data;
                this.mostrarDialogoCrear = true;
            }, (error: any) => {
                this.Notificacion.Warning(error);
            });


    }
    
    volver() {
        this.compLista.mostrar = 'listado';
        this.notificar.emit(false);
    }
    ImprimirReporte() {
        this.reporte.REPORTE = 'r_pag_liboc';
        this.reporte.PARAMETROS = '<PA_GESTION>' + this.dlb_lib_bolson_cab.GESTION + '</PA_GESTION><PA_INSTITUCION>' + this.dlb_lib_bolson_cab.INSTITUCION + '</PA_INSTITUCION><PA_GA>' + this.dlb_lib_bolson_cab.GA + '</PA_GA><PA_NRO_DOCUMENTO>' + this.dlb_lib_bolson_cab.NRO_DOCUMENTO + '</PA_NRO_DOCUMENTO>';
        this.reporte.API_TRANSACCION = 'CREAR'
        this.mostrar = 'Doc-Reporte';
        this.reporte.API_ESTADO = 'REPORTE DE DOCUMENTO DE LIBRETAS BOLSON';
        // this.operacion = "crear";
    }   
    Recargar(event: boolean) {
        if (event) {
            this.mostrar = "";
        }
    } 
}