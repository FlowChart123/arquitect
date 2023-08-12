import { Component, OnInit, ViewChild } from '@angular/core';
import { RushModalComponent } from './rush-modal/rush-modal.component';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';


@Component({
  selector: 'app-rush',
  templateUrl: './rush.component.html',
  styleUrls: ['./rush.component.sass']
})
export class RushComponent implements OnInit {
  @ViewChild('dataForm', { static: true }) dataForm: RushModalComponent;

  constructor() {    
  }

  ngOnInit(): void {
    EventEmitterService.get('edit').subscribe(p=>{
      this.dataForm.open(p.id);
    })    
  }

  heading = 'Suplementos para teste de CRUD de dados';
  subheading = 'Modelo de entrada de dados utilizado no sistema, listagens e formulários dinâmicos.';
  icon = 'pe-7s-drawer icon-gradient bg-happy-itmeo';

  Adding()
  {
    this.dataForm.open('');
  }
}
