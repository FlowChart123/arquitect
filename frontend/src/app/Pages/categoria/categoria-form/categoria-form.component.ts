import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { GenericListService } from 'src/app/Business/DataServices/GenericListService';
import { CategoriaService } from 'src/app/Business/DataServices/CategoriaService';
import { Categoria } from 'src/app/Business/Models/categoria';
import { NotificationService } from 'src/app/Business/Services/NotificationService';
import { BaseFormComponent } from 'src/app/Components/base-form/base-form.component';

const now = new Date();

@Component({ 
  selector: 'app-categoria-form',
  templateUrl: './categoria-form.component.html',
  styleUrls: ['./categoria-form.component.sass'],
  providers: [CategoriaService, GenericListService],  
})
export class CategoriaFormComponent extends BaseFormComponent<Categoria> implements OnInit {
  
  constructor(
    private principalsService: CategoriaService,    
    private fb: FormBuilder,        
    private notifier: NotificationService
  ) { 
    super(fb,notifier);
  }
    
  ngOnInit(): void {
    
  }
      
  Initialize(id : any){    
    if (id && id!=''){
      this.title='EDITAR CATEGORIA';
      this.elementId=id;
      this._get_record()
    }
    else{
      this.title='ADICIONAR CATEGORIA';
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
  
  _get_newModel()
  {
    let dt = new Date();

    var ln =  {      
      id: 0,
      nome:''
    } as Categoria;
    this.model=ln;
    this.createForm();
  }

  _get_record()
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
        this.showError(err.message,"Erro!");
        
      });
    }
  }
  
}


