import { Component, OnInit } from '@angular/core';
import { NotificacionesService } from '../Services/NotificacionesService';
import { DialogService } from '../Services/DialogService';
import { Router } from '@angular/router';
import { Http } from '@angular/http';

import { DocLibBolsonFteService } from './DocLibBolsonFte.service';

import { DLB_LIB_BOLSON_CAB_DTO } from '../Clases/DLB_LIB_BOLSON_CAB_DTO';

@Component({
    selector: 'lista-DLB_LIB_BOLSON_CAB_DTO',
    templateUrl: './DocLibBolsonFte/DocLibBolsonFte'
})
export class DocLibBolsonFteComponent implements OnInit {

    mostrar: string;
    operacion: string;
    mensaje: boolean;
    registro: DLB_LIB_BOLSON_CAB_DTO;
    operacionPerfil: string;
    SalidaError: string;

    dlb_lib_bolson_cab: DLB_LIB_BOLSON_CAB_DTO[];

    constructor(private _service: DocLibBolsonFteService,
                private Notificacion: NotificacionesService,
                private _DialogService: DialogService,
                private _router: Router,
                private _http: Http ) {
    }

    ngOnInit() {
        this.mostrar = 'listado';
        this.operacion = 'ninguna';
        this.obtenerOperacionPerfil();
        this._service.GetAll().subscribe(data => {
            this.dlb_lib_bolson_cab = <DLB_LIB_BOLSON_CAB_DTO[]>data;
            this.registro = data[0];
        }, (error: any) => {
            this.Notificacion.Warning(error);
        }
        );
    }

    aprobarDocumento(pDlbLibBolCab: DLB_LIB_BOLSON_CAB_DTO) {
        return this._service.GetAprobar().then(value => {
            this.registro = pDlbLibBolCab;
            this.mostrar = 'Doc-Consultar';
            this.operacion = "aprobar";
        }, (error: any) => {
            this.SalidaError = error;
            this.Notificacion.Warning(error);
        } );
    }

    consultarDocumento(pDlbLibBolCab: DLB_LIB_BOLSON_CAB_DTO) {
        return this._service.GetConsulta().then(value => {
            this.registro = pDlbLibBolCab;
            this.mostrar = "Doc-Consultar";
            this.operacion = "consultar";
          //  alert(this.mostrar);
        }, (error: any) => {
            this.SalidaError = error;
            this.Notificacion.Warning(error);
            });
        
    }
    crearDocumento() {
        this._service.GetDocumento().subscribe(data => {
            this.registro = data;
            this.mostrar = "Doc-Crear";
            this.operacion = "crear";
        }, (error: any) => {
            this.SalidaError = error;
            this.Notificacion.Wait(error);
        }
        );
    }

    desverificarDocumento(pDlbLibBolCab: DLB_LIB_BOLSON_CAB_DTO) {
        return this._service.GetDesverificar().then(value => {
            this.registro = pDlbLibBolCab;
            this.mostrar = "Doc-Consultar";
            this.operacion = "desverificar";
       //     alert(this.mostrar);
        }, (error: any) => {
            this.SalidaError = error;
            this.Notificacion.Warning(error);
        });
    }

    eliminarDocumento(pDlbLibBolCab: DLB_LIB_BOLSON_CAB_DTO) {
        return this._service.GetEliminar().then(value => {
            this.registro = pDlbLibBolCab;
            this.mostrar = "Doc-Consultar";
            this.operacion = "eliminar";
        }, (error: any) => {
            this.SalidaError = error;
            this.Notificacion.Warning(error);
        });
    }

    extraerFecha(dato: string): string {
        if (dato) {
            let miDato = dato.substring(dato.indexOf('(', 0) + 1, dato.length - 2);
            return miDato;
        }
        else return null;
    }

    //habilitarBoton(boton: string, estado: string): boolean {
    //    switch (boton) {
    //        case "CONSULTAR":
    //            return true;
    //        case "CREAR":
    //            if (this.operacionPerfil == "REGISTRAR") { return true; }
    //        case "MODIFICAR":
    //            if (this.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
    //            break;
    //        case "VERIFICAR":
    //            if (this.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
    //            break;
    //        case "DESVERIFICAR":
    //            if (this.operacionPerfil == "REGISTRAR" && estado == "VERIFICADO") { return true; }
    //            break;
    //        case "ELIMINAR":
    //            if (this.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
    //            break;
    //        case "APROBAR":
    //            if (this.operacionPerfil == "APROBAR" && estado == "VERIFICADO") { return true; }
    //            break;
    //        default:
    //            break;
    //    }
    //    return false;
    //}
    modificarDocumento(pDlbLibBolCab: DLB_LIB_BOLSON_CAB_DTO) {
        this._service.GetModificarCrear().then(value => {
            this.registro = pDlbLibBolCab;
            this.mostrar = "Doc-Crear";
            this.operacion = "modificar";
        }, (error: any) => {
            this.SalidaError = error;
            this.Notificacion.Warning(error);
        });
    }

    obtenerOperacionPerfil() {
        this._service.operacionEntrada().subscribe(data => {
            this.operacionPerfil = data;
        }, (error: any) => {
            this.SalidaError = error;
            this.Notificacion.Warning(error);
        });
    }

    onNotificar(message: boolean): void {
        this.ngOnInit();
        this.mensaje = message;
    }

    verificarDocumento(pDlbLibBolCab: DLB_LIB_BOLSON_CAB_DTO) {
        return this._service.GetVerificar().then(value => {
            this.registro = pDlbLibBolCab;
            this.mostrar = "Doc-Consultar";
            this.operacion = "verificar";
        }, (error: any) => {
            this.SalidaError = error;
            this.Notificacion.Warning(error);
        });
    }
    
}
