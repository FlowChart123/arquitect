import { Component, OnInit, ViewChild } from '@angular/core';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { CategoriaModalComponent } from './categoria-modal/categoria-modal.component';
import { CategoriaListComponent } from './categoria-list/categoria-list.component';
import { CategoriaService } from 'src/app/Business/DataServices/CategoriaService';
import { NotificationService } from 'src/app/Business/Services/NotificationService';
import { BasePageComponent } from 'src/app/Components/base-page/base-page.component';
import { CategoriaFormComponent } from './categoria-form/categoria-form.component';


@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.sass'],
  providers:[CategoriaService]
  
})
export class CategoriaComponent extends BasePageComponent implements OnInit {
  @ViewChild('dataForm') dataForm: CategoriaFormComponent;
  @ViewChild('dataList') dataList: CategoriaListComponent;

  constructor( private principalService: CategoriaService,
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
