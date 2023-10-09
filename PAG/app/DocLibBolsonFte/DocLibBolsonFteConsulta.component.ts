import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core'
import { NotificacionesService } from '../Services/NotificacionesService';
import { DialogService } from '../Services/DialogService';
import { Router } from '@angular/router';
import { Http } from '@angular/http';

import { DocLibBolsonFteService } from './DocLibBolsonFte.service';

import { DocLibBolsonFteComponent } from './DocLibBolsonFte.component';
import { COLA_PARAMETROS_REPORTES_DTO } from '../Clases/COLA_PARAMETROS_REPORTES_DTO';

import { DLB_LIB_BOLSON_CAB_DTO } from '../Clases/DLB_LIB_BOLSON_CAB_DTO';
import { DLB_LIB_BOLSON_DET_DTO } from '../Clases/DLB_LIB_BOLSON_DET_DTO';

@Component({
    selector: 'consulta-DocLibBolsonFte',
    templateUrl: './DocLibBolsonFte/DocLibBolsonFteConsulta'
})
export class DocLibBolsonFteConsultaComponent implements OnInit {

    @Input() dlb_lib_bolson_cab: DLB_LIB_BOLSON_CAB_DTO;
    @Input() tipo_operacion: String;
    @Output() notificar: EventEmitter<boolean> = new EventEmitter<boolean>();

    mostrar: string = "";
    operacion: string;

    operacionPerfil: string;
    refrescarLista: boolean = false;
    reporte: COLA_PARAMETROS_REPORTES_DTO = new COLA_PARAMETROS_REPORTES_DTO();
    habilitaReporte: boolean = false;

    dlb_lib_bolson_det: DLB_LIB_BOLSON_DET_DTO[];

    constructor(private _serviceCon: DocLibBolsonFteService,
                private Notificacion: NotificacionesService,
                private _DialogService: DialogService,
                private compLista: DocLibBolsonFteComponent,
                private _router: Router,
                private _http: Http) {
    }

    ngOnInit() {
      //  alert(this.mostrar);
        this.obtenerOperacionPerfil();
        this.llenadoDocLibBolson();
        this.refrescarLista = false;
        if (this.dlb_lib_bolson_cab.NRO_DOCUMENTO > 0) { this.habilitaReporte = true; }
    }
    extraerFecha(dato: string): string {
        if (dato) {
            let miDato = dato.substring(dato.indexOf('(', 0) + 1, dato.length - 2);
            return miDato;
        }
        else return null;
    }

    aprobarDocumento(precCab: DLB_LIB_BOLSON_CAB_DTO) {
        this._serviceCon.updAprobarDocumento(precCab).subscribe(data => {
                this.dlb_lib_bolson_cab = data;
                this.Notificacion.Success("");
                this.refrescarLista = true;
                this.llenadoDocLibBolson();
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }

    eliminarDocumento(precCab: DLB_LIB_BOLSON_CAB_DTO) {
        this._serviceCon.updEliminarDocumento(precCab).subscribe(data => {
            this.dlb_lib_bolson_cab = data;
            this.Notificacion.Success("");
            this.refrescarLista = true;
            this.Volver();
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }

    verificarDocumento(precCab: DLB_LIB_BOLSON_CAB_DTO) {
        this._serviceCon.updVerificarDocumento(precCab).subscribe(data => {
            this.dlb_lib_bolson_cab = data;
            this.Notificacion.Success("");
            this.refrescarLista = true;
            this.llenadoDocLibBolson();
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }

    desverificarDocumento(precCab: DLB_LIB_BOLSON_CAB_DTO) {
        this._serviceCon.updDesverificarDocumento(precCab).subscribe(data => {
            this.dlb_lib_bolson_cab = data;
            this.Notificacion.Success("");
            this.refrescarLista = true;
            this.llenadoDocLibBolson();
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }

    habilitarBoton(boton: string, estado: string): boolean {
        switch (boton) {
            case "CONSULTAR":
                return true;
            case "CREAR":
                if (this.operacionPerfil == "REGISTRAR") { return true; }
            case "VERIFICAR":
                if (this.tipo_operacion == "verificar" && this.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
                break;
            case "DESVERIFICAR":
                if (this.tipo_operacion == "desverificar" && this.operacionPerfil == "REGISTRAR" && estado == "VERIFICADO") { return true; }
                break;
            case "ELIMINAR":
                if (this.tipo_operacion == "eliminar" && this.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
                break;
            case "APROBAR":
                if (this.tipo_operacion == "aprobar" && this.operacionPerfil == "APROBAR" && estado == "VERIFICADO") { return true; }
                break;
            default:
                break;
        }
        return false;
    }

    llenadoDocLibBolson() {
        this.llenadoLibBolsonDetalle();    
    }
    Volver() {
        this.compLista.mostrar = 'listado';
        this.notificar.emit(false);
    }
    llenadoLibBolsonDetalle() {
        var precDet = new DLB_LIB_BOLSON_CAB_DTO;
        precDet.GESTION = this.dlb_lib_bolson_cab.GESTION;
        precDet.INSTITUCION = this.dlb_lib_bolson_cab.INSTITUCION;
        precDet.GA = this.dlb_lib_bolson_cab.GA;
        precDet.NRO_DOCUMENTO = this.dlb_lib_bolson_cab.NRO_DOCUMENTO;
        this._serviceCon.GetDetalle(precDet).subscribe(data => {
            this.dlb_lib_bolson_det = data;
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
    }
    obtenerOperacionPerfil() {
        this._serviceCon.operacionEntrada().subscribe(data => {
            this.operacionPerfil = data;
        }, (error: any) => {
            this.Notificacion.Warning(error);
        });
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
