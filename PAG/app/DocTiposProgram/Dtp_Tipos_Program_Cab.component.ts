import { Component, OnInit } from '@angular/core';
import { NotificacionesService } from '../Services/NotificacionesService';
import { DialogService } from '../Services/DialogService';
import { Router } from '@angular/router';
import { Http } from '@angular/http';

import { Dtp_Tipos_Program_CabService  } from './Dtp_Tipos_Program_Cab.Service';
import { DTP_TIPOS_PROGRA_CAB_DTO } from '../Clases/DTP_TIPOS_PROGRA_CAB_DTO';

declare var Tabla: any;

@Component({
    selector: 'lista-DTP_TIPOS_PROGRAM_CAB',
    templateUrl: './DocTiposProgram/DocTiposProgram'
})
export class Dtp_Tipos_Program_CabComponent  implements OnInit {

    dtp_tipos_program_cab: DTP_TIPOS_PROGRA_CAB_DTO[];
    registro: DTP_TIPOS_PROGRA_CAB_DTO;
    selected: boolean;
    mostrar: string; 
    operacion: string;
    operacionPerfil: string;

    //reportes
    NoRecibo: number;

    acc: string;
    constructor(private _service: Dtp_Tipos_Program_CabService,
                private Notificacion: NotificacionesService,
                private _DialogService: DialogService,
                private _router: Router,
        private _http: Http
               ) {
    }

    ngOnInit() {
        this.mostrar = 'listado';
        this.obtenerOperacionPerfil();
        this._service.GetAll().subscribe(data => {
            this.dtp_tipos_program_cab = data;
        }), (error: any) => { this.Notificacion.Warning(error); };

    }
    extraerFecha(dato: string): string{
        if (dato){
            let miDato = dato.substring(dato.indexOf('(', 0) + 1, dato.length - 2);
            return miDato;
        }
        else return null;
    }

    onAgregar() {
        this.selected = true;
        //this._service.Agregar();
    }

    onModificarDTP_TIPOS_PROGRAM_CAB(pDtpTiPrgCab: DTP_TIPOS_PROGRA_CAB_DTO) {
        this.selected = true;// es solo por colocar algo, aca se llama a la otra pantalla        
    }
    consultarDocumento(pDtpTiPrgCab: DTP_TIPOS_PROGRA_CAB_DTO) {
        this.registro = pDtpTiPrgCab;
        this.mostrar = 'Doc-Consultar';
        this.operacion = "consultar";
        return this._http.get('DocTiposProgram/DocTiposProgramConsulta').toPromise()
            .then(data => { return data; }, (error: any) => { this.Notificacion.Warning(error); });
    }
    modificarDocumento(pDtpTiPrgCab: DTP_TIPOS_PROGRA_CAB_DTO) {
       // console.log(pDtpTiPrgCab);     
        this.mostrar = 'Doc-Crear';
        this.registro = pDtpTiPrgCab;
        this.operacion = "modificar";

    }
    detalleDocumento(pDtpTiPrgCab: DTP_TIPOS_PROGRA_CAB_DTO , Opcion:string) {
        this.registro = pDtpTiPrgCab;
        this.mostrar = 'Doc-Detalle';
        this.acc = Opcion;
        this.operacion = "aprobar";
        
    }
    crearDocumento(idTipoOperacion:string) {
        console.log("Creando documento");
        console.log(this.registro);
        this._service.GetDocumento().subscribe(data => {
            this.registro = data;
            this.mostrar = 'Doc-Crear';
            this.operacion = "crear";
        }, (error: any) => { this.Notificacion.Warning(error); });
    }


    onNotificar(message: boolean): void {
        this.ngOnInit();
        this.selected = message;
    }
    obtenerOperacionPerfil() {
        this._service.operacionEntrada().subscribe(data => {
            this.operacionPerfil = data;
        }, (error: any) => { this.Notificacion.Warning(error); });
    }
    habilitarBoton(boton: string, estado: string): boolean {
        switch (boton) {
            case "CONSULTAR":
                return true;            
            case "CREAR":
                if (this.operacionPerfil == "REGISTRAR") { return true; }
            case "MODIFICAR":
                if (this.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
                break;
            case "VERIFICAR":
                if (this.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
                break;
            case "DESVERIFICAR":
                if (this.operacionPerfil == "REGISTRAR" && estado == "VERIFICADO") { return true; }
                break;
            case "ELIMINAR":
                if (this.operacionPerfil == "REGISTRAR" && estado == "ELABORADO") { return true; }
                break;
            case "APROBAR":
                if (this.operacionPerfil == "APROBAR" && estado == "VERIFICADO") { return true; }
                break;
            default:
                break;
        }

        return false;
    }
    
}