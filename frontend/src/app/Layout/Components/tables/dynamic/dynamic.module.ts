import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TableDynamicComponent } from './dynamic.component';


@NgModule({
  imports: [
    CommonModule, FormsModule, ReactiveFormsModule, NgbModule,
  ],
  declarations: [TableDynamicComponent],
  exports: [TableDynamicComponent],
  
  
})
export class TableDynamicModule { }
