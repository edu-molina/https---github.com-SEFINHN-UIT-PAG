import { Component, OnInit, Input, EventEmitter, Output  } from '@angular/core'
import { NgForm } from '@angular/forms'
import { Http } from '@angular/http'
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
import { TPR_TIPOS_PROGRAMACION_DTO } from '../Clases/TPR_TIPOS_PROGRAMACION_DTO';
import { DCO_COLUMNAS_DTO } from '../Clases/DCO_COLUMNAS_DTO';
import { COLA_PARAMETROS_REPORTES_DTO } from '../Clases/COLA_PARAMETROS_REPORTES_DTO';

@Component({
    selector: 'doc-DocTiposProgramCrear',
    templateUrl: './DocTiposProgram/DocTiposProgramCrear'
})

export class DocTiposProgramCrearComponent implements OnInit {

    @Input() dtp_tipos_program_cab: DTP_TIPOS_PROGRA_CAB_DTO;
    @Input() tipo_operacion: String;
    @Output() notificar: EventEmitter<boolean> = new EventEmitter<boolean>();

    operaciones: SelectItem[];
    documentos: SelectItem[];
    columnas: SelectItem[];
    

    dtp_tipos_program_det: DTP_TIPOS_PROGRA_DET_DTO[];
    dtp_documentos_det: DTP_DOCUMENTOS_DET_DTO[];
    dtp_detalles_det: DTP_DETALLES_DET_DTO[];
    vm_pag_lista_valores_dto: VM_PAG_LISTA_VALORES_DTO[];
    dtp_detalles_det_Nuevo: DTP_DETALLES_DET_DTO[];
    tpr_tipos_programacion: TPR_TIPOS_PROGRAMACION_DTO[];
    

    //variables para bloqueo de objetos 
    PrograCabCreado: boolean = false;
    PrograDetCreado: boolean = false;
    DocDetCreado: boolean = false;
    bloqueadoDoc: string = "none";
    bloqueadoVal: string = "none";
    mostrar: string = ""; 
    reporte: COLA_PARAMETROS_REPORTES_DTO = new COLA_PARAMETROS_REPORTES_DTO();

    //modelo
    nDetProg: DTP_TIPOS_PROGRA_DET_DTO = new DTP_TIPOS_PROGRA_DET_DTO();
    nDetDoc: DTP_DOCUMENTOS_DET_DTO = new DTP_DOCUMENTOS_DET_DTO();
    nDetVal: DTP_DETALLES_DET_DTO = new DTP_DETALLES_DET_DTO();
    ValoresSelec: VM_PAG_LISTA_VALORES_DTO[];

    varTipoProg: DTP_TIPOS_PROGRA_DET_DTO;
    varTipoDocto: DTP_DOCUMENTOS_DET_DTO;

    regTipoProgram: any;
    ValEspecial: boolean = false;
    ColumnaSelect: string = "";


    displayDialog: boolean;
    displayDialog2: boolean;
    displayDialog3: boolean;
    habilitaReporte: boolean = false;
    displayDialogTipoProg: boolean = false;

    bandera3: boolean = false;
    bandera2: boolean = false;
    bandera: boolean = false;

    newProgDet: boolean = false;
    newDocDet: boolean = false;
    newValDet: boolean = false;

    // sirve para refrescar al regresar a la lista de documento 
    refrescarLista: boolean = false;
    // sirve para que no se permita cambiar el tipo de operaci>n de documento
    desactivarTipoOperacion: boolean = false;

    documentoSeleccionado: DTP_DOCUMENTOS_DET_DTO;
    // lsta de los tipos de programación seleccionados en el diálogo de modificar o eliminar
    listaSelecTiposProg: TPR_TIPOS_PROGRAMACION_DTO[];
    // indica si una columna tiene lista de valores asociada valores S/N
    columna: DCO_COLUMNAS_DTO;
    mostrarListaColumna: boolean = false;
    columnaNumerica: boolean = false;
    valorCadena: string;
    valorNumero: number;

