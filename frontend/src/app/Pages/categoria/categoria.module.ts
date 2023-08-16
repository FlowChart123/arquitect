import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbDateAdapter, NgbDateNativeAdapter, NgbDatepickerModule, NgbModule, NgbPagination, NgbPaginationModule, NgbDateStruct, NgbCalendar  } from '@ng-bootstrap/ng-bootstrap';
import { TableRoutingModule } from 'src/app/DemoPages/Material/Datatable/table/table-routing.module';
import { RegularModule } from 'src/app/DemoPages/Tables/regular/regular.module';

import { PageTitleModule } from 'src/app/Layout/Components/page-title/page-title.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { SharedModule } from 'src/app/Business/Shared/shared-module/shared.module';
import { CategoriaComponent } from './categoria.component';
import { CategoriaListComponent } from './categoria-list/categoria-list.component';
import { CategoriaModalComponent } from './categoria-modal/categoria-modal.component';
import { CategoriaFormComponent } from './categoria-form/categoria-form.component';
import { CategoriaRoutingModule } from './categoria-routing.module';



@NgModule({
  declarations: [
    CategoriaComponent,
    CategoriaListComponent,
    CategoriaModalComponent,
    CategoriaFormComponent  , 
    
  ],
  imports: [
    NgbDatepickerModule,
    NgbModule,
    SharedModule,
    CommonModule,
    NgbPaginationModule,
    CategoriaRoutingModule,
    CommonModule,        
    CommonModule,
    TableRoutingModule,   
    PageTitleModule,FormsModule, ReactiveFormsModule,
    CommonModule, NgbModule, RegularModule,          
  ],
  providers: [{provide: NgbDateAdapter, useClass: NgbDateNativeAdapter}],
  exports:[NgbPaginationModule, SharedModule, NgbDatepickerModule] 
})
export class CategoriaModule { }
