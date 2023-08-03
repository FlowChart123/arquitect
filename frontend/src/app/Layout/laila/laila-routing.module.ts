import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LailaComponent } from './laila.component';


const routes: Routes = [
  {
    path: '',
    component: LailaComponent,
    data: {
      title: 'Laila Component'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LailaRoutingModule { }
