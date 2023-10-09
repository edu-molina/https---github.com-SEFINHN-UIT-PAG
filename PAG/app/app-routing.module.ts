import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//import { Dtp_Tipos_Program_CabComponent } from './DocTiposProgram/Dtp_Tipos_Program_Cab.component';
//import { DocTiposProgramConsultaComponent } from './DocTiposProgram/DocTiposProgramConsulta.component';
//import { DocTiposProgramCrearComponent } from './DocTiposProgram/DocTiposProgramCrear.component';
//import { DocTiposProgramDetalleComponent } from './DocTiposProgram/DocTiposProgramDetalle.component';
//import { TiposProgramComponent } from './TiposProgram/TiposProgram.component';
//import { LibBolsonFteComponent } from './LibBolsonFte/LibBolsonFte.component';
//import { DocLibBolsonFteComponent } from './DocLibBolsonFte/DocLibBolsonFte.component';
//import { DocLibBolsonFteConsultaComponent } from './DocLibBolsonFte/DocLibBolsonFteConsulta.component';
//import { DocLibBolsonFteCrearComponent } from './DocLibBolsonFte/DocLibBolsonFteCrear.component';

import { PageNotFoundComponent } from './Services/NotFound/not-found.component';
import { AppComponent } from './pag.component';

//const appRoutes: Routes = [
//    { path: 'doctiposprogram/index', component: Dtp_Tipos_Program_CabComponent },
//    { path: 'doctiposprogram', component: Dtp_Tipos_Program_CabComponent },
//    { path: 'tiposprogram/index', component: TiposProgramComponent },
//    { path: 'tiposprogram', component: TiposProgramComponent },
//    { path: 'libbolsonfte/index', component: LibBolsonFteComponent },
//    { path: 'libbolsonfte', component: LibBolsonFteComponent },
//    { path: 'doclibbolsonfte/index', component: DocLibBolsonFteComponent },
//    { path: 'doclibbolsonfte', component: DocLibBolsonFteComponent },
//    { path: '**', component: PageNotFoundComponent }
//];
const appRoutesV2: Routes = [
    { path: 'doclibbolsonfte', loadChildren: './app/DocLibBolsonFte/DocLibBolsonFte.module#DocLibBolsonFteModule' },
    { path: 'doctiposprogram', loadChildren: './app/DocTiposProgram/Dtp_Tipos_Program_Cab.module#Dtp_Tipos_Program_Cabmodule' },
    { path: 'libbolsonfte', loadChildren: './app/LibBolsonFte/LibBolsonFte.module#LibBolsonFteModule' },
    { path: 'tiposprogram', loadChildren: './app/TiposProgram/TiposProgram.module#TiposProgramModule' },
    { path: '',component:AppComponent, pathMatch:'full' },
    { path: '**', component: PageNotFoundComponent }
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutesV2)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }