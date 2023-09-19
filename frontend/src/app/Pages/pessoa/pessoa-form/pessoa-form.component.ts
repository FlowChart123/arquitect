import { EventEmitter, Component, OnInit, Output, ViewChild, } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { formatDate } from '@angular/common';

import { GenericListService } from 'src/app/Business/DataServices/GenericListService';
import { PessoaService } from 'src/app/Business/DataServices/PessoaService';
import { Pessoa } from 'src/app/Business/Models/pessoa';
import { PessoaFisica } from 'src/app/Business/Models/pessoaFisica';
import { PessoaFisicaComplemento } from 'src/app/Business/Models/pessoaFisicaComplemento';
import { NotificationService } from 'src/app/Business/Services/NotificationService';
import { GenericValidator } from 'src/app/Business/Validators/CpfValidator';

const now = new Date();

@Component({
  selector: 'app-pessoa-form',
  templateUrl: './pessoa-form.component.html',
  styleUrls: ['./pessoa-form.component.sass'],
  providers: [PessoaService, GenericListService],
  
})
export class PessoaFormComponent implements OnInit {
  
  @Output()  init= new EventEmitter<any>();  
  @Output()  OnCallBack= new EventEmitter<any>();  
  
  submitted=false;
  form: FormGroup;    
  title='';
  mode='zero';
  editMode=false;

  SetDocMode()
  {
    let t = this.form.controls['doc'].value;
   

     if (t.length==11)
    {
      this.mode='CPF';
    }
    else if (t.length==14){
      this.mode='CNPJ';
    }
    else 
    {
      this.mode='OUTROS';
    }
  }


  constructor(
    private principalsService: PessoaService,
    private calendar: NgbCalendar,
    private fb: FormBuilder,
    private genericLists: GenericListService,
    private notifier: NotificationService
  ) { }
<<<<<<< Updated upstream
=======

  ngAfterViewInit(): void {
    
  }
>>>>>>> Stashed changes
  model:Pessoa;

  ngOnInit(): void {
    this.init.emit(this);
    this.loadSelects();
  }
  elementId:any;
  

  

<<<<<<< Updated upstream
  Initialize(id : any){    
=======
  Initialize(id: any){        
    this.submitted=false;
    
    //let id = localStorage.getItem('editId');
>>>>>>> Stashed changes
    if (id && id!=''){
      this.elementId=id;
      this.title='EDITAR - PESSOA';
      this.editMode=true;
      this._get_record(id)
    }
    else{
      this.title='INSERIR - PESSOA';
      this.editMode=false;
      this._get_newModel();
    }      
}  

  createForm()
  {
       
    this.form = this.fb.group
    (      
      {
        id: [this.model.id],
<<<<<<< Updated upstream
        nome: [this.model.nome, [Validators.required]],    
        pessoaFisica: this.fb.group(
          {
            cpf: [this.model.pessoaFisica.cpf],            
            pessoaFisicaComplemento: this.fb.group(
              {
                  id: [this.model.pessoaFisica.pessoaFisicaComplemento.id], 
                  rg: [this.model.pessoaFisica.pessoaFisicaComplemento.rg,[Validators.required]],
                  rgEmissaoData: [formatDate(_rgEmissao, 'yyyy-MM-dd', 'en')],
                  rgEmissaoUF: [this.model.pessoaFisica.pessoaFisicaComplemento.rgEmissaoUF],
                  rgEmissaoMunicipio: [this.model.pessoaFisica.pessoaFisicaComplemento.rgEmissaoMunicipio],
                  nascimentoData: [formatDate(_nascimentoData, 'yyyy-MM-dd', 'en')],
                  nascimentoUf: [this.model.pessoaFisica.pessoaFisicaComplemento.nascimentoUf],
                  nascimentoMunicipio: [this.model.pessoaFisica.pessoaFisicaComplemento.rgEmissaoMunicipio],
                  nomePai: [this.model.pessoaFisica.pessoaFisicaComplemento.nomePai],
                  nomeMae: [this.model.pessoaFisica.pessoaFisicaComplemento.nomeMae],
                  cnh: [this.model.pessoaFisica.pessoaFisicaComplemento.cnh],
                  cnhEmissao: [formatDate(_cnhEmissao, 'yyyy-MM-dd', 'en')],
                  cnhValidade:[formatDate(_cnhValidade, 'yyyy-MM-dd', 'en')],
                  cnhCategoria: [this.model.pessoaFisica.pessoaFisicaComplemento.cnhCategoria],
                  cnhPrimeiraHabilitacao: [formatDate(_cnhPHabilitacao, 'yyyy-MM-dd', 'en')],
                  nacionalidade: [this.model.pessoaFisica.pessoaFisicaComplemento.nacionalidade]            
              }
            )
          }
        )
      }
    )
=======
        nome: [this.model.nome, [Validators.required]],  
        doc: [this.model.docNum, [Validators.required,GenericValidator.isValidCpf(), GenericValidator.isValidCnpj()]],               
      }
    )
   
>>>>>>> Stashed changes
  }
  
  get f() {
    return this, this.form.controls;
  }

  _get_newModel()
  {
    let dt = new Date();

    var ln =  {      
      id: null,
<<<<<<< Updated upstream
      nome:'',
      pessoaFisica: {
        cpf:'',        
        id: '00000000-0000-0000-0000-000000000000', //coloquei o id zerado para nao ter que criar uma casse dto para insercao
        pessoaFisicaComplemento:{
          id: '00000000-0000-0000-0000-000000000000', 
          rg: '',
          rgEmissaoData: new Date(),
          rgEmissaoUF: '',
          rgEmissaoMunicipio: '',
          nascimentoData:'',
          nascimentoUf: '',
          nascimentoMunicipio: '',
          nomePai: '',
          nomeMae: '',
          cnh: '',
          cnhEmissao:new Date(),
          cnhValidade: new Date(),
          cnhCategoria: '',
          cnhPrimeiraHabilitacao: new Date(),
          nacionalidade: ''
        }
      }
=======
      nome:'',       
      docNum:''    
>>>>>>> Stashed changes
    } as Pessoa;
    this.model=ln;
    this.createForm();
  }

  _get_record(id)
  {
<<<<<<< Updated upstream
      this.principalsService.Load(this.elementId).subscribe(p=>{    
        console.log(p);    
        this.model=p;
        this.createForm();
      })
=======
    this.principalsService.Load(this.elementId).subscribe(p=>{                  
      this.model=p;      
      if (this.model.pessoaFisica)
      {
        
      }
      else
      {
        
      }
      this.createForm();
    })
>>>>>>> Stashed changes
  }


  loadSelects()
  {    
    
  }

  
  Back()
  {
    var res={
      mode:'back',  
      result:'---'    
     }
     this.OnCallBack.emit(res);
  }

  Save()
  {
    let f = this.form;    
    this.submitted=true;    
    console.log(f.errors);
    if (f.valid==true) {
      let vr=f.value;     
      this.principalsService.InsertOrUpdate(vr).subscribe(p=>{   
         var res={
          mode:'save',
          result:'success'
         }
         this.OnCallBack.emit(res);
      }, err=>{              
        this.notifier.openToast(err.message,"Erro!","error");
      });
    }
  }  
}


