import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NotificationService } from 'src/app/Business/Services/NotificationService';



@Component({
  selector: 'app-base-form',
  templateUrl: './base-form.component.html',
  styleUrls: ['./base-form.component.sass']
})
export abstract class BaseFormComponent<TModel> implements OnInit {

  
  @Output()  init= new EventEmitter<any>();  
  @Output()  OnCallBack= new EventEmitter<any>();  
  
  title='';
  submitted=false;
  form: FormGroup;      
  elementId:any;
  model:TModel;

  constructor(
    private _fb: FormBuilder,        
    private _notifier: NotificationService
  ) { }

  ngOnInit(): void {
    this.init.emit(this);
    this.loadSelects();
  }
  
  get f() {
    return this, this.form.controls;
  }

  Back()
  {
    var res={
      mode:'back',  
      result:'---'    
     }
     this.OnCallBack.emit(res);
  }

  
  abstract loadSelects();
  abstract Initialize(id : any);
  abstract createForm();
  abstract _get_newModel();
  abstract _get_record();
  abstract Save();
  
  showError(msg,title)
  {
    this._notifier.openToast(msg,title,"error");
  }
  
}




//MODELO DOS METODOS UTILIZADOS:


// Initialize(id : any){    
//   if (id && id!=''){
//     this.title='EDITAR CATEGORIA';
//     this.elementId=id;
//     this._get_record()
//   }
//   else{
//     this.title='ADICIONAR CATEGORIA';
//     this._get_newModel();
//   }      
// }  

// Save()
// {
//   let f = this.form;    
//   this.submitted=true;    
//   if (f.valid==true) {
//     let vr=f.value;       
//     this.principalsService.InsertOrUpdate(vr).subscribe(p=>{   
//        var res={
//         mode:'save',
//         result:'success'
//        }
//        this.OnCallBack.emit(res);
//     }, err=>{      
//       this.notifier.openToast(err.message,"Erro!","error");
//     });
//   }
// }



// createForm()
// {
//   this.form = this.fb.group
//   (      
//     {
//       id: [this.model.id],
//       nome: [this.model.nome, [Validators.required]],          
//     }
//   )
// }


// _get_newModel()
// {
//   let dt = new Date();

//   var ln =  {      
//     id: 0,
//     nome:''
//   } as Categoria;
//   this.model=ln;
//   this.createForm();
// }


// _get_record()
// {
//     this.principalsService.Load(this.elementId).subscribe(p=>{
//       console.log('registro:',p);
//       this.model=p;
//       this.createForm();
//     })
// }

