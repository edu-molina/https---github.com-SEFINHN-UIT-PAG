
import { NgModule } from '@angular/core';
import { ReportsComponent } from '../Reports/Reports.component';
//import { BrowserModule } from '@angular/platform-browser';
//import { PdfViewerComponent } from 'ng2-pdf-viewer';
import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';

@NgModule({
    imports: [/*BrowserModule,*/ FormsModule,CommonModule],
    exports: [ReportsComponent],
    declarations: [ReportsComponent]
})
export class ReportModule { }