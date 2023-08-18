import { Component, OnInit, ViewChild } from '@angular/core';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { CategoriaModalComponent } from './categoria-modal/categoria-modal.component';
import { CategoriaListComponent } from './categoria-list/categoria-list.component';
import { CategoriaService } from 'src/app/Business/DataServices/CategoriaService';
import { NotificationService } from 'src/app/Business/Services/NotificationService';
import { BasePageComponent } from 'src/app/Components/base-page/base-page.component';


@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.sass'],
  providers:[CategoriaService]
  
})
export class CategoriaComponent extends BasePageComponent implements OnInit {
  @ViewChild('dataForm') dataForm: CategoriaModalComponent;
  @ViewChild('dataList') dataList: CategoriaListComponent;

  constructor( private principalService: CategoriaService,
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
