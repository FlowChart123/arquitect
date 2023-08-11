import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule, NgbPagination, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { TableRoutingModule } from 'src/app/DemoPages/Material/Datatable/table/table-routing.module';
import { RegularModule } from 'src/app/DemoPages/Tables/regular/regular.module';
import { RushRoutingModule } from './rush-routing.module';
import { RushComponent } from './rush/rush.component';
import { PageTitleModule } from 'src/app/Layout/Components/page-title/page-title.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RushListComponent } from './rush/rush-list/rush-list.component';

@NgModule({
  declarations: [
    RushComponent,
    RushListComponent,    
    
  ],
  imports: [
    CommonModule,
    NgbPaginationModule,
    RushRoutingModule,
    CommonModule,        
    CommonModule,
    TableRoutingModule,   
    PageTitleModule,FormsModule, ReactiveFormsModule,
    CommonModule, NgbModule, RegularModule,        
  ],
  
  exports:[NgbPaginationModule]
})
export class RushModule { }
