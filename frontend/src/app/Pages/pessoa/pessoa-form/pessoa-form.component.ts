import { EventEmitter, Component, OnInit, Output, ViewChild, } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbCalendar } from '@ng-bootstrap/ng-bootstrap';

import { GenericListService } from 'src/app/Business/DataServices/GenericListService';
import { PessoaService } from 'src/app/Business/DataServices/PessoaService';
import { Pessoa } from 'src/app/Business/Models/pessoa';
import { NotificationService } from 'src/app/Business/Services/NotificationService';

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

  constructor(
    private principalsService: PessoaService,
    private calendar: NgbCalendar,
    private fb: FormBuilder,
    private genericLists: GenericListService,
    private notifier: NotificationService
  ) { }
  model:Pessoa;

  ngOnInit(): void {
    this.init.emit(this);
    this.loadSelects();
  }
  elementId:any;
  

  

  Initialize(id : any){    
    if (id && id!=''){
      this.elementId=id;
      this.title='EDITAR - PESSOA';
      this._get_record(id)
    }
    else{
      this.title='INSERIR - PESSOA';
      this._get_newModel();
    }      
}  

  createForm()
  {
    this.form = this.fb.group
    (      
      {
        id: [this.model.id],
        nome: [this.model.nome, [Validators.required]],    
       
      }
    )
  }
  
  get f() {
    return this, this.form.controls;
  }

  _get_newModel()
  {
    let dt = new Date();

    var ln =  {      
      id: null,
      nome:''
    } as Pessoa;
    this.model=ln;
    this.createForm();
  }

  _get_record(id)
  {
      this.principalsService.Load(this.elementId).subscribe(p=>{
        console.log('registro:',p);
        this.model=p;
        this.createForm();
      })
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


