import { EventEmitter, Component, OnInit, Output,} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbCalendar } from '@ng-bootstrap/ng-bootstrap';

import { GenericListService } from 'src/app/Business/DataServices/GenericListService';
import { SistemaFinanceiroService } from 'src/app/Business/DataServices/SistemaFinanceiroService';
import { SistemaFinanceiro } from 'src/app/Business/Models/sistema-financeiro';
import { NotificationService } from 'src/app/Business/Services/NotificationService';

const now = new Date();

@Component({
  selector: 'app-sf-form',
  templateUrl: './sf-form.component.html',
  styleUrls: ['./sf-form.component.sass'],
  providers: [SistemaFinanceiroService, GenericListService],
 
})
export class SFFormComponent implements OnInit {
  
  @Output()  init= new EventEmitter<any>();  
  @Output()  OnCallBack= new EventEmitter<any>();  
  
  submitted=false;
  form: FormGroup;    
  meses=[];
  title='';

  constructor(
    private principalsService: SistemaFinanceiroService,
    private calendar: NgbCalendar,
    private fb: FormBuilder,
    private genericLists: GenericListService,
    private notifier: NotificationService
  ) { }
  model:SistemaFinanceiro;

  ngOnInit(): void {
    this.init.emit(this);
    this.loadSelects();
  }
  elementId:any;
  

  

  Initialize(id : any){    
    if (id && id!=''){
      this.elementId=id;
      this.title='EDITAR SISTEMA FINANCEIRO';
      this._get_record(id)
    }
    else{
      this.title='ADICIONAR SISTEMA FINANCEIRO';
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
        ano: [this.model.ano, [Validators.required]],
        mes: [this.model.mes, [Validators.required]],
        diaFechamento: [this.model.diaFechamento, [Validators.required]],
        gerarCopiaDespesa: [this.model.gerarCopiaDespesa, [Validators.required]],
        mesCopia: [this.model.mesCopia, [Validators.required, Validators.min(1),Validators.max(12)]],
        anoCopia: [this.model.anoCopia, [Validators.required, Validators.min(2000)]],
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
      id: 0,
      ano:  dt.getFullYear(),
      mes: dt.getMonth(),   
      diaFechamento:30,     
      gerarCopiaDespesa:false,
      mesCopia:12,
      anoCopia:0   
    } as SistemaFinanceiro;
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
    this.meses=this.genericLists.Meses();
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


