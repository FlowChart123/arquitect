import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-label-pessoa-fisica',
  templateUrl: './label-pessoa-fisica.component.html',
  styleUrls: ['./label-pessoa-fisica.component.sass']
})
export class LabelPessoaFisicaComponent implements OnInit {

  @Input() item;

  constructor() { }

  ngOnInit(): void {
  }

  getTipoPessoa(isFis)
  {
    if (isFis==true)
      return "Física";
    else return "Jurídica";
  }
}
