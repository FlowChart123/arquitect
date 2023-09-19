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
<<<<<<< Updated upstream
=======
import { LabelPessoaFisicaComponent } from './components/label-pessoa-fisica/label-pessoa-fisica.component';
import { LabelPessoaJuridicaComponent } from './components/label-pessoa-juridica/label-pessoa-juridica.component';
import {TabsModule} from 'ngx-tabset';
>>>>>>> Stashed changes

import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatTabsModule } from '@angular/material/tabs';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatChipsModule } from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';
import { NgxMaskModule } from 'ngx-mask';
import { PessoaFisicaComplementosComponent } from './components/pessoa-fisica-complementos/pessoa-fisica-complementos.component';
import { PessoaJuridicaComplementosComponent } from './components/pessoa-juridica-complementos/pessoa-juridica-complementos.component';
import { PessoaOutrosComponent } from './components/pessoa-outros/pessoa-outros.component';


@NgModule({
  declarations: [
    PessoaComponent,
    PessoaListComponent,
    PessoaModalComponent,
<<<<<<< Updated upstream
    PessoaFormComponent  , 
=======
    PessoaFormComponent,
    LabelPessoaFisicaComponent,
    LabelPessoaJuridicaComponent,
    PessoaFisicaComplementosComponent,
    PessoaJuridicaComplementosComponent,
    PessoaOutrosComponent  , 
>>>>>>> Stashed changes
    
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
    MatCheckboxModule,
    MatCheckboxModule,
    MatButtonModule,
    MatInputModule,
    MatAutocompleteModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatRadioModule,
    MatSelectModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatTabsModule,
    MatExpansionModule,
    MatButtonToggleModule,
    MatChipsModule,
    MatIconModule,
    NgxMaskModule.forRoot({
      dropSpecialCharacters: false
    }),

    TabsModule.forRoot()      
  ],
  providers: [{provide: NgbDateAdapter, useClass: NgbDateNativeAdapter}],
  exports:[NgbPaginationModule, SharedModule, NgbDatepickerModule] 
})
export class PessoaModule { }
