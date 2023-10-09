import { Component, OnInit, Input, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { NotificacionesService } from '../Services/NotificacionesService';
import { DialogService } from '../Services/DialogService';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { ReportsService } from './Reports.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
    selector: 'reports',
    templateUrl: './Reports/ReportViewer',
    providers: [ReportsService]
})

export class ReportsComponent {
    constructor(private _service: ReportsService,
        private Notificacion: NotificacionesService,
        private _DialogService: DialogService,
        private _router: Router,
        public sanitizer: DomSanitizer
    ) {
    }
    url: any;
    page: number = 1;
    @Input() Parametros: any;
    @Output() notificar: EventEmitter<boolean> = new EventEmitter<boolean>();

    @ViewChild('pdfViewer') iframe: ElementRef;

    Volver() {
        this.notificar.emit(true);
    }

    ngAfterViewInit() {

        this._service.traerReporte(this.Parametros).subscribe((res: any) => {

            var rawLength = res.text.length;
            var pdfData = new Uint8Array(new ArrayBuffer(rawLength));

            for (var i = 0; i < rawLength; i++) {
                pdfData[i] = res.text[i];
            }

            //this.iframe.nativeElement.contentWindow.PDFViewerApplication.open(pdfData);

            this.iframe.nativeElement.contentWindow.PDFViewerApplication.open(this.base64ToUint8Array(res.text64));
        });

    }
    private base64ToUint8Array(base64: any) {
        var raw = atob(base64);
        var uint8Array = new Uint8Array(raw.length);
        for (var i = 0; i < raw.length; i++) {
            uint8Array[i] = raw.charCodeAt(i);
        }
        return uint8Array;
    }
}