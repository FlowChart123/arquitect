import { Component, OnInit, ViewChild } from '@angular/core';
import { CodigoBarraListComponent } from './codigobarra-list/codigobarra-list.component';
import { CodigoBarraService } from 'src/app/Business/DataServices/CodigoBarraService';
import { NotificationService } from 'src/app/Business/Services/NotificationService';
import { BasePageComponent } from 'src/app/Components/base-page/base-page.component';
import { CodigoBarraFormComponent } from './codigobarra-form/codigobarra-form.component';


@Component({
  selector: 'app-codigobarra',
  templateUrl: './codigobarra.component.html',
  styleUrls: ['./codigobarra.component.sass'],
  providers:[CodigoBarraService]
  
})
export class CodigoBarraComponent extends BasePageComponent implements OnInit {
  @ViewChild('dataForm') dataForm: CodigoBarraFormComponent;
  @ViewChild('dataList') dataList: CodigoBarraListComponent;

  constructor( private principalService: CodigoBarraService,
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
