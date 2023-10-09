import { NgModule } from '@angular/core';
//import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { ToastyModule } from 'ng2-toasty';
import { DataTableModule, SharedModule, DropdownModule } from 'primeng/primeng';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { Dtp_Tipos_Program_CabService } from '../DocTiposProgram/Dtp_Tipos_Program_Cab.Service';
import { TiposProgramService } from './TiposProgram.service';
import { TiposProgramComponent } from './TiposProgram.component';
import { ReportModule } from '../Reports/Reports.module';
import { NotificacionesService } from '../Services/NotificacionesService';

@NgModule({
    imports: [
        CommonModule,
        ToastyModule.forRoot(),
        FormsModule,
        SharedModule,
        DropdownModule,
        DataTableModule,
        ReportModule,
        RouterModule.forChild([
            {
                path: '',
                children: [
                    { path: 'index', component: TiposProgramComponent },
                    { path: '', component: TiposProgramComponent,pathMatch:'full' }
                ]
            }
            
        ])
    ],
    declarations: [TiposProgramComponent],
    providers: [TiposProgramService, Dtp_Tipos_Program_CabService, NotificacionesService],
    exports: [ToastyModule]
})
export class TiposProgramModule { }