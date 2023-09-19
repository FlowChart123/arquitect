import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { GenericListService } from 'src/app/Business/DataServices/GenericListService';
import { PessoaService } from 'src/app/Business/DataServices/PessoaService';
import { Pessoa } from 'src/app/Business/Models/pessoa';
import { PessoaFisica } from 'src/app/Business/Models/pessoaFisica';
import { NotificationService } from 'src/app/Business/Services/NotificationService';

declare var $: any;

@Component({
  selector: 'app-pessoa-fisica-complementos',
  templateUrl: './pessoa-fisica-complementos.component.html',
  styleUrls: ['./pessoa-fisica-complementos.component.sass']
})
export class PessoaFisicaComplementosComponent implements OnInit {


  submitted = true;
  form: FormGroup;
  model: PessoaFisica;

  buildForm() {
    let _rgEmissao=(this.model && this.model.pessoaFisicaComplemento && this.model.pessoaFisicaComplemento.rgEmissaoData) ? this.model.pessoaFisicaComplemento.rgEmissaoData : new Date();
    let _nascimentoData = (this.model &&  this.model.pessoaFisicaComplemento && this.model.pessoaFisicaComplemento.rgEmissaoData) ? this.model.pessoaFisicaComplemento.rgEmissaoData : new Date();
    let _cnhEmissao = (this.model &&  this.model.pessoaFisicaComplemento && this.model.pessoaFisicaComplemento.cnhEmissao) ? this.model.pessoaFisicaComplemento.cnhEmissao : new Date();
    let _cnhValidade = (this.model &&  this.model.pessoaFisicaComplemento &&this.model.pessoaFisicaComplemento.cnhValidade) ? this.model.pessoaFisicaComplemento.cnhValidade : new Date();
    let _cnhPHabilitacao = (this.model &&  this.model.pessoaFisicaComplemento && this.model.pessoaFisicaComplemento.cnhPrimeiraHabilitacao) ? this.model.pessoaFisicaComplemento.cnhPrimeiraHabilitacao : new Date();


    this.form = this.fb.group
      (
        {
          cpf: [this.model.cpf],
          pessoaFisicaComplemento: this.fb.group(
            {
              id: [this.model.pessoaFisicaComplemento.id],
              rg: [this.model.pessoaFisicaComplemento.rg, [Validators.required]],
              rgEmissaoData: [formatDate(_rgEmissao, 'yyyy-MM-dd', 'en')],
              rgEmissaoUf: [this.model.pessoaFisicaComplemento.rgEmissaoUf, [Validators.required]],
              rgEmissaoMunicipio: [this.model.pessoaFisicaComplemento.rgEmissaoMunicipio],
              nascimentoData: [formatDate(_nascimentoData, 'yyyy-MM-dd', 'en')],
              nascimentoUf: [this.model.pessoaFisicaComplemento.nascimentoUf],
              nascimentoMunicipio: [this.model.pessoaFisicaComplemento.rgEmissaoMunicipio],
              nomePai: [this.model.pessoaFisicaComplemento.nomePai],
              nomeMae: [this.model.pessoaFisicaComplemento.nomeMae],
              cnh: [this.model.pessoaFisicaComplemento.cnh],
              cnhEmissao: [formatDate(_cnhEmissao, 'yyyy-MM-dd', 'en')],
              cnhValidade: [formatDate(_cnhValidade, 'yyyy-MM-dd', 'en')],
              cnhCategoria: [this.model.pessoaFisicaComplemento.cnhCategoria],
              cnhPrimeiraHabilitacao: [formatDate(_cnhPHabilitacao, 'yyyy-MM-dd', 'en')],
              nacionalidade: [this.model.pessoaFisicaComplemento.nacionalidade]
            }
          )
        });


    setTimeout(() => {
      $('#sleCnpj').mask('00.000.000/0000-00', { reverse: true });
    }, 500);

  }

  constructor(
    private principalsService: PessoaService,
    private calendar: NgbCalendar,
    private fb: FormBuilder,
    private genericLists: GenericListService,
    private notifier: NotificationService
  ) { }



  ngOnInit(): void {
  }

}
