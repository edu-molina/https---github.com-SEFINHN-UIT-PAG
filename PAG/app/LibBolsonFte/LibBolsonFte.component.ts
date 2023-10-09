import { Component, OnInit } from '@angular/core';

import { PRG_LIBRETAS_BOLSON_DTO } from '../Clases/PRG_LIBRETAS_BOLSON_DTO';
import { NotificacionesService } from '../Services/NotificacionesService';
import { COLA_PARAMETROS_REPORTES_DTO } from '../Clases/COLA_PARAMETROS_REPORTES_DTO';
import { LibBolsonFteService } from './LibBolsonFte.service';

@Component({
    templateUrl: './LibBolsonFte/LibBolsonFte',
    selector: 'cons-LibBolsonFte'
})
export class LibBolsonFteComponent implements OnInit{
    prg_libretas_bolson: PRG_LIBRETAS_BOLSON_DTO[];
    mostrar: string = "";
    reporte: COLA_PARAMETROS_REPORTES_DTO = new COLA_PARAMETROS_REPORTES_DTO();
    constructor(private _service: LibBolsonFteService, private Notificacion: NotificacionesService) {
    }

    ngOnInit(){
        this._service.GetAll().subscribe(data => {
            this.prg_libretas_bolson = data;
        }, (error: any) => { this.Notificacion.Warning(error); });
    }
    ImprimirReporte() {
        this.reporte.REPORTE = 'r_pag_libo';
        this.reporte.PARAMETROS = '<PA_GESTION>' + this.prg_libretas_bolson[0].GESTION + '</PA_GESTION><PA_INSTITUCION>' + this.prg_libretas_bolson[0].INSTITUCION + '</PA_INSTITUCION><PA_GA>' + this.prg_libretas_bolson[0].GA + '</PA_GA>';
        this.reporte.API_TRANSACCION = 'CREAR'
        this.mostrar = 'Doc-Reporte';
        this.reporte.API_ESTADO = 'REPORTE DE CONSOLIDADO DE LIBRETAS BOLSON';
        // this.operacion = "crear";
    } 
    Recargar(event: boolean) {
        if (event) {
            this.mostrar = "";
        }
    } 
}