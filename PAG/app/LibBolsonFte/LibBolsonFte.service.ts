import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { PRG_LIBRETAS_BOLSON_DTO } from '../Clases/PRG_LIBRETAS_BOLSON_DTO';

@Injectable()
export class LibBolsonFteService {

    constructor(private _http: Http) {
    }

    GetAll() {
        return this._http.get('LibBolsonFte/LibBolsonFteList').map(
            (response) => <PRG_LIBRETAS_BOLSON_DTO[]>response.json()).catch(this.handleError);
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