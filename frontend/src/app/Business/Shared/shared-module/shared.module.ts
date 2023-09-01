import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DtHeaderDirective } from 'src/app/Components/datagrid/dt-header.directive';
import { LeftToolboxFormComponent } from 'src/app/Components/left-toolbox-form/left-toolbox-form.component';



@NgModule({
  declarations: [
    DtHeaderDirective,
    LeftToolboxFormComponent
    
  ],
  imports: [
    CommonModule,    
  ],
  exports: [
    DtHeaderDirective,
    LeftToolboxFormComponent
  ]
})
export class SharedModule { }
