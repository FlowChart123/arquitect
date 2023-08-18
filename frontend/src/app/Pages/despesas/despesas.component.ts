import { Component, OnInit, ViewChild } from '@angular/core';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { DespesasModalComponent } from './despesas-modal/despesas-modal.component';
import { DespesasService } from 'src/app/Business/DataServices/DespesasService';
import { DespesasListComponent } from './despesas-list/despesas-list.component';
import { NotificationService } from 'src/app/Business/Services/NotificationService';
import { BasePageComponent } from 'src/app/Components/base-page/base-page.component';


@Component({
  selector: 'app-despesas',
  templateUrl: './despesas.component.html',
  styleUrls: ['./despesas.component.sass'],
  providers:[DespesasService]
  
})
export class DespesasComponent extends BasePageComponent implements OnInit {
  @ViewChild('dataForm') dataForm: DespesasModalComponent;
  @ViewChild('dataList') dataList: DespesasListComponent;

  constructor( private despesaService: DespesasService,
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

  Save(obj)
  {
    this.despesaService.InsertOrUpdate(obj).subscribe(p=>{    
      this.dataList._RefreshData();
      this.dataForm.close();
      this.notifier.openToast('Informações salvas com sucesso!',"Confirmado!","success");
    });
  }

  PrintContent()
  {
    super.onPrintByClass('printer');
  }

  
}
