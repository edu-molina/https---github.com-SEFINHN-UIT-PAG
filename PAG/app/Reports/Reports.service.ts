import { Injectable, enableProdMode } from '@angular/core';
import { Http, URLSearchParams, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class ReportsService {
    constructor(private _http: Http) {
    }
    traerReporte(precDto: any) {
        let headers = new Headers({
            'Content-Type': 'application/pdf',
            'filename': 'test'
        });
        let options = new RequestOptions({ headers: headers });

        return this._http.post('Reports/DisplayReporte', { param: precDto }).map(
            (response) => {
                var array = response.text();
                var jsonPDF = JSON.parse(response.text());

                headers.append('filename', 'MyCustomHeaderValue');
                return jsonPDF;

            }
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