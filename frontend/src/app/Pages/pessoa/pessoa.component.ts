import { Component, OnInit, ViewChild } from '@angular/core';
import { PessoaListComponent } from './pessoa-list/pessoa-list.component';
import { PessoaService } from 'src/app/Business/DataServices/PessoaService';
import { NotificationService } from 'src/app/Business/Services/NotificationService';
import { BasePageComponent } from 'src/app/Components/base-page/base-page.component';
import { PessoaFormComponent } from './pessoa-form/pessoa-form.component';


@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.sass'],
  providers:[PessoaService]
  
})
export class PessoaComponent extends BasePageComponent implements OnInit {
  @ViewChild('dataForm') dataForm: PessoaFormComponent;
  @ViewChild('dataList') dataList: PessoaListComponent;

  constructor( private principalService: PessoaService,
    private notifier: NotificationService ) {    
      super();
  }

  ngOnInit(): void {
      
  }

  editMode=false;

  Adding()
  {        
    this.editMode = true;
    this.dataForm.submitted=false;
    
    this.dataForm.Initialize(0);
  }

  Edit(p)
  {
    this.editMode = true;
   
    this.dataForm.Initialize(p.id);   
  }

  
  PrintContent()
  {
    super.onPrintByClass('printer');
  }
  
  FormCallBack(obj)
  {
    if (obj.mode=='back'){
      this.editMode=false;
    }
    if (obj.mode=='save' && obj.result=='success') {
      this.dataList._RefreshData();
      this.editMode = false;
      this.notifier.openToast('Informações salvas com sucesso!',"Confirmado!","success");
      }
  }
}
