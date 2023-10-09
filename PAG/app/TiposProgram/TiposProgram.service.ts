import { Injectable, enableProdMode } from '@angular/core';
import { Http, URLSearchParams, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { SelectItem } from 'primeng/primeng';

import { DTP_TIPOS_PROGRA_CAB_DTO } from '../Clases/DTP_TIPOS_PROGRA_CAB_DTO';
import { TPR_TIPOS_PROGRAMACION_DTO } from '../Clases/TPR_TIPOS_PROGRAMACION_DTO';
import { TPR_DOCUMENTOS_DTO } from '../Clases/TPR_DOCUMENTOS_DTO';
import { TPR_DETALLES_DTO } from '../Clases/TPR_DETALLES_DTO';

//enableProdMode();
@Injectable()
export class TiposProgramService {
    constructor(private _http: Http) {
    }
    selected: boolean;

    GetAll() {
        return this._http.get('TiposProgram/TiposProgramList').map(
            (response) => <TPR_TIPOS_PROGRAMACION_DTO[]>response.json()).catch(this.handleError);
    }
    GetDocumento() {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });

        return this._http.get('TiposProgram/DocTiposProgramCrearCargar', options).map(
            (response) => <DTP_TIPOS_PROGRA_CAB_DTO>response.json()).catch(this.handleError);
    }


    GetTiposProgram() {
        return this._http.get('TiposProgram/TiposProgramList').toPromise()
            .then(res => {
                var valor = res.json();
                return <SelectItem[]>valor;
            })
            .then(data => { return data; }).catch(this.handleError);
    }

    GetTiposDoc(precDet: TPR_DOCUMENTOS_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('TiposProgram/TprDocumentosConsulta', {
            idInstitucion: precDet.INSTITUCION, idGa: precDet.GA, idTipoProgramacion: precDet.TIPO_PROGRAMACION
        }, options)
            .map(
            (response) => <TPR_DOCUMENTOS_DTO[]>response.json()
            ).catch(this.handleError);
    }
    GetValores(precDet: TPR_DETALLES_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('TiposProgram/TprDetallesConsulta', {
            idGestion: precDet.GESTION, idInstitucion: precDet.INSTITUCION, idGa: precDet.GA, idTipoProgramacion: precDet.TIPO_PROGRAMACION,
            idSecDocumento: precDet.SECUENCIA_DOC }, options).map(
            (response) => <TPR_DETALLES_DTO[]>response.json()
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

} //FIN TiposProgramService