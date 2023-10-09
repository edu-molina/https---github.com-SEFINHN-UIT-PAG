import { Injectable, enableProdMode } from '@angular/core';
import { Http, URLSearchParams, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { SelectItem } from 'primeng/primeng';


import { DLB_LIB_BOLSON_CAB_DTO } from '../Clases/DLB_LIB_BOLSON_CAB_DTO';
import { DLB_LIB_BOLSON_DET_DTO } from '../Clases/DLB_LIB_BOLSON_DET_DTO';
import { PRG_LIBRETAS_BOLSON_DTO } from '../Clases/PRG_LIBRETAS_BOLSON_DTO';

//enableProdMode();
@Injectable()

export class DocLibBolsonFteService {
    constructor(private _http: Http) {
    }
    borrarDetalle( precDetalle: DLB_LIB_BOLSON_DET_DTO ) {

        let headers = new Headers({
            'Content-Type': 'application/json',
            'Cache-Control': 'no-cache',
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocLibBolsonFte/DocLibBolsonFteDetBorrar', precDetalle, options)
            .map(
            (response) => <DLB_LIB_BOLSON_DET_DTO>response.json()
            ).catch(this.handleError);
    }
    GetAll() {
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Cache-Control': 'no-cache',
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocLibBolsonFte/DocLibBolsonFteList', null , options).map(
            (response) => <DLB_LIB_BOLSON_CAB_DTO[]>response.json()
        ).catch(this.handleError);
    }

    GetConsolidado(precDet: DLB_LIB_BOLSON_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Cache-Control': 'no-cache',
        });
        let options = new RequestOptions({ headers: headers });

        return this._http.post('DocLibBolsonFte/LibBolsonFteList', precDet, options)
            .map(
            (response) => <PRG_LIBRETAS_BOLSON_DTO[]>response.json()
            ).catch(this.handleError);
    }

    GetAprobar() {
        return this._http.get('DocLibBolsonFte/DocLibBolsonFteConsulta').toPromise()
            .then(data => { return data; }).catch(this.handleError);
    }

    GetBancos() {
        return this._http.get('DocLibBolsonFte/cargarBancos').toPromise()
            .then(res => {
                var valor = res.json();
                return valor;
            })
            .then(data => { return data; }).catch(this.handleError);
    }

    GetConsulta() {
        return this._http.get('DocLibBolsonFte/DocLibBolsonFteConsulta').toPromise()
            .then(data => { return data; }).catch(this.handleError);;
        
    }
    GetDocumento() {
        return this._http.get('DocLibBolsonFte/DocLibBolsonFteCrearCargar').map(
            (response) => <DLB_LIB_BOLSON_CAB_DTO>response.json())
            .catch(this.handleError);
    }
    GetDesverificar() {
        return this._http.get('DocLibBolsonFte/DocLibBolsonFteConsulta').toPromise()
            .then(data => { return data; }).catch(this.handleError);;
    }
    GetDetalle(precDet: DLB_LIB_BOLSON_CAB_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Cache-Control': 'no-cache',
        });
        let options = new RequestOptions({ headers: headers });

        return this._http.post('DocLibBolsonFte/DocLibBolsonFteDetalle', {
            idGestion: precDet.GESTION, idInstitucion: precDet.INSTITUCION,
            idGa: precDet.GA, idNroDocumento: precDet.NRO_DOCUMENTO }, options)
            .map(
            (response) => <DLB_LIB_BOLSON_DET_DTO[]>response.json()
        ).catch(this.handleError);
    }
    GetDominios(Param: string) {
        let params = new URLSearchParams();
        params.set('idDominio', Param.toString());

        return this._http.get('DocLibBolsonFte/cargarDominio', { search: params }).toPromise()
            .then(res => {
                var valor = res.json();
                return valor;
            })
            .then(data => { return data; }).catch(this.handleError);
    }

    GetEliminar() {
        return this._http.get('DocLibBolsonFte/DocLibBolsonFteConsulta').toPromise()
            .then(data => { return data; }).catch(this.handleError);

    }
    GetFuentes() {
        return this._http.get('DocLibBolsonFte/cargarFuentes').toPromise()
            .then(res => {
                var valor = res.json();
                return valor;
            })
            .then(data => { return data; }).catch(this.handleError);
    }

    GetLibretas(idGestion: string, idBanco: string, idCuenta: string) {
        let params = new URLSearchParams();
        params.set('idGestion', idGestion.toString());
        params.set('idBanco', idBanco.toString());
        params.set('idCuenta', idCuenta.toString());

        //short idGestion, short idBanco, string idcuenta
        return this._http.get('DocLibBolsonFte/cargarLibretas', { search: params }).toPromise()
            .then(res => {
                var valor = res.json();
                return valor;
            })
            .then(data => { return data; }).catch(this.handleError);
    }

    GetLibrosBanco(idGestion: string, idBanco: string, idMoneda: string) {
        let params = new URLSearchParams();
        params.set('idGestion', idGestion.toString());
        params.set('idBanco', idBanco.toString());
        params.set('idMoneda', idMoneda);
        return this._http.get('DocLibBolsonFte/cargarLibrosBanco', { search: params }).toPromise()
            .then(res => {
                var valor = res.json();
                return valor;
            })
            .then(data => { return data; }).catch(this.handleError);
    }

    GetModificarCrear() {
        return this._http.get('DocLibBolsonFte/DocLibBolsonFteCrear').toPromise()
            .then(data => { return data; }).catch(this.handleError);
    }

    GetModificarModif() {
        return this._http.get('DocLibBolsonFte/DocLibBolsonFteModif').toPromise()
            .then(data => { return data; }).catch(this.handleError);
    }

    GetMonedas() {
        return this._http.get('DocLibBolsonFte/cargarMonedas').toPromise()
            .then(res => {
                var valor = res.json();
                return valor;
            })
            .then(data => { return data; }).catch(this.handleError);
    }
    GetVerificar() {
        return this._http.get('DocLibBolsonFte/DocLibBolsonFteConsulta').toPromise()
            .then(data => { return data; }).catch(this.handleError);
    }

    operacionEntrada() {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocLibBolsonFte/operacionEntrada', options).map(
            (response) => <string>response.json()).catch(this.handleError);
    }

    salvarCabecera(precCabecera: DLB_LIB_BOLSON_CAB_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocLibBolsonFte/DocLibBolsonFteCrearSalvar', precCabecera, options)
            .map(
            (response) => <DLB_LIB_BOLSON_CAB_DTO>response.json()
            ).catch(this.handleError).catch(this.handleError);
    }

    salvarDetalle(precDetalle: DLB_LIB_BOLSON_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocLibBolsonFte/DocLibBolsonFteDetCrearSalvar', precDetalle, options)
            .map(
            (response) => <DLB_LIB_BOLSON_DET_DTO>response.json()
            ).catch(this.handleError);
    }

    salvarDetalleModif(precDetalle: DLB_LIB_BOLSON_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocLibBolsonFte/DocLibBolsonFteDetModifSalvar', precDetalle, options)
            .map(
            (response) => <DLB_LIB_BOLSON_DET_DTO>response.json()
            ).catch(this.handleError);
    }

    SalvarArregloDetalles(precDto: DLB_LIB_BOLSON_DET_DTO[]) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocLibBolsonFte/LibBolsonFteSalvarArreglo', { precListDet: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }

    updAprobarDocumento(precCabecera: DLB_LIB_BOLSON_CAB_DTO) {

        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocLibBolsonFte/DocLibBolsonFteAprobar', precCabecera, options)
            .map(
            (response) => <DLB_LIB_BOLSON_CAB_DTO>response.json()
            ).catch(this.handleError);
    }
    updDesverificarDocumento(precCabecera: DLB_LIB_BOLSON_CAB_DTO) {

        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocLibBolsonFte/DocLibBolsonFteDesverificar', precCabecera, options)
            .map(
            (response) => <DLB_LIB_BOLSON_CAB_DTO>response.json()
            ).catch(this.handleError);
    }
    updEliminarDocumento(precCabecera: DLB_LIB_BOLSON_CAB_DTO) {

        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocLibBolsonFte/DocLibBolsonFteEliminar', precCabecera, options)
            .map(
            (response) => <DLB_LIB_BOLSON_CAB_DTO>response.json()
            ).catch(this.handleError);
    }

    updVerificarDocumento(precCabecera: DLB_LIB_BOLSON_CAB_DTO) {

        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocLibBolsonFte/DocLibBolsonFteVerificar', precCabecera, options)
            .map(
            (response) => <DLB_LIB_BOLSON_CAB_DTO>response.json()
            ).catch(this.handleError);
    }

    volverListaDocumentos() {
        return this._http.get('DocLibBolsonFte/DocLibBolsonFteList').map(
            (response) => <DLB_LIB_BOLSON_CAB_DTO[]>response.json()
        ).catch(this.handleError);
    }
    private handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.message || JSON.stringify(body);
            errMsg = `${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error("ESTE ES EL ERROR: " + errMsg);
        return Observable.throw(errMsg);
    }
}