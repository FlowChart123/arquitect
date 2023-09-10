import { Component, OnInit, ViewChild } from '@angular/core';
import { DespesasService } from 'src/app/Business/DataServices/DespesasService';
import { DespesasListComponent } from './despesas-list/despesas-list.component';
import { NotificationService } from 'src/app/Business/Services/NotificationService';
import { BasePageComponent } from 'src/app/Components/base-page/base-page.component';
import { DespesasFormComponent } from './despesas-form/despesas-form.component';


@Component({
  selector: 'app-despesas',
  templateUrl: './despesas.component.html',
  styleUrls: ['./despesas.component.sass'],
  providers:[DespesasService]
  
})
export class DespesasComponent extends BasePageComponent implements OnInit {
  @ViewChild('dataForm') dataForm: DespesasFormComponent;
  @ViewChild('dataList') dataList: DespesasListComponent;

  constructor( private despesaService: DespesasService,
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
