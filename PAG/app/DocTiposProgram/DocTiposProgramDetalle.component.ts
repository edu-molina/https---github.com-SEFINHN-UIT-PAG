import { Component, OnInit, Input, EventEmitter ,Output  } from '@angular/core'
import { NgForm } from '@angular/forms'
import { Http } from '@angular/http'

import { Dtp_Tipos_Program_CabService  } from './Dtp_Tipos_Program_Cab.Service'
import { Dtp_Tipos_Program_CabComponent } from './Dtp_Tipos_Program_Cab.component'
import { NotificacionesService } from '../Services/NotificacionesService';

import { DTP_TIPOS_PROGRA_CAB_DTO } from '../Clases/DTP_TIPOS_PROGRA_CAB_DTO';
import { DTP_TIPOS_PROGRA_DET_DTO } from '../Clases/DTP_TIPOS_PROGRA_DET_DTO';
import { DTP_DOCUMENTOS_DET_DTO } from '../Clases/DTP_DOCUMENTOS_DET_DTO';
import { DTP_DETALLES_DET_DTO } from '../Clases/DTP_DETALLES_DET_DTO';
declare var Tabla: any;

@Component({
    selector: 'doc-DocTiposProgramDetalle',
    templateUrl: './DocTiposProgram/DocTiposProgramDetalle'
})

export class DocTiposProgramDetalleComponent implements OnInit {

    @Input() dtp_tipos_program_cab: DTP_TIPOS_PROGRA_CAB_DTO;
    @Input() tipo_operacion: String;
    @Output() notificar: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Input() Opc: String;

//regTipoProgram: DTP_TIPOS_PROGRA_DET_DTO;
    dtp_tipos_program_det: DTP_TIPOS_PROGRA_DET_DTO[];
    dtp_documentos_det: DTP_DOCUMENTOS_DET_DTO[];
    dtp_detalles_det: DTP_DETALLES_DET_DTO[];
    regTipoProgram: any; 
    Ejec: boolean = false;

    refrescarLista: boolean = true;

     //variables para bloqueo de objetos 
    bloqueadoDoc: string = "none";
    bloqueadoVal: string = "none";
    


    constructor(private _service: Dtp_Tipos_Program_CabService ,
        private compLista: Dtp_Tipos_Program_CabComponent,
        private Notificacion: NotificacionesService,
                private _http: Http) {
    }

    ngOnInit() {
        this.llenadoTiposProgram();
    //    this.regTipoProgram = this.dtp_tipos_program_det[0];
    //    console.log(this.dtp_tipos_program_det);
    }
    Volver() {
        //if (this.refrescarLista) {
        //    this._service.GetAll().subscribe(data => {
        //        this.compLista.mostrar = 'listado';
        //        this.compLista.dtp_tipos_program_cab = data;
        //        this.compLista.registro = data[0];
        //        this.notificar.emit(false);
        //    });;

        //} else {
        //    this.compLista.mostrar = 'listado';
        //    this.notificar.emit(false);
        //}
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
        console.log("Carga Tipo Program");
        console.log(filaSeleccionada);
        this.regTipoProgram = filaSeleccionada;
    }
    VerifCab() {
        this.dtp_tipos_program_cab.API_TRANSACCION = "VERIFICAR";
        this._service.VerificarCab(this.dtp_tipos_program_cab).subscribe((data: any) => {
            this.dtp_tipos_program_cab = data;
            this.Notificacion.Success("");
            this.Ejec = true;
            this.refrescarLista = true;
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }
    DesVerCab() {
        this.dtp_tipos_program_cab.API_TRANSACCION = "DESVERIFICAR";
        this._service.DesverificarCab (this.dtp_tipos_program_cab).subscribe((data: any) => {
            this.dtp_tipos_program_cab = data;
            this.Notificacion.Success("");
            this.Ejec = true;
            this.refrescarLista = true;
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }
    AprobCab() {
        this.dtp_tipos_program_cab.API_TRANSACCION = "APROBAR";
        this._service.AprobarCab(this.dtp_tipos_program_cab).subscribe((data: any) => {
            this.dtp_tipos_program_cab = data;
            this.Notificacion.Success("");
            this.Ejec = true;
            this.refrescarLista = true;
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }
    ElimCab() {
        this.dtp_tipos_program_cab.API_TRANSACCION = "ELIMINAR";
        this._service.EliminarCab(this.dtp_tipos_program_cab).subscribe((data: any) => {
            this.dtp_tipos_program_cab = data;
            this.Notificacion.Success("");
            this.Ejec = true;
            this.refrescarLista = true;
            this.Volver();
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }
    llenadoTiposProgram(){
        var precDet = new DTP_TIPOS_PROGRA_DET_DTO;
        //.log(this.dtp_tipos_program_det[0].GESTION);
        precDet.GESTION = this.dtp_tipos_program_cab.GESTION;
        precDet.INSTITUCION = this.dtp_tipos_program_cab.INSTITUCION;
        precDet.GA = this.dtp_tipos_program_cab.GA;
        precDet.NRO_DOCUMENTO = this.dtp_tipos_program_cab.NRO_DOCUMENTO;
        this._service.GetTiposProgram(precDet).subscribe(data => {
            this.dtp_tipos_program_det = data;
           // this.llenadoTipoDoc(this.dtp_tipos_program_det[0]);

        }, (error: any) => {
            this.Notificacion.Warning(error);
        });

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
            //this.llenadoValores(this.dtp_documentos_det[0]);
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
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
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }


    clickFila(evento: any) {
        this.llenadoTipoDoc(evento.data);
        this.bloqueadoDoc = "block";
        this.bloqueadoVal = "none";
    }
    clickFilaDoc(evento: any) {
        this.llenadoValores(evento.data);
        this.bloqueadoVal = "block";
    }

    
}