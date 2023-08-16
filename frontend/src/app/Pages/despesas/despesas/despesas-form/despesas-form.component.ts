import { EventEmitter, Component, OnInit, Output, ViewChild, } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { DespesasService } from 'src/app/Business/DataServices/DespesasService';
import { Despesa } from 'src/app/Business/Models/despesa';
import { NgbInputDatepicker } from '@ng-bootstrap/ng-bootstrap'; 

const now = new Date();

@Component({
  selector: 'app-despesas-form',
  templateUrl: './despesas-form.component.html',
  styleUrls: ['./despesas-form.component.sass'],
  providers: [DespesasService],
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
export class DespesasFormComponent implements OnInit {
  
  @Output()  init= new EventEmitter<any>();  
  // @ViewChild('dpDataDeCadastro', { static: true }) dpDataDeCadastro: NgbInputDatepicker;
  
  submitted=false;
  form: FormGroup;  

  constructor(
    private despesasService: DespesasService,
    private calendar: NgbCalendar,
    private fb: FormBuilder
  ) { }
  model:Despesa;

  ngOnInit(): void {
    this.init.emit(this);
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


}


