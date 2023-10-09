import { NgModule } from '@angular/core';
//import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { ToastyModule } from 'ng2-toasty';
//import { ReportModule } from '../Reports/Reports.module';
import { DropdownModule, DataTableModule, SharedModule, DialogModule, ButtonModule } from 'primeng/primeng';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { Dtp_Tipos_Program_CabService } from './Dtp_Tipos_Program_Cab.Service';
//import { DocTiposProgramModifService } from './DocTiposProgramModifService';
//import { DocTiposProgramConsultaService } from './DocTiposProgramConsultaService';
//import { DocTiposProgramCrearService } from './DocTiposProgramCrearService';
import { ReportModule } from '../Reports/Reports.module';
import { Dtp_Tipos_Program_CabComponent } from './Dtp_Tipos_Program_Cab.component';
import { DoctiposProgramModificarcomponent } from './DocTiposProgramModificar.component';
import { DocTiposProgramConsultaComponent } from './DocTiposProgramConsulta.component';
import { DocTiposProgramCrearComponent } from './DocTiposProgramCrear.component';
import { DocTiposProgramDetalleComponent } from './DocTiposProgramDetalle.component';
import { NotificacionesService } from '../Services/NotificacionesService';

@NgModule({
    imports: [
        CommonModule,
        //BrowserModule,
        ToastyModule.forRoot(),
        FormsModule,
        SharedModule,
        DialogModule,
        DropdownModule,
        DataTableModule,
        ButtonModule,
        ReportModule,
        RouterModule.forChild([
            {
                path: '',
                component: Dtp_Tipos_Program_CabComponent,
                children: [
                    { path: 'index', component: Dtp_Tipos_Program_CabComponent },
                    { path: 'index', component: Dtp_Tipos_Program_CabComponent, pathMatch: 'full' }]
            }
        ]
        )],
    declarations: [
        Dtp_Tipos_Program_CabComponent,
        DocTiposProgramConsultaComponent,
        DocTiposProgramDetalleComponent,
        DocTiposProgramCrearComponent
    ],
    providers: [Dtp_Tipos_Program_CabService, NotificacionesService],
    exports: [ToastyModule]
})
export class Dtp_Tipos_Program_Cabmodule { }