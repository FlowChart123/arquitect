import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbDateAdapter, NgbDateNativeAdapter, NgbDatepickerModule, NgbModule, NgbPagination, NgbPaginationModule, NgbDateStruct, NgbCalendar  } from '@ng-bootstrap/ng-bootstrap';
import { TableRoutingModule } from 'src/app/DemoPages/Material/Datatable/table/table-routing.module';
import { RegularModule } from 'src/app/DemoPages/Tables/regular/regular.module';

import { PageTitleModule } from 'src/app/Layout/Components/page-title/page-title.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { SharedModule } from 'src/app/Business/Shared/shared-module/shared.module';
import { CodigoBarraComponent } from './codigobarra.component';
import { CodigoBarraListComponent } from './codigobarra-list/codigobarra-list.component';
import { CodigoBarraModalComponent } from './codigobarra-modal/codigobarra-modal.component';
import { CodigoBarraFormComponent } from './codigobarra-form/codigobarra-form.component';
import { CodigoBarraRoutingModule } from './codigobarra-routing.module';



@NgModule({
  declarations: [
    CodigoBarraComponent,
    CodigoBarraListComponent,
    CodigoBarraModalComponent,
    CodigoBarraFormComponent  , 
    
  ],
  imports: [
    NgbDatepickerModule,
    NgbModule,
    SharedModule,
    CommonModule,
    NgbPaginationModule,
    CodigoBarraRoutingModule,
    CommonModule,        
    CommonModule,
    TableRoutingModule,   
    PageTitleModule,FormsModule, ReactiveFormsModule,
    CommonModule, NgbModule, RegularModule,          
  ],
  providers: [{provide: NgbDateAdapter, useClass: NgbDateNativeAdapter}],
  exports:[NgbPaginationModule, SharedModule, NgbDatepickerModule] 
})
export class CodigoBarraModule { }
