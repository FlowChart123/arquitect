import { EventEmitter, Component, OnInit, Output, ViewChild, } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbCalendar } from '@ng-bootstrap/ng-bootstrap';

import { NgbInputDatepicker } from '@ng-bootstrap/ng-bootstrap'; 
import { validateEvents } from 'angular-calendar/modules/common/util';
import { GenericListService } from 'src/app/Business/DataServices/GenericListService';
import { SistemaFinanceiroService } from 'src/app/Business/DataServices/SistemaFinanceiroService';
import { SistemaFinanceiro } from 'src/app/Business/Models/sistema-financeiro';

const now = new Date();

@Component({
  selector: 'app-sf-form',
  templateUrl: './sf-form.component.html',
  styleUrls: ['./sf-form.component.sass'],
  providers: [SistemaFinanceiroService, GenericListService],
  styles: [`
  .custom-day {
    text-align: center;
    padding: 0.185rem 0.25rem;
    display: inline-block;
    height: 2rem;
    width: 2rem;
  }

  .custom-day.focused {
    background-color: #e6e6e6;
  }

  .custom-day.range, .custom-day:hover {
    background-color: rgb(2, 117, 216);
    color: white;
  }

  .custom-day.faded {
    background-color: rgba(2, 117, 216, 0.5);
  }
`]
})
export class SFFormComponent implements OnInit {
  
  @Output()  init= new EventEmitter<any>();  
  // @ViewChild('dpDataDeCadastro', { static: true }) dpDataDeCadastro: NgbInputDatepicker;
  
  submitted=false;
  form: FormGroup;  
  // categorias=[];
  meses=[];
  // tipos_despesas=[];

  constructor(
    private principalsService: SistemaFinanceiroService,
    private calendar: NgbCalendar,
    private fb: FormBuilder,
    private genericLists: GenericListService
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
      this._get_record(id)
    }
    else{
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
    // this.genericLists.Get('Categorias','').subscribe(p=>{      
    //   this.categorias=p;
    // })
    this.meses=this.genericLists.Meses();
    // this.tipos_despesas=this.genericLists.TiposDespessa();
  }

}


