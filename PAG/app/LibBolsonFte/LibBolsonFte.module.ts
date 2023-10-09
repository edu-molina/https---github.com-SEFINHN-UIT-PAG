import { NgModule } from '@angular/core';
//import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { ToastyModule } from 'ng2-toasty';
import { DataTableModule, SharedModule, DropdownModule } from 'primeng/primeng';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { LibBolsonFteService } from './LibBolsonFte.service';

import { LibBolsonFteComponent } from './LibBolsonFte.component';

import { ReportModule } from '../Reports/Reports.module';
import { NotificacionesService } from '../Services/NotificacionesService';

@NgModule({
    imports: [
        CommonModule,
        //BrowserModule,
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
                    { path: 'index', component: LibBolsonFteComponent },
                    { path: '', component: LibBolsonFteComponent, pathMatch: 'full' }
                ]
            }

        ])],
    declarations: [LibBolsonFteComponent],
    providers: [LibBolsonFteService, NotificacionesService],
    exports: [ToastyModule]
})
export class LibBolsonFteModule { }