import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DtHeaderDirective } from 'src/app/Components/datagrid/dt-header.directive';



@NgModule({
  declarations: [
    DtHeaderDirective,
    
  ],
  imports: [
    CommonModule,    
  ],
  exports: [
    DtHeaderDirective,
    
  ]
})
export class SharedModule { }
