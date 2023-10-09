import { Injectable} from '@angular/core';
import { Http, URLSearchParams, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { SelectItem } from 'primeng/primeng';


import { DTP_TIPOS_PROGRA_CAB_DTO } from '../Clases/DTP_TIPOS_PROGRA_CAB_DTO';
import { DTP_TIPOS_PROGRA_DET_DTO } from '../Clases/DTP_TIPOS_PROGRA_DET_DTO';
import { DTP_DOCUMENTOS_DET_DTO } from '../Clases/DTP_DOCUMENTOS_DET_DTO';
import { DTP_DETALLES_DET_DTO } from '../Clases/DTP_DETALLES_DET_DTO';
import { VM_PAG_LISTA_VALORES_DTO } from '../Clases/VM_PAG_LISTA_VALORES_DTO';
import { TPR_TIPOS_PROGRAMACION_DTO } from '../Clases/TPR_TIPOS_PROGRAMACION_DTO';


@Injectable()

export class Dtp_Tipos_Program_CabService {
    constructor(private _http: Http) {
    }
    selected: boolean;

    GetAll() {
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Cache-Control': 'no-cache',
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramList', options).map(
            response => {
              return <DTP_TIPOS_PROGRA_CAB_DTO[]>response.json();
            }).catch(this.handleError);
    }
    AgregarProgramCab(precDto : DTP_TIPOS_PROGRA_CAB_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return  this._http.post('DocTiposProgram/DocTiposProgramCrearSalvar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }

    AgregarProgramDet(precDto: DTP_TIPOS_PROGRA_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramDetCrearSalvar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }

    ModificarProgramDet(precDto: DTP_TIPOS_PROGRA_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramDetModifSalvar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }

    EliminarProgramDet(precDto: DTP_TIPOS_PROGRA_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramEliminar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }

    AgregarDocDet(precDto: DTP_DOCUMENTOS_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramDoctosCrearSalvar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }

    AgregarValDet(precDto: DTP_DETALLES_DET_DTO[]) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramDetallesCrearSalvar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }
    EliminarValDet(precDto: DTP_DETALLES_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramDetallesEliminar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }

    ModificarDocDet(precDto: DTP_DOCUMENTOS_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramDoctosModifSalvar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }

    EliminarDocDet(precDto: DTP_DOCUMENTOS_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramDoctosEliminar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }

    VerificarCab(precDto: DTP_TIPOS_PROGRA_CAB_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramVerificarSalvar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }

    DesverificarCab(precDto: DTP_TIPOS_PROGRA_CAB_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramDesverificarSalvar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }
    AprobarCab(precDto: DTP_TIPOS_PROGRA_CAB_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramAprobarSalvar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }
    EliminarCab(precDto: DTP_TIPOS_PROGRA_CAB_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramEliminarSalvar', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }
    cargarProgramDet(precDto: DTP_TIPOS_PROGRA_CAB_DTO) {
            let params = new URLSearchParams();
            params.set('idGestion', precDto.GESTION.toString());
            params.set('idGa', precDto.GA.toString());
            params.set('idInstitucion', precDto.INSTITUCION.toString());
            params.set('idNroDocumento', precDto.NRO_DOCUMENTO.toString());
            return this._http.get('DocTiposProgram/DocTiposProgramDetCrearCargar', { search: params }).toPromise()
                .then(res => {
                    var valor = res.json();
                    return valor;
                })
                .then(data => { return data; }).catch(this.handleError);
        
    }
    cargarProgramCab() {
        let params = new URLSearchParams();
        return this._http.get('DocTiposProgram/DocTiposProgramCrearCargar').toPromise()
            .then(res => {
                var valor = res.json();
                return valor;
            })
            .then(data => { return data; }).catch(this.handleError);

    }
    cargarValoresLista(precDto: DTP_DETALLES_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
      //  alert(precDto);
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/cargarValoresColumnas', { precDetalle: precDto }, options).map(
            (res) => <VM_PAG_LISTA_VALORES_DTO[]>res.json()
            ).catch(this.handleError);

    }
    GetDocumento() {

        return this._http.get('DocTiposProgram/DocTiposProgramCrearCargar').map(
            (response) => <DTP_TIPOS_PROGRA_CAB_DTO>response.json()).catch(this.handleError);
    }

    GetTiposProgram(precDet: DTP_TIPOS_PROGRA_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramDetConsultaCargar', { idGestion: precDet.GESTION, idInstitucion: precDet.INSTITUCION, idGa: precDet.GA, idNroDocumento: precDet.NRO_DOCUMENTO }, options)
            .map(
            (response) => <DTP_TIPOS_PROGRA_DET_DTO[]>response.json()
            ).catch(this.handleError);
    }
    GetTiposDoc(precDet: DTP_DOCUMENTOS_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramDoctosConsultaCargar', {
            idGestion: precDet.GESTION, idInstitucion: precDet.INSTITUCION, idGa: precDet.GA, idNroDocumento: precDet.NRO_DOCUMENTO,
            idInstitucionProg: precDet.INSTITUCION_PROG, idGaProg: precDet.GA_PROG, idTipoProgramacion: precDet.TIPO_PROGRAMACION
        }, options)
            .map(
            (response) => <DTP_DOCUMENTOS_DET_DTO[]>response.json()
            ).catch(this.handleError);
    }

    GetValores(precDet: DTP_DETALLES_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/DocTiposProgramDetallesConsulta', {
            idGestion: precDet.GESTION, idInstitucion: precDet.INSTITUCION, idGa: precDet.GA, idNroDocumento: precDet.NRO_DOCUMENTO,
            idInstitucionProg: precDet.INSTITUCION_PROG, idGaProg: precDet.GA_PROG, idTipoProgramacion: precDet.TIPO_PROGRAMACION, secdocumento: precDet.SECUENCIA_DOC
        }, options)
            .map(
            (response) => <DTP_DETALLES_DET_DTO[]>response.json()
            ).catch(this.handleError);
    }

    //Modificar(pDtpTiPrgCab: DTP_TIPOS_PROGRA_CAB_DTO) {
    //    let url = 'DocTiposProgram/DocTiposProgramEditar/${pDtpTiPrgCab.GESTION, pDtpTiPrgCab.INSTITUCION, pDtpTiPrgCab.GA, pDtpTiPrgCab.NRO_DOCUMENTO}';
    //    return this._http.get(url)
    //                .toPromise()
    //                .then(respuesta => respuesta.json())
    //                .catch(this.handleError)
    //  //var datos = this._http.get('DocTiposProgram/DocTiposProgramModificar/${GESTION, INSTITUCION,GA, NRO_DOCUMENTO}').map(
    //  //    (response) => <DTP_TIPOS_PROGRA_CAB_DTO[]>response.json());
    //  //return datos;
    //}
    //Eliminar(pDtpTiPrgCab: DTP_TIPOS_PROGRA_CAB_DTO) {
    //}
    GetDTP_TIPOS_PROGRAM_CAB() {
        return this._http.get('DocTiposProgram/Index').toPromise()
            .then(res => {
                var valor = res.json();
                return <SelectItem[]>valor;
            })
            .then(data => { return data; }).catch(this.handleError);
    }
    GetDominios(Param: string) {
        let params = new URLSearchParams();
        params.set('idDominio', Param.toString());

        return this._http.get('DocTiposProgram/cargarDominio', { search: params }).toPromise()
            .then(res => {
                var valor = res.json();
                return valor;
            })
            .then(data => { return data; }).catch(this.handleError);
    }
    GetColumnas(Especial: any = "", Param: any = "") {
        let params = new URLSearchParams();
        params.set('especial', Especial.toString());
        params.set('idDocumento', Param.toString());

        return this._http.get('DocTiposProgram/cargarColumnas', { search: params }).toPromise()
            .then(res => {
                var valor = res.json();
                return valor;
            })
            .then(data => { return data; }).catch(this.handleError);
    }
    operacionEntrada() {
        let headers = new Headers({
            'Content-Type': 'application/json',
            'Cache-Control': 'no-cache',
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/operacionEntrada', options).map(
            (response) => <string>response.json());
    }
    cargarValoresColumnaSeleccionada(idColumna: string) {

        return this._http.post('DocTiposProgram/cargarValorColumnaSeleccionada', { idColumna: idColumna.toString()}).toPromise()
            .then(res => {
                var valor = res.json();
                console.log("valor ");
                console.log(valor);
                return valor;
            })
            .then(data => {
                console.log("en data ");
                console.log(data);
                return data;

            }).catch(this.handleError);
    }

    GetDoctoLov() {
        let params = new URLSearchParams();
      

        return this._http.get('DocTiposProgram/cargarTiposDocumentos').toPromise()
            .then(res => {
                var valor = res.json();
                return valor;
            })
            .then(data => { return data; }).catch(this.handleError);
    }

    GetListaTiposProgramConsolidado(precDetalle: DTP_TIPOS_PROGRA_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/TiposProgramList', { precDet: precDetalle }, options)
            .map(
            (response) => <TPR_TIPOS_PROGRAMACION_DTO[]>response.json()
            ).catch(this.handleError);
    }

    SalvarArregloDetalles(precDto: DTP_TIPOS_PROGRA_DET_DTO[]) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/TiposProgramSalvarArreglo', { precListDet: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
    }
    SalvarValorDetalle(precDto: DTP_DETALLES_DET_DTO) {
        let headers = new Headers({
            'Content-Type': 'application/json'
        });
        let options = new RequestOptions({ headers: headers });
        return this._http.post('DocTiposProgram/SalvarValorDetalle', { precDto: precDto }, options).map(response => {
            return response.json();
        }).catch(this.handleError);
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
} //FIN DTP_TIPOS_PROGRAM_CAB_DTOService