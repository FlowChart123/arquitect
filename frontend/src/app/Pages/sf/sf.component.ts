import { Component, OnInit, ViewChild } from '@angular/core';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { SFModalComponent } from './sf-modal/sf-modal.component';
import { SFListComponent } from './sf-list/sf-list.component';
import { SistemaFinanceiroService } from 'src/app/Business/DataServices/SistemaFinanceiroService';
import { NotificationService } from 'src/app/Business/Services/NotificationService';
import { BasePageComponent } from 'src/app/Components/base-page/base-page.component';


@Component({
  selector: 'app-sf',
  templateUrl: './sf.component.html',
  styleUrls: ['./sf.component.sass'],
  providers:[SistemaFinanceiroService]
  
})
export class SFComponent extends BasePageComponent implements OnInit {
  @ViewChild('dataForm') dataForm: SFModalComponent;
  @ViewChild('dataList') dataList: SFListComponent;

  constructor( private principalService: SistemaFinanceiroService,
    private notifier: NotificationService ) {   
      super(); 
  }

  ngOnInit(): void {
     
  }

  heading = 'Cadastros Gerais';
  subheading = '';
  icon = 'pe-7s-drawer icon-gradient bg-happy-itmeo';

  Adding()
  {    
    this.dataForm.open(0);
  }

  Edit(p)
  {
    this.dataForm.open(p.id);
  }
  
  
  PrintContent()
  {
    super.onPrintByClass('printer');
  }

  
  Save(obj)
  {
    this.principalService.InsertOrUpdate(obj).subscribe(p=>{    
      this.dataList._RefreshData();
      this.dataForm.close();
      this.notifier.openToast('Informações salvas com sucesso!',"Confirmado!","success");
    });
  }
}
