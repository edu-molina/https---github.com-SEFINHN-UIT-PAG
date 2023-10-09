import { NgModule } from '@angular/core';
//import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { ToastyModule } from 'ng2-toasty';
import { DataTableModule, SharedModule, DropdownModule, DialogModule, ButtonModule } from 'primeng/primeng';
import { FormsModule } from '@angular/forms';
import { RouterModule,Routes } from '@angular/router';

import { DocLibBolsonFteService } from './DocLibBolsonFte.service';

import { DocLibBolsonFteComponent } from './DocLibBolsonFte.component';
import { DocLibBolsonFteConsultaComponent } from './DocLibBolsonFteConsulta.component'
import { DocLibBolsonFteCrearComponent } from './DocLibBolsonFteCrear.component'
import { ReportModule } from '../Reports/Reports.module';
import { NotificacionesService } from '../Services/NotificacionesService';

@NgModule({
    imports: [
        //BrowserModule,
        CommonModule,
        ToastyModule.forRoot(),
        FormsModule,
        SharedModule,
        DropdownModule,
        DataTableModule,
        DialogModule,
        ButtonModule,
        ReportModule,
        RouterModule.forChild([
            {
                path: '',
                component: DocLibBolsonFteComponent,
                children: [
                    { path: 'index', component: DocLibBolsonFteComponent },
                    { path: 'index', component: DocLibBolsonFteComponent,pathMatch:'full' }
                ]
            }
            //RouterModule.forChild([
            //    { path: 'doclibbolsonfte/index', component: DocLibBolsonFteComponent },
            //    { path: 'doclibbolsonfte', component: DocLibBolsonFteComponent }
            //])
        ])
    ],
    declarations: [
        DocLibBolsonFteComponent,
        DocLibBolsonFteConsultaComponent,
        DocLibBolsonFteCrearComponent
    ],
    providers: [DocLibBolsonFteService, NotificacionesService],
    exports: [ToastyModule]
})
export class DocLibBolsonFteModule { }