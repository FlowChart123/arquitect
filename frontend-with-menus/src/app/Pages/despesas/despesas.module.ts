import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbDateAdapter, NgbDateNativeAdapter, NgbDatepickerModule, NgbModule, NgbPagination, NgbPaginationModule, NgbDateStruct, NgbCalendar  } from '@ng-bootstrap/ng-bootstrap';
import { TableRoutingModule } from 'src/app/DemoPages/Material/Datatable/table/table-routing.module';
import { RegularModule } from 'src/app/DemoPages/Tables/regular/regular.module';

import { PageTitleModule } from 'src/app/Layout/Components/page-title/page-title.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { DespesasFormComponent } from './despesas-form/despesas-form.component';
import { DespesasModalComponent } from './despesas-modal/despesas-modal.component';
import { DespesasListComponent } from './despesas-list/despesas-list.component';
import { DespesasComponent } from './despesas.component';
import { DespesasRoutingModule } from './despesas-routing.module';
import { SharedModule } from 'src/app/Business/Shared/shared-module/shared.module';



@NgModule({
  declarations: [
    DespesasComponent,
    DespesasListComponent,
    DespesasModalComponent,
    DespesasFormComponent  , 
    
  ],
  imports: [
    NgbDatepickerModule,
    NgbModule,
    SharedModule,
    CommonModule,
    NgbPaginationModule,
    DespesasRoutingModule,
    CommonModule,        
    CommonModule,
    TableRoutingModule,   
    PageTitleModule,FormsModule, ReactiveFormsModule,
    CommonModule, NgbModule, RegularModule,          
  ],
  providers: [{provide: NgbDateAdapter, useClass: NgbDateNativeAdapter}],
  exports:[NgbPaginationModule, SharedModule, NgbDatepickerModule] 
})
export class DespesasModule { }
