import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
// import { FormsBasepageComponent } from 'src/app/Layout/custom-layout/forms-basepage/forms-basepage.component';
// import { PageTitleComponent } from 'src/app/Layout/Components/page-title/page-title.component';
// import { PageTitleModule } from 'src/app/Layout/Components/page-title/page-title.module';
// import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    // FormsBasepageComponent,    
    // PageTitleComponent,
    // ReactiveFormsModule
  ],
  imports: [
    CommonModule,    
    // PageTitleComponent,
    // PageTitleModule
  ],
  exports: [
    // FormsBasepageComponent,,
    // PageTitleComponent,
    // PageTitleModule, ReactiveFormsModule
  ]
})
export class SharedModule { }