    constructor(private _service: Dtp_Tipos_Program_CabService ,
        private compLista: Dtp_Tipos_Program_CabComponent,
        private Notificacion: NotificacionesService,
        private _DialogService: DialogService,
                private _http: Http) {

        //this.dtp_tipos_program_cab = new DTP_TIPOS_PROGRA_CAB_DTO();
    }

    ngOnInit() {

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
        if (this.dtp_tipos_program_cab.NRO_DOCUMENTO > 0) {  // Si el documento ya fue creado
            //se desactiva el tipo de operación
            this.desactivarTipoOperacion = true;
            this.PrograCabCreado = true;
        } else {  // si es un documento nuevo
            this.desactivarTipoOperacion = false;
            this.dtp_tipos_program_cab.NRO_DOCUMENTO = -1;
        }
        this.llenadoTiposProgram(this.dtp_tipos_program_cab);
        //verifica si puede imprimir el reporte en caso de ser opcion de modificacion
        if (this.dtp_tipos_program_cab.NRO_DOCUMENTO > 0) { this.habilitaReporte = true; }
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
    //GetValor(event: any) {
    //    if (this.columna.TIPO_COLUMNA == "NUMBER") {

    //    }
    //    else {
    //    }
    //    this.valor = event.target.value;
    //}
    nodeChangeDT(event: any) {
        this.nDetDoc.ID_DOCUMENTO = event.value;

    }
    nodeChangeColumna(event: any) {
        this._service.cargarValoresColumnaSeleccionada(this.nDetVal.ID_COLUMNA.toString()).then(data => {
            this.columna = data;
            this.mostrarListaColumna = this.columna.TIENE_LISTA == 'S';
            this.columnaNumerica = this.columna.TIPO_COLUMNA == "NUMBER";
            if (this.columna.TIENE_LISTA == 'S') {
                this.ColumnaSelect = this.columna.ID_COLUMNA.toString();
                let entrada: DTP_DETALLES_DET_DTO = new DTP_DETALLES_DET_DTO();
                entrada.GA = this.nDetDoc.GA
                entrada.GA_PROG = this.nDetDoc.GA_PROG;
                entrada.INSTITUCION = this.nDetDoc.INSTITUCION;
                entrada.INSTITUCION_PROG = this.nDetDoc.INSTITUCION_PROG;
                entrada.GESTION = this.nDetDoc.GESTION;
                entrada.NRO_DOCUMENTO = this.nDetDoc.NRO_DOCUMENTO;
                entrada.TIPO_PROGRAMACION = this.nDetDoc.TIPO_PROGRAMACION;
                entrada.SECUENCIA_DOC = this.nDetDoc.SECUENCIA_DOC;
                entrada.ID_DOCUMENTO = this.nDetDoc.ID_DOCUMENTO;
                entrada.ID_COLUMNA = this.columna.ID_COLUMNA;
                this._service.cargarValoresLista(entrada).subscribe((data: any) => {
                    this.vm_pag_lista_valores_dto = data;
                }, (error: any) => {
                    this.Notificacion.Warning(error);
                });
            }
        });

    }
    showDialogToAdd() {
        if (this.dtp_tipos_program_cab.TIPO_OPERACION == "A") {// si es una creación
            this.newProgDet = true;
            //this.car = new PrimeCar();
            this.bandera = true;
            this.displayDialog = true;
            this._service.cargarProgramDet(this.dtp_tipos_program_cab).then((data: any) => {
                this.nDetProg = data;
            }, (error: any) => {
                this.Notificacion.Warning(error);
            });
            this.ValEspecial = false;
        } else {// si es modificación o eliminación, se visualiza la lista de tipos del consolidado
            var detalle: DTP_TIPOS_PROGRA_DET_DTO = new DTP_TIPOS_PROGRA_DET_DTO();
            detalle.GESTION = this.dtp_tipos_program_cab.GESTION;
            detalle.INSTITUCION = this.dtp_tipos_program_cab.INSTITUCION;
            detalle.GA = this.dtp_tipos_program_cab.GA;
            detalle.NRO_DOCUMENTO = this.dtp_tipos_program_cab.NRO_DOCUMENTO;
            this._service.GetListaTiposProgramConsolidado(detalle).subscribe(data => {
                this.tpr_tipos_programacion = data;
                this.displayDialogTipoProg = true;
            }, (error: any) => {
                this.Notificacion.Warning(error);
            });
            
        }
    }

    showDialogToAdd2() {
        this.newDocDet = true;
        this.bandera2 = true;
        this.displayDialog2 = true;
        this.nDetDoc = new DTP_DOCUMENTOS_DET_DTO();
        this.nDetDoc.GESTION = this.nDetProg.GESTION;
        this.nDetDoc.INSTITUCION = this.nDetProg.INSTITUCION;
        this.nDetDoc.GA = this.nDetProg.GA;
        this.nDetDoc.NRO_DOCUMENTO = this.nDetProg.NRO_DOCUMENTO;
        this.nDetDoc.INSTITUCION_PROG = this.nDetProg.INSTITUCION_PROG;
        this.nDetDoc.GA_PROG = this.nDetProg.GA_PROG;
        this.nDetDoc.TIPO_PROGRAMACION = this.nDetProg.TIPO_PROGRAMACION;
        this.cargaDoctoDet(this.nDetProg);
    }
    showDialogToAdd3() {
        if (this.documentoSeleccionado) {

            this.ValoresSelec = null;
            this.vm_pag_lista_valores_dto = null;
            this._service.GetColumnas(this.nDetProg.ESPECIAL, this.nDetDoc.ID_DOCUMENTO).then((data: any) => {
                this.columnas = <SelectItem[]>data;
                this.ColumnaSelect = "";
                this.nDetVal.ID_COLUMNA = null;
                this.newValDet = true;
            }, (error: any) => {
            this.Notificacion.Warning(error);
        });
            //this.car = new PrimeCar();
            this.bandera3 = true;
            this.displayDialog3 = true;
            // inicializar valores diálogo
            this.valorCadena = null;
            this.valorNumero = null;
            
            this.ValoresSelec = null;

            // this.cargaDoctoDet(this.nDetProg);
        }
    }
    saveCab() {
        let continuar: boolean = true;
        //alert("continua");
        if (this.dtp_tipos_program_cab.TIPO_OPERACION == "") { this.Notificacion.Warning("Debe selecionar el tipo de operación"); continuar = false; } 

        if (continuar) {
            this._service.AgregarProgramCab(this.dtp_tipos_program_cab).subscribe((data: any) => {
                this.Notificacion.Success(" ");
                this.dtp_tipos_program_cab = data
                this.refrescarLista = true;
               // this.bandera = false;
               //this.displayDialog = false;
                this.PrograCabCreado = true;
                this.desactivarTipoOperacion = true;
                this.habilitaReporte = true;
            }, (error: any) => {
                this.Notificacion.Warning(error);
            }
  );

           // this.bloqueadoDoc = "block";
            //this.PrograDetCreado = t;
            //this.DocDetCreado = false;
            return;
        }
    }
    saveProgDet() {
        let continuar: boolean = true;
        //let salida: boolean = false;
        if (this.nDetProg.DESC_TIPO_PROGRAMACION == "" || this.nDetProg.DESC_TIPO_PROGRAMACION == null) { this.Notificacion.Warning("Debe ingresar la descripción"); continuar = false; }
        if (continuar) {
            //if (this.nDetProg.ESPECIAL == 'on') { this.nDetProg.ESPECIAL == 'S'; } else { this.nDetProg.ESPECIAL == 'N'; }
            if (this.newProgDet){

            this._service.AgregarProgramDet(this.nDetProg).subscribe((data: any) => {
                this.nDetProg = data
                this.PrograDetCreado = true;
                this.Notificacion.Success("");
                this.bandera = false;
                this.displayDialog = false;
                this.llenadoTiposProgram(this.dtp_tipos_program_cab);
                this.varTipoProg = data;
                this.bloqueadoDoc = "none";
                this.bloqueadoVal = "none";
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


    eliminaProgDet(precDetalle: DTP_TIPOS_PROGRA_DET_DTO) {
        this.nDetProg = precDetalle;
        this.nDetProg.API_TRANSACCION = "ELIMINAR"; 
        this._service.EliminarProgramDet(this.nDetProg).subscribe((data: any) => {
            this.nDetProg = data;
            this.Notificacion.Success("");
            this.bandera = false;
            this.displayDialog = false;
            this.llenadoTiposProgram(this.dtp_tipos_program_cab);
            this.bloqueadoDoc = "none";
            this.bloqueadoVal = "none";
        }, (error: any) => { this.Notificacion.Warning(error); });
    }
    cancelar() {
        if (this.displayDialog) {
            this.displayDialog = false;
            this.varTipoProg = null;  // para desmarcar la selección
            this.bloqueadoDoc = "none";// para bloquear el tab de documentos
            this.bloqueadoVal = "none"; // para bloquear el tab de valores
        }
        if (this.displayDialog2) {
            this.displayDialog2 = false;
            this.varTipoDocto = null;// para desmarcar la selección
            this.bloqueadoVal = "none";  // para bloquear el tab de valores
        }
        if (this.displayDialog3) { this.displayDialog3 = false; }
        if (this.displayDialogTipoProg) { this.displayDialogTipoProg = false;}
    }
    saveDocDet() {
        let continuar: boolean = true;
        //let salida: boolean = false;
        console.log(this.nDetDoc.OBSERVACION);
        if (this.nDetDoc.ID_DOCUMENTO == "" || this.nDetDoc.ID_DOCUMENTO == null) { this.Notificacion.Warning("Debe seleccionar un tipo de documento"); continuar = false; }
        else if (this.nDetDoc.OBSERVACION == "" || this.nDetDoc.OBSERVACION == null) { this.Notificacion.Warning("Debe ingresar una observación "); continuar = false;}
        if (continuar) {
            //if (this.nDetProg.ESPECIAL == 'on') { this.nDetProg.ESPECIAL == 'S'; } else { this.nDetProg.ESPECIAL == 'N'; }
            if (this.newDocDet) {
                this.nDetDoc.API_TRANSACCION = "CREAR";

                this._service.AgregarDocDet(this.nDetDoc).subscribe((data: any) => {
                    this.nDetDoc = data;
                    this.DocDetCreado = true;
                    this.Notificacion.Success("");
                    this.bandera2 = false;
                    this.displayDialog2 = false;
                    this.llenadoTipoDoc(this.nDetProg);
                    this.varTipoDocto = data;
                    this.bloqueadoVal = "none";
                }, (error: any) => {
                    this.Notificacion.Warning(error);
                });

            } else {
                this._service.ModificarDocDet(this.nDetDoc).subscribe((data: any) => {
                    this.nDetDoc = data;
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
            this.bloqueadoVal = "none";
        }, (error: any) => { this.Notificacion.Warning(error); });
    }
    SalvaValoresDet() {
        let continuar = true;
        if (this.nDetVal.ID_COLUMNA == null) {
            this.Notificacion.Warning("Debe seleccionar Una columna");
            continuar = false;
        }
        if (this.mostrarListaColumna) {
            if (this.ValoresSelec == null) {
                this.Notificacion.Warning("Debe seleccionar algún valor");
                continuar = false;
            }
            if (continuar) {
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
                }, (error: any) => { this.Notificacion.Warning(error); });
            }
        } else { // si es una columna sin lista de valores
            if (this.valorCadena == null && this.valorNumero == null) {
                this.Notificacion.Warning("Debe escribir algún valor");
                continuar = false;
            }
            if (continuar) {
                var nuevo: DTP_DETALLES_DET_DTO;
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
                nuevo.ID_COLUMNA = this.columna.ID_COLUMNA;
                nuevo.TIPO_COLUMNA = this.columna.TIPO_COLUMNA;
                if (nuevo.TIPO_COLUMNA == 'VARCHAR2') {
                    nuevo.VALOR_CADENA = this.valorCadena;
                }
                else {
                    nuevo.VALOR_NUMERO = Number(this.valorNumero);
                }
                // se salva el valor 
                this._service.SalvarValorDetalle(nuevo).subscribe((data: any) => {
                    this.Notificacion.Success("");
                    this.bandera3 = false;
                    this.displayDialog3 = false;
                    this.llenadoValores(this.nDetDoc);
                }, (error: any) => { this.Notificacion.Warning(error); });
            }
        }

    }
    eliminarValor(precDto: DTP_DETALLES_DET_DTO) {
        precDto.API_TRANSACCION = "BORRAR";
        this._service.EliminarValDet(precDto).subscribe((data: any) => {
            this.Notificacion.Success("");
            this.llenadoValores(this.nDetDoc);
        }, (error: any) => { this.Notificacion.Warning(error); });
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
    llenadoTiposProgram(dtp_tipos_program_cab: DTP_TIPOS_PROGRA_CAB_DTO ) {
        var precDet = new DTP_TIPOS_PROGRA_DET_DTO;
        precDet.GESTION = dtp_tipos_program_cab.GESTION;
        precDet.INSTITUCION = dtp_tipos_program_cab.INSTITUCION;
        precDet.GA = dtp_tipos_program_cab.GA;
        precDet.NRO_DOCUMENTO = dtp_tipos_program_cab.NRO_DOCUMENTO;
        this._service.GetTiposProgram(precDet).subscribe(data => {
            this.dtp_tipos_program_det = data;
        }, (error: any) => { this.Notificacion.Warning(error); });

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
        }, (error: any) => { this.Notificacion.Warning(error); });
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
        this.dtp_documentos_det = null;
        this.dtp_detalles_det = null;
        this.llenadoTipoDoc(evento.data);
        this.bloqueadoDoc = "block";
        this.bloqueadoVal = "none";
    }
    clickFilaDoc(evento: any) {
        this.dtp_detalles_det = null;
        this.documentoSeleccionado = evento.data;
        this.llenadoValores(evento.data);
        this.nDetDoc = new DTP_DOCUMENTOS_DET_DTO();
        this.nDetDoc.GESTION = evento.data.GESTION;
        this.nDetDoc.INSTITUCION = evento.data.INSTITUCION;
        this.nDetDoc.GA = evento.data.GA;
        this.nDetDoc.NRO_DOCUMENTO = evento.data.NRO_DOCUMENTO;
        this.nDetDoc.SECUENCIA_DOC = evento.data.SECUENCIA_DOC;
        this.nDetDoc.INSTITUCION_PROG = evento.data.INSTITUCION_PROG;
        this.nDetDoc.GA_PROG = evento.data.GA_PROG;
        this.nDetDoc.TIPO_PROGRAMACION = evento.data.TIPO_PROGRAMACION;
        this.nDetDoc.ID_DOCUMENTO = evento.data.ID_DOCUMENTO;
        this.nDetDoc.OBSERVACION = evento.data.OBSERVACION;
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
    clickEditarDoc(evento: DTP_DOCUMENTOS_DET_DTO) {
        this.displayDialog2 = true;
        this.bandera2 = true;
        this.nDetDoc = new DTP_DOCUMENTOS_DET_DTO();
        this.nDetDoc.GESTION = evento.GESTION;
        this.nDetDoc.INSTITUCION = evento.INSTITUCION;
        this.nDetDoc.GA = evento.GA;
        this.nDetDoc.NRO_DOCUMENTO = evento.NRO_DOCUMENTO;
        this.nDetDoc.SECUENCIA_DOC = evento.SECUENCIA_DOC;
        this.nDetDoc.INSTITUCION_PROG = evento.INSTITUCION_PROG;
        this.nDetDoc.GA_PROG = evento.GA_PROG;
        this.nDetDoc.TIPO_PROGRAMACION = evento.TIPO_PROGRAMACION;
        this.nDetDoc.ID_DOCUMENTO = evento.ID_DOCUMENTO;
        this.nDetDoc.OBSERVACION = evento.OBSERVACION;
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

    habilitarBotonDetalle(boton: string, estado: string, tipo_operacion:string): boolean {
        switch (boton) {
            case "CONSULTAR":
                return true;
            case "CREAR":
                if (this.compLista.operacionPerfil == "REGISTRAR") { return true; }
            case "MODIFICAR":
                if (this.compLista.operacionPerfil == "REGISTRAR" && estado == "ELABORADO" && tipo_operacion != "B" ) { return true; }
                break;
            case "BORRAR":
                if (this.compLista.operacionPerfil == "REGISTRAR" && estado == "ELABORADO" && tipo_operacion != "B" ) { return true; }
                break;
            case "BORRAR_TIPO_PROG":
                if (this.compLista.operacionPerfil == "REGISTRAR" && estado == "ELABORADO" ) { return true; }
                break;
            default:
                break;
        }

        return false;
    }

    salvarListaTiposProgram() {
            let continuar = true;

            if (this.listaSelecTiposProg == null) {
                this.Notificacion.Warning("Debe seleccionar algún valor");
                continuar = false;
            }
            if (continuar) {
                //
                var listaSalvar: DTP_TIPOS_PROGRA_DET_DTO[] = [];
                var regNuevo: DTP_TIPOS_PROGRA_DET_DTO;

                for (var i = 0; i < this.listaSelecTiposProg.length; i++) {
                    regNuevo = new DTP_TIPOS_PROGRA_DET_DTO();
                    regNuevo.GESTION = this.dtp_tipos_program_cab.GESTION;
                    regNuevo.INSTITUCION = this.dtp_tipos_program_cab.INSTITUCION;
                    regNuevo.GA = this.dtp_tipos_program_cab.GA;
                    regNuevo.NRO_DOCUMENTO = this.dtp_tipos_program_cab.NRO_DOCUMENTO;
                    regNuevo.INSTITUCION_PROG = this.listaSelecTiposProg[i].INSTITUCION;
                    regNuevo.GA_PROG = this.listaSelecTiposProg[i].GA;
                    regNuevo.TIPO_PROGRAMACION = this.listaSelecTiposProg[i].TIPO_PROGRAMACION;
                    regNuevo.DESC_TIPO_PROGRAMACION = this.listaSelecTiposProg[i].DESC_TIPO_PROGRAMACION;
                    regNuevo.ESPECIAL = this.listaSelecTiposProg[i].ESPECIAL;
                    regNuevo.API_TRANSACCION = 'CREAR';
                    listaSalvar.push(regNuevo);
                }

                this._service.SalvarArregloDetalles(listaSalvar).subscribe((data: any) => {
                    this.Notificacion.Success("");
                    this.displayDialogTipoProg = false;
                    this.llenadoTiposProgram(this.dtp_tipos_program_cab);
                }, (error: any) => { this.Notificacion.Warning(error); });
                this.listaSelecTiposProg = null;
            }
    }
    ImprimirReporte() {
        this.reporte.REPORTE = 'r_pag_dttpca';
        this.reporte.PARAMETROS = '<PA_GESTION>' + this.dtp_tipos_program_cab.GESTION + '</PA_GESTION><PA_INSTITUCION>' + this.dtp_tipos_program_cab.INSTITUCION + '</PA_INSTITUCION><PA_GA>' + this.dtp_tipos_program_cab.GA + '</PA_GA><PA_NRO_DOCUMENTO>' + this.dtp_tipos_program_cab.NRO_DOCUMENTO + '</PA_NRO_DOCUMENTO>';
        this.reporte.API_TRANSACCION = 'CREAR'
        this.mostrar = 'Doc-Reporte';
        this.reporte.API_ESTADO = 'REPORTE DE DOCUMENTO REGITRO DE TIPOS DE PROGRAMACION';
        // this.operacion = "crear";
    }
    Recargar(event: boolean) {
        if (event) {
            this.mostrar = "";
        }
    }   

}