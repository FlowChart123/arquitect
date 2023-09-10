import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-label-pessoa-juridica',
  templateUrl: './label-pessoa-juridica.component.html',
  styleUrls: ['./label-pessoa-juridica.component.sass']
})
export class LabelPessoaJuridicaComponent implements OnInit {

  @Input() item;
  
  constructor() { }

  ngOnInit(): void {
  }

}
