import { Component, OnInit, ViewChild } from '@angular/core';
import { SFListComponent } from './sf-list/sf-list.component';
import { SistemaFinanceiroService } from 'src/app/Business/DataServices/SistemaFinanceiroService';
import { NotificationService } from 'src/app/Business/Services/NotificationService';
import { BasePageComponent } from 'src/app/Components/base-page/base-page.component';
import { SFFormComponent } from './sf-form/sf-form.component';


@Component({
  selector: 'app-sf',
  templateUrl: './sf.component.html',
  styleUrls: ['./sf.component.sass'],
  providers:[SistemaFinanceiroService]
  
})
export class SFComponent extends BasePageComponent implements OnInit {
  @ViewChild('dataForm') dataForm: SFFormComponent;
  @ViewChild('dataList') dataList: SFListComponent;

  constructor( private principalService: SistemaFinanceiroService,
    private notifier: NotificationService ) {   
      super(); 
  }

  editMode=false;
  
  ngOnInit(): void {
     
  }

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
