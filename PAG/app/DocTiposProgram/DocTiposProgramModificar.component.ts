import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
//import { TextMaskModule } from 'angular2-text-mask';
import { NgForm } from '@angular/forms';
import { Http } from '@angular/http';
//import { SharedModule, DropdownModule, SelectItem, DataTableModule } from 'primeng/primeng';
import { DropdownModule, SelectItem, DataTableModule, SharedModule, DialogModule, ButtonModule, InputTextModule } from 'primeng/primeng';
import { NotificacionesService } from '../Services/NotificacionesService';
import { DialogService } from '../Services/DialogService';

import { Dtp_Tipos_Program_CabService } from './Dtp_Tipos_Program_Cab.Service'
import { Dtp_Tipos_Program_CabComponent } from './Dtp_Tipos_Program_Cab.component'

import { DTP_TIPOS_PROGRA_CAB_DTO } from '../Clases/DTP_TIPOS_PROGRA_CAB_DTO';
import { DTP_TIPOS_PROGRA_DET_DTO } from '../Clases/DTP_TIPOS_PROGRA_DET_DTO';
import { DTP_DOCUMENTOS_DET_DTO } from '../Clases/DTP_DOCUMENTOS_DET_DTO';
import { DTP_DETALLES_DET_DTO } from '../Clases/DTP_DETALLES_DET_DTO';
import { VM_PAG_LISTA_VALORES_DTO } from '../Clases/VM_PAG_LISTA_VALORES_DTO';

@Component({
    selector: 'doc-DocTiposProgramModif',
    templateUrl: './DocTiposProgram/DocTiposProgramModif'
})

export class DoctiposProgramModificarcomponent implements OnInit {
    @Input() dtp_tipos_program_cab: DTP_TIPOS_PROGRA_CAB_DTO;
    @Input() tipo_operacion: String;
    @Output() notificar: EventEmitter<boolean> = new EventEmitter<boolean>();

    operaciones: SelectItem[];
    documentos: SelectItem[];
    columnas: SelectItem[];
    //operacion: number;
    //dtp_tipos_program_cab :  DTP_TIPOS_PROGRA_CAB_DTO;
    dtp_tipos_program_det: DTP_TIPOS_PROGRA_DET_DTO[];
    dtp_documentos_det: DTP_DOCUMENTOS_DET_DTO[];
    dtp_detalles_det: DTP_DETALLES_DET_DTO[];
    vm_pag_lista_valores_dto: VM_PAG_LISTA_VALORES_DTO[];
    dtp_detalles_det_Nuevo: DTP_DETALLES_DET_DTO[];



    //variables para bloqueo de objetos 
    //PrograCabCreado: boolean = false;
    //PrograDetCreado: boolean = false;
   // DocDetCreado: boolean = false;
    bloqueadoDoc: string = "none";
    bloqueadoVal: string = "none";

    //modelo
    nDetProg: DTP_TIPOS_PROGRA_DET_DTO = new DTP_TIPOS_PROGRA_DET_DTO();
    nDetDoc: DTP_DOCUMENTOS_DET_DTO = new DTP_DOCUMENTOS_DET_DTO();
    nDetVal: DTP_DETALLES_DET_DTO = new DTP_DETALLES_DET_DTO();
    ValoresSelec: VM_PAG_LISTA_VALORES_DTO[];

    regTipoProgram: any;
    ValEspecial: boolean = false;
    ColumnaSelect: string = "";


    displayDialog: boolean;
    displayDialog2: boolean;
    displayDialog3: boolean;
    bandera3: boolean = false;
    bandera2: boolean = false;
    bandera: boolean = false;

    newProgDet: boolean = false;
    newDocDet: boolean = false;
    newValDet: boolean = false;


    constructor(private _service: Dtp_Tipos_Program_CabService,
        private compLista: Dtp_Tipos_Program_CabComponent,
        private Notificacion: NotificacionesService,
        private _DialogService: DialogService,
        private _http: Http) {

        //this.dtp_tipos_program_cab = new DTP_TIPOS_PROGRA_CAB_DTO();
    }

