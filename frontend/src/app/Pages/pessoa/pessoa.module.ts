import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbDateAdapter, NgbDateNativeAdapter, NgbDatepickerModule, NgbModule, NgbPagination, NgbPaginationModule, NgbDateStruct, NgbCalendar  } from '@ng-bootstrap/ng-bootstrap';
import { TableRoutingModule } from 'src/app/DemoPages/Material/Datatable/table/table-routing.module';
import { RegularModule } from 'src/app/DemoPages/Tables/regular/regular.module';

import { PageTitleModule } from 'src/app/Layout/Components/page-title/page-title.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { SharedModule } from 'src/app/Business/Shared/shared-module/shared.module';
import { PessoaComponent } from './pessoa.component';
import { PessoaListComponent } from './pessoa-list/pessoa-list.component';
import { PessoaModalComponent } from './pessoa-modal/pessoa-modal.component';
import { PessoaFormComponent } from './pessoa-form/pessoa-form.component';
import { PessoaRoutingModule } from './pessoa-routing.module';
import { LabelPessoaFisicaComponent } from './components/label-pessoa-fisica/label-pessoa-fisica.component';
import { LabelPessoaJuridicaComponent } from './components/label-pessoa-juridica/label-pessoa-juridica.component';



@NgModule({
  declarations: [
    PessoaComponent,
    PessoaListComponent,
    PessoaModalComponent,
    PessoaFormComponent,
    LabelPessoaFisicaComponent,
    LabelPessoaJuridicaComponent  , 
    
  ],
  imports: [
    NgbDatepickerModule,
    NgbModule,
    SharedModule,
    CommonModule,
    NgbPaginationModule,
    PessoaRoutingModule,
    CommonModule,        
    CommonModule,
    TableRoutingModule,   
    PageTitleModule,FormsModule, ReactiveFormsModule,
    CommonModule, NgbModule, RegularModule,          
  ],
  providers: [{provide: NgbDateAdapter, useClass: NgbDateNativeAdapter}],
  exports:[NgbPaginationModule, SharedModule, NgbDatepickerModule] 
})
export class PessoaModule { }
