import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';



import { LailaRoutingModule } from './laila-routing.module';
import { LailaComponent } from './laila.component';
import { TableComponent } from 'src/app/DemoPages/Material/Datatable/table/table.component';
import { TableRoutingModule } from 'src/app/DemoPages/Material/Datatable/table/table-routing.module';
import { PageTitleModule } from '../Components/page-title/page-title.module';
import { RegularModule } from 'src/app/DemoPages/Tables/regular/regular.module';
import { TableDynamicModule } from '../Components/tables/dynamic/dynamic.module';



@NgModule({  
  imports: [
    CommonModule,    
    LailaRoutingModule,
    CommonModule,
    TableRoutingModule,   
    PageTitleModule,
    CommonModule, NgbModule, RegularModule, TableDynamicModule,
    PageTitleModule,
  ],

  declarations: [LailaComponent],
  exports:[LailaComponent]
})
export class LailaModule { }