    ngOnInit() {
        //this.dtp_tipos_program_cab.NRO_DOCUMENTO = -1;
        this.llenadoTiposProgram(this.dtp_tipos_program_cab);
        //this._service.cargarProgramCab().then((data: any) => {
        //    this.dtp_tipos_program_cab = data;
        //});
        this._service.GetDominios("TIPO_OPERACION").then(data => {
            this.operaciones = <SelectItem[]>data;
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
        this._service.GetDoctoLov().then(data => {
            this.documentos = <SelectItem[]>data;
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }
    nodeChangeoperacion(event: any) {
        this.dtp_tipos_program_cab.TIPO_OPERACION = event.value;
    }

    GetDescProg(event: any) {
        this.nDetProg.DESC_TIPO_PROGRAMACION = event.target.value;
    }

    GetEspecialProg(event: any) {
        let valor: string
        //console.log(event.target.checked);
        if (event.target.checked == true) { valor = 'S' } else { valor = 'N' }
        this.nDetProg.ESPECIAL = valor;
    }
    GetObserDoc(event: any) {
        this.nDetDoc.OBSERVACION = event.target.value;
    }
    nodeChangeDT(event: any) {
        this.nDetDoc.ID_DOCUMENTO = event.value;

    }
    nodeChangeColumna(event: any) {
        this.ColumnaSelect = event.value;
        let entrada: DTP_DETALLES_DET_DTO = new DTP_DETALLES_DET_DTO();
        //console.log(this.nDetDoc);
        entrada.GA = this.nDetDoc.GA
        entrada.GA_PROG = this.nDetDoc.GA_PROG;
        entrada.INSTITUCION = this.nDetDoc.INSTITUCION;
        entrada.INSTITUCION_PROG = this.nDetDoc.INSTITUCION_PROG;
        entrada.GESTION = this.nDetDoc.GESTION;
        entrada.NRO_DOCUMENTO = this.nDetDoc.NRO_DOCUMENTO;
        entrada.TIPO_PROGRAMACION = this.nDetDoc.TIPO_PROGRAMACION;
        entrada.SECUENCIA_DOC = this.nDetDoc.SECUENCIA_DOC;
        entrada.ID_DOCUMENTO = this.nDetDoc.ID_DOCUMENTO;
        entrada.ID_COLUMNA = Number(this.ColumnaSelect);
        this._service.cargarValoresLista(entrada).subscribe((data: any) => {
            this.vm_pag_lista_valores_dto = data;
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }
    showDialogToAdd() {
        this.newProgDet = true;
        //this.car = new PrimeCar();
        this.bandera = true;
        this.displayDialog = true;
        this._service.cargarProgramDet(this.dtp_tipos_program_cab).then((data: any) => {
            this.nDetProg = data;
        });
        this.ValEspecial = false;
    }

    showDialogToAdd2() {
        this.newDocDet = true;
        //this.car = new PrimeCar();
        this.bandera2 = true;
        this.displayDialog2 = true;
        this.cargaDoctoDet(this.nDetProg);
    }
    showDialogToAdd3() {
        this.ValoresSelec = null;
        this.vm_pag_lista_valores_dto = null;
        this._service.GetColumnas(this.nDetDoc.ID_DOCUMENTO.toString(), "").then((data: any) => {
            this.columnas = <SelectItem[]>data;
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
        this.ColumnaSelect = "";
        this.newValDet = true;
        //this.car = new PrimeCar();
        this.bandera3 = true;
        this.displayDialog3 = true;
        // this.cargaDoctoDet(this.nDetProg);
    }
    saveProgDet() {
        let continuar: boolean = true;
        //let salida: boolean = false;
        if (this.nDetProg.DESC_TIPO_PROGRAMACION == "" || this.nDetProg.DESC_TIPO_PROGRAMACION == null) { this.Notificacion.Warning("Debe ingresar la descripción"); continuar = false; }
        if (continuar) {
            //if (this.nDetProg.ESPECIAL == 'on') { this.nDetProg.ESPECIAL == 'S'; } else { this.nDetProg.ESPECIAL == 'N'; }
            if (this.newProgDet) {

                this._service.AgregarProgramDet(this.nDetProg).subscribe((data: any) => {
                    this.nDetProg = data
                   // this.PrograDetCreado = true;
                    this.Notificacion.Success("");
                    this.bandera = false;
                    this.displayDialog = false;
                    this.llenadoTiposProgram(this.dtp_tipos_program_cab);
                }, (error: any) => {
                    this.Notificacion.Warning(error);
                });

            } else {
                this._service.ModificarProgramDet(this.nDetProg).subscribe((data: any) => {
                    this.nDetProg = data
                    this.Notificacion.Success("");
                    this.bandera = false;
                    this.displayDialog = false;
                    this.llenadoTiposProgram(this.dtp_tipos_program_cab);
                    //this.PrograDetCreado = true;
                }, (error: any) => {
                    this.Notificacion.Warning(error);
                });

            }


            // this.bloqueadoDoc = "block";
            //this.PrograDetCreado = t;
            //this.DocDetCreado = false;
            return;
        }
    }


    eliminaProgDet() {
        this.nDetProg.API_TRANSACCION = "ELIMINAR";
        this._service.EliminarProgramDet(this.nDetProg).subscribe((data: any) => {
            this.nDetProg = data;
            this.Notificacion.Success("");
            this.bandera = false;
            this.displayDialog = false;
            this.llenadoTiposProgram(this.dtp_tipos_program_cab);
        }); (error: any) => { this.Notificacion.Warning(error); }
    }

    saveDocDet() {
        let continuar: boolean = true;
        //let salida: boolean = false;
        console.log(this.nDetDoc.OBSERVACION);
        if (this.nDetDoc.ID_DOCUMENTO == "" || this.nDetDoc.ID_DOCUMENTO == null) { this.Notificacion.Warning("Debe seleccionar un tipo de documento"); continuar = false; }
        else if (this.nDetDoc.OBSERVACION == "" || this.nDetDoc.OBSERVACION == null) { this.Notificacion.Warning("Debe ingresar una observación "); continuar = false; }
        if (continuar) {
            //if (this.nDetProg.ESPECIAL == 'on') { this.nDetProg.ESPECIAL == 'S'; } else { this.nDetProg.ESPECIAL == 'N'; }
            if (this.newDocDet) {
                this.nDetDoc.API_TRANSACCION = "CREAR";

                this._service.AgregarDocDet(this.nDetDoc).subscribe((data: any) => {
                    this.nDetDoc = data
                  //  this.DocDetCreado = true;
                    this.Notificacion.Success("");
                    this.bandera2 = false;
                    this.displayDialog2 = false;
                    this.llenadoTipoDoc(this.nDetProg);
                }, (error: any) => {
                    this.Notificacion.Warning(error);
                });

            } else {
                this._service.ModificarDocDet(this.nDetDoc).subscribe((data: any) => {
                    this.nDetDoc = data
                    this.Notificacion.Success("");
                    this.bandera2 = false;
                    this.displayDialog2 = false;
                    this.llenadoTipoDoc(this.nDetProg);
                    //this.PrograDetCreado = true;
                }, (error: any) => {
                    this.Notificacion.Warning(error);
                });

            }


            // this.bloqueadoDoc = "block";
            //this.PrograDetCreado = t;
            //this.DocDetCreado = false;
            return;
        }
    }
    eliminaDocDet() {
        this.nDetDoc.API_TRANSACCION = "ELIMINAR";
        this._service.EliminarDocDet(this.nDetDoc).subscribe((data: any) => {
            this.nDetDoc = data;
            this.Notificacion.Success("");
            this.bandera2 = false;
            this.displayDialog2 = false;
            this.llenadoTipoDoc(this.nDetProg);
        }), (error: any) => {
            this.Notificacion.Warning(error);
        };
    }
    SalvaValoresDet() {
        let continuar = true;

        if (this.ValoresSelec == null) {
            this.Notificacion.Warning("Debe seleccionar algun valor");
            continuar = false;
        }
        else if (this.ColumnaSelect == '' || this.ColumnaSelect == null) {
            this.Notificacion.Warning("Debe seleccionar Una columna");
            continuar = false;
        }
        if (continuar) {
            let x: number = this.ValoresSelec.length
           // alert(x);
            var salida: DTP_DETALLES_DET_DTO[] = [];
            var nuevo: DTP_DETALLES_DET_DTO;
            for (var i = 0; i < this.ValoresSelec.length; i++) {
                nuevo = new DTP_DETALLES_DET_DTO();
                nuevo.API_ESTADO = 'CREADO';
                nuevo.API_TRANSACCION = 'CREAR';
                nuevo.GA = this.nDetDoc.GA;
                nuevo.GA_PROG = this.nDetDoc.GA_PROG;
                nuevo.INSTITUCION = this.nDetDoc.INSTITUCION;
                nuevo.INSTITUCION_PROG = this.nDetDoc.INSTITUCION_PROG;
                nuevo.GESTION = this.nDetDoc.GESTION;
                nuevo.ID_DOCUMENTO = this.nDetDoc.ID_DOCUMENTO;
                nuevo.TIPO_PROGRAMACION = this.nDetDoc.TIPO_PROGRAMACION;
                nuevo.NRO_DOCUMENTO = this.nDetDoc.NRO_DOCUMENTO;
                nuevo.SECUENCIA_DOC = this.nDetDoc.SECUENCIA_DOC;
                nuevo.ID_COLUMNA = Number(this.ColumnaSelect);
                nuevo.TIPO_COLUMNA = this.ValoresSelec[i].TIPO_VALOR;
                if (nuevo.TIPO_COLUMNA == 'VARCHAR2') {
                    nuevo.VALOR_CADENA = this.ValoresSelec[i].VALOR;
                }
                else { nuevo.VALOR_NUMERO = Number(this.ValoresSelec[i].VALOR); }
                salida.push(nuevo);
            }

            this._service.AgregarValDet(salida).subscribe((data: any) => {
                this.Notificacion.Success("");
                this.bandera3 = false;
                this.displayDialog3 = false;
                this.llenadoValores(this.nDetDoc);
            }); (error: any) => { this.Notificacion.Warning(error); }

        }
    }
    eliminarValor(event: any) {
        var Modificar = function () {
            let elim: DTP_DETALLES_DET_DTO = new DTP_DETALLES_DET_DTO();
            elim = event;
            this._service.EliminarValDet(elim).subscribe((data: any) => {
            }); (error: any) => { this.Notificacion.Warning(error); }
        }
        let estado = "¿Desea eliminar el valor selecionado?";
        this._DialogService.cancel('<i class="fa fa-times"></i> Cancelar')
            .message("¿Esta seguro de efectuar la operación?.").title(estado)
            .okay('<i class="fa fa-check"></i> Confirmar', Modificar.bind(this)).confirm();
        this.llenadoValores(this.nDetDoc);
    }
    Volver() {
        this.compLista.mostrar = 'listado';
        this.notificar.emit(false);
    }
    extraerFecha(dato: string): string {
        if (dato) {
            let miDato = dato.substring(dato.indexOf('(', 0) + 1, dato.length - 2);
            return miDato;
        }
        else return null;
    }
    cargaTipoProgram(filaSeleccionada: any) {
        this.regTipoProgram = filaSeleccionada;
    }
    llenadoTiposProgram(dtp_tipos_program_cab: DTP_TIPOS_PROGRA_CAB_DTO) {
        var precDet = new DTP_TIPOS_PROGRA_DET_DTO;
        precDet.GESTION = dtp_tipos_program_cab.GESTION;
        precDet.INSTITUCION = dtp_tipos_program_cab.INSTITUCION;
        precDet.GA = dtp_tipos_program_cab.GA;
        precDet.NRO_DOCUMENTO = dtp_tipos_program_cab.NRO_DOCUMENTO;
        this._service.GetTiposProgram(precDet).subscribe(data => {
            this.dtp_tipos_program_det = data;
            this.llenadoTipoDoc(this.dtp_tipos_program_det[0]);

        }); (error: any) => { this.Notificacion.Warning(error); }

    }
    llenadoTipoDoc(dtp_tipos_program_det: DTP_TIPOS_PROGRA_DET_DTO) {
        var precDet = new DTP_DOCUMENTOS_DET_DTO;
        precDet.GESTION = dtp_tipos_program_det.GESTION;
        precDet.INSTITUCION = dtp_tipos_program_det.INSTITUCION;
        precDet.GA = dtp_tipos_program_det.GA;
        precDet.NRO_DOCUMENTO = dtp_tipos_program_det.NRO_DOCUMENTO;
        precDet.INSTITUCION_PROG = dtp_tipos_program_det.INSTITUCION_PROG;
        precDet.GA_PROG = dtp_tipos_program_det.GA_PROG;
        precDet.TIPO_PROGRAMACION = dtp_tipos_program_det.TIPO_PROGRAMACION;
        this._service.GetTiposDoc(precDet).subscribe(data => {
            this.dtp_documentos_det = data;
            this.llenadoValores(this.dtp_documentos_det[0]);
        }); (error: any) => { this.Notificacion.Warning(error); }
    }
    llenadoValores(dtp_documentos_det: DTP_DOCUMENTOS_DET_DTO) {
        var precDet = new DTP_DETALLES_DET_DTO;
        precDet.GESTION = dtp_documentos_det.GESTION;
        precDet.INSTITUCION = dtp_documentos_det.INSTITUCION;
        precDet.GA = dtp_documentos_det.GA;
        precDet.NRO_DOCUMENTO = dtp_documentos_det.NRO_DOCUMENTO;
        precDet.INSTITUCION_PROG = dtp_documentos_det.INSTITUCION_PROG;
        precDet.GA_PROG = dtp_documentos_det.GA_PROG;
        precDet.SECUENCIA_DOC = dtp_documentos_det.SECUENCIA_DOC;
        precDet.TIPO_PROGRAMACION = dtp_documentos_det.TIPO_PROGRAMACION;
        this._service.GetValores(precDet).subscribe(data => {
            this.dtp_detalles_det = data;
        }, (error: any) => { this.Notificacion.Warning(error); });
    }


    clickFila(evento: any) {
        this.nDetProg = evento.data;
        this.nDetDoc = null;
        this.dtp_documentos_det = null;
        this.dtp_detalles_det = null;
        this.llenadoTipoDoc(evento.data);
        this.bloqueadoDoc = "block";
        
    }
    clickFilaDoc(evento: any) {
        this.dtp_detalles_det = null;
        this.nDetVal = null;
        this.llenadoValores(evento.data);
        this.nDetDoc = evento.data;
        this.bloqueadoVal = "block";
    }

    clickEditarProg(evento: any) {
        // alert("Entra");
        this.nDetProg = evento;
        this.nDetProg.API_TRANSACCION = 'MODIFICAR';
        this.newProgDet = false;
        // alert(this.nDetProg.ESPECIAL);
        if (this.nDetProg.ESPECIAL == "S") {
            this.ValEspecial = true;
        }
        else {
            this.ValEspecial = false;
        }
        this.displayDialog = true;
        this.bandera = true;
    }
    clickEditarDoc(evento: any) {
        this.displayDialog2 = true;
        this.bandera2 = true;
        this.nDetDoc = evento;
        this.nDetDoc.API_TRANSACCION = "MODIFICAR";
        this.newDocDet = false;
    }
    cargaDoctoDet(precDto: DTP_TIPOS_PROGRA_DET_DTO) {
        this.nDetDoc.GA = precDto.GA;
        this.nDetDoc.INSTITUCION = precDto.INSTITUCION;
        this.nDetDoc.GA_PROG = precDto.GA_PROG;
        this.nDetDoc.GESTION = precDto.GESTION;
        this.nDetDoc.INSTITUCION_PROG = precDto.INSTITUCION_PROG;
        this.nDetDoc.TIPO_PROGRAMACION = precDto.TIPO_PROGRAMACION;
        this.nDetDoc.NRO_DOCUMENTO = precDto.NRO_DOCUMENTO;
        //this.nDetDoc.API_TRANSACCION = "CREAR";
    }
    habilitarBoton(boton: string, estado: string): boolean {
        switch (boton) {
            case "CONSULTAR":
                return true;
            case "CREAR":
                if (this.compLista.operacionPerfil == "REGISTRAR") { return true; }
            case "MODIFICAR":
                if (this.compLista.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
                break;
            case "VERIFICAR":
                if (this.compLista.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
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

}