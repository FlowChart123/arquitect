import { EventEmitter, Component, OnInit, Output,  } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { DespesasService } from 'src/app/Business/DataServices/DespesasService';
import { Despesa } from 'src/app/Business/Models/despesa';
import { GenericListService } from 'src/app/Business/DataServices/GenericListService';
import { NotificationService } from 'src/app/Business/Services/NotificationService';

const now = new Date();

@Component({
  selector: 'app-despesas-form',
  templateUrl: './despesas-form.component.html',
  styleUrls: ['./despesas-form.component.sass'],
  providers: [DespesasService, GenericListService],
  
})
export class DespesasFormComponent implements OnInit {
  
  @Output()  init= new EventEmitter<any>();  
  @Output()  OnCallBack= new EventEmitter<any>();  
  
  submitted=false;
  form: FormGroup;  
  categorias=[];
  meses=[];
  tipos_despesas=[];
  title='';

  constructor(
    private despesasService: DespesasService,
    private calendar: NgbCalendar,
    private fb: FormBuilder,
    private genericLists: GenericListService,
    private notifier: NotificationService
  ) { }
  model:Despesa;

  ngOnInit(): void {
    this.init.emit(this);
    this.loadSelects();
  }
  elementId:any;
  
  
  Initialize(id : any){    
    if (id && id!=''){
      this.elementId=id;
      this.title='EDITAR DESPESA';
      this._get_record(id)
    }
    else{
      this.title='INSERIR DESPESA';
      this._get_newModel();
    }      
}  

  createForm()
  {
    this.form = this.fb.group
    (      
      {
        id: [this.model.id],
        ano: [this.model.ano, [Validators.required]],
        mes: [this.model.mes, [Validators.required]],
        nome: [this.model.nome, [Validators.required]],
        dataPagamento: [this.model.dataPagamento, [Validators.required]],
        dataVencimento: [this.model.dataVencimento, [Validators.required]],
        despesaAtrasada: [this.model.despesaAntrasada, [Validators.required]],
        idCategoria: [this.model.idCategoria, [Validators.required]],
        pago: [this.model.pago, [Validators.required]],
        tipoDespesa: [this.model.tipoDespesa, [Validators.required]],
        valor: [this.model.valor, [Validators.required]],
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
      despesaAntrasada:false,
      pago:false,
      tipoDespesa:1,
      idCategoria:1,
      dataPagamento: dt,
      dataCadastro: dt,
      dataVencimento: dt,
      dataAlteracao: dt,
      valor:0
            
    } as Despesa;
    this.model=ln;
    this.createForm();
  }

  _get_record(id)
  {
      this.despesasService.Load(this.elementId).subscribe(p=>{
        console.log('registro:',p);
        this.model=p;
        this.createForm();
      })
  }


  loadSelects()
  {    
    this.genericLists.Get('Categorias','').subscribe(p=>{      
      this.categorias=p;
    })
    this.meses=this.genericLists.Meses();
    this.tipos_despesas=this.genericLists.TiposDespesa();
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
      this.despesasService.InsertOrUpdate(vr).subscribe(p=>{   
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


