import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { UrlSerializer } from '@angular/router';

import { ToastyModule } from 'ng2-toasty';


import { PageNotFoundComponent } from './Services/NotFound/not-found.component';

import { NotificacionesService } from './Services/NotificacionesService';
import { DialogService } from './Services/DialogService';

//import { CookieService } from 'angular2-cookie/services/cookies.service';

import { FormsModule } from '@angular/forms';
import { LowerCaseUrlSerializer } from './Helpers/LowerCaseUrlSerializer';

import { AppComponent } from './pag.component';
import { AppRoutingModule } from './app-routing.module';
//import { PdfViewerComponent } from 'ng2-pdf-viewer';

//import { Dtp_Tipos_Program_Cabmodule } from './DocTiposProgram/Dtp_Tipos_Program_Cab.module';
//import { TiposProgramModule } from './TiposProgram/TiposProgram.module';
//import { LibBolsonFteModule } from './LibBolsonFte/LibBolsonFte.module';
//import { DocLibBolsonFteModule } from './DocLibBolsonFte/DocLibBolsonFte.module';
import { ReportModule } from './Reports/Reports.module';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        ToastyModule.forRoot(), 
        AppRoutingModule,
        ReportModule
    ],
    declarations: [AppComponent, PageNotFoundComponent],
    bootstrap: [AppComponent],
    //providers: [NotificacionesService, CookieService, DialogService],
    providers: [NotificacionesService, DialogService,
        {
            provide: UrlSerializer,
            useClass: LowerCaseUrlSerializer
        }],
    exports: [ToastyModule],
})
export class AppModule { }
