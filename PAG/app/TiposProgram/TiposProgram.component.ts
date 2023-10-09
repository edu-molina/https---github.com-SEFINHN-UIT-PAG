import { Component, OnInit } from '@angular/core';
import { NotificacionesService } from '../Services/NotificacionesService';
import { DialogService } from '../Services/DialogService';
import { Router } from '@angular/router';
import { Http } from '@angular/http';

import { TiposProgramService } from './TiposProgram.service';
import { Dtp_Tipos_Program_CabService } from '../DocTiposProgram/Dtp_Tipos_Program_Cab.Service';

import { TPR_TIPOS_PROGRAMACION_DTO } from '../Clases/TPR_TIPOS_PROGRAMACION_DTO';
import { COLA_PARAMETROS_REPORTES_DTO } from '../Clases/COLA_PARAMETROS_REPORTES_DTO';
import { TPR_DOCUMENTOS_DTO } from '../Clases/TPR_DOCUMENTOS_DTO';
import { TPR_DETALLES_DTO } from '../Clases/TPR_DETALLES_DTO';
import { DTP_TIPOS_PROGRA_CAB_DTO } from '../Clases/DTP_TIPOS_PROGRA_CAB_DTO';

declare var Tabla: any;

@Component({
    templateUrl: './TiposProgram/TiposProgram',
    selector: 'cons-TiposProgram'
})
export class TiposProgramComponent implements OnInit {

    tpr_tipos_program: TPR_TIPOS_PROGRAMACION_DTO[];
    dtp_tipos_program_cab: DTP_TIPOS_PROGRA_CAB_DTO
    tpr_documentos: TPR_DOCUMENTOS_DTO[];
    tpr_detalles: TPR_DETALLES_DTO[];
    mostrar: string = "";
    reporte: COLA_PARAMETROS_REPORTES_DTO = new COLA_PARAMETROS_REPORTES_DTO();

    constructor(private _service: TiposProgramService,
        private _service2: Dtp_Tipos_Program_CabService,
        private Notificacion: NotificacionesService,
        private _DialogService: DialogService,
        private _router: Router,
        private _http: Http) {
    }

    ngOnInit() {
        this._service.GetAll().subscribe(data => {
            this.tpr_tipos_program = data;
            this.llenadoTipoDoc(this.tpr_tipos_program[0]);
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
        
    }
    llenadoTipoDoc(tpr_tipos_program: TPR_TIPOS_PROGRAMACION_DTO) {
        var precDet = new TPR_DOCUMENTOS_DTO;
        precDet.INSTITUCION = tpr_tipos_program.INSTITUCION;
        precDet.GA = tpr_tipos_program.GA;
        precDet.TIPO_PROGRAMACION = tpr_tipos_program.TIPO_PROGRAMACION;
        this._service.GetTiposDoc(precDet).subscribe(data => {
            this.tpr_documentos = data;
            this.llenadoValores(this.tpr_documentos[0]);
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }
    llenadoValores(tpr_documentos: TPR_DOCUMENTOS_DTO) {
        var precDet = new TPR_DETALLES_DTO;
        precDet.INSTITUCION = tpr_documentos.INSTITUCION;
        precDet.GA = tpr_documentos.GA;
        precDet.TIPO_PROGRAMACION = tpr_documentos.TIPO_PROGRAMACION;
        precDet.SECUENCIA_DOC = tpr_documentos.SECUENCIA_DOC;
        this._service.GetValores(precDet).subscribe(data => {
            this.tpr_detalles = data;
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }
    clickFila(evento: any) {
        this.llenadoTipoDoc(evento.data);
    }
    clickFilaDoc(evento: any) {
        this.llenadoValores(evento.data);
    }
    ImprimirReporte() {
        this._service.GetDocumento().subscribe(data => {
            this.dtp_tipos_program_cab = data;
            this.reporte.REPORTE = 'r_pag_tprtp';
            this.reporte.PARAMETROS = '<PA_GESTION>' + this.dtp_tipos_program_cab.GESTION + '</PA_GESTION><PA_INSTITUCION>' + this.dtp_tipos_program_cab.INSTITUCION + '</PA_INSTITUCION><PA_GA>' + this.dtp_tipos_program_cab.GA + '</PA_GA>';
            this.reporte.API_TRANSACCION = 'CREAR'
            this.reporte.API_ESTADO = 'REPORTE DE CONSOLIDADO DE TIPOS DE PROGRAMACION';

            this.mostrar = 'Doc-Reporte';
        }, (error: any) => { this.Notificacion.Warning(error); });
        //this.reporte.REPORTE = 'r_pag_tprtp';
        //this.reporte.PARAMETROS = '<PA_GESTION>' + this.dtp_tipos_program_cab.GESTION + '</PA_GESTION><PA_INSTITUCION>' + this.dtp_tipos_program_cab.INSTITUCION + '</PA_INSTITUCION><PA_GA>' + this.dtp_tipos_program_cab.GA + '</PA_GA>';
        //this.reporte.API_TRANSACCION = 'CREAR'
        //this.mostrar = 'Doc-Reporte';
        //this.reporte.API_ESTADO = 'REPORTE DE CONSOLIDADO DE TIPOS DE PROGRAMACION';
        //this.operacion = "crear";
    } 
    Recargar(event: boolean) {
        if (event) {
            this.mostrar = "";
        }
    } 
}


