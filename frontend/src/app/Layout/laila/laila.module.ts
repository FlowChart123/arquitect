
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LailaComponent } from './laila.component';
import { LailaRoutingModule } from './laila-routing.module';


@NgModule({
  imports: [
    CommonModule, FontAwesomeModule,    
    LailaRoutingModule,
  ],
  declarations: [LailaComponent],
  exports:[LailaComponent]
})
export class LailaModule { }
