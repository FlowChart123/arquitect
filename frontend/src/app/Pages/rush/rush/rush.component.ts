import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-rush',
  templateUrl: './rush.component.html',
  styleUrls: ['./rush.component.sass']
})
export class RushComponent implements OnInit {

  constructor() {    
  }

  ngOnInit(): void {
    
  }

  heading = 'Suplementos para teste de CRUD de dados';
  subheading = 'Modelo de entrada de dados utilizado no sistema, listagens e formulários dinâmicos.';
  icon = 'pe-7s-drawer icon-gradient bg-happy-itmeo';

  Adding()
  {
    alert(123);
  }
}
