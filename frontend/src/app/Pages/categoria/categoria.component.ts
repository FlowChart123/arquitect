import { Component, OnInit, ViewChild } from '@angular/core';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { CategoriaModalComponent } from './categoria-modal/categoria-modal.component';
import { CategoriaListComponent } from './categoria-list/categoria-list.component';
import { CategoriaService } from 'src/app/Business/DataServices/CategoriaService';
import { NotificationService } from 'src/app/Business/Services/NotificationService';


@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.sass'],
  providers:[CategoriaService]
  
})
export class CategoriaComponent implements OnInit {
  @ViewChild('dataFormCategorias') dataForm: CategoriaModalComponent;
  @ViewChild('dataList') dataList: CategoriaListComponent;

  constructor( private principalService: CategoriaService,
    private notifier: NotificationService ) {    
  }

  ngOnInit(): void {
    EventEmitterService.get('edit-categorias').subscribe(p=>{
      this.dataForm.open(p.id);
    })    
  }

  heading = 'Cadastros Gerais';
  subheading = '';
  icon = 'pe-7s-drawer icon-gradient bg-happy-itmeo';

  Adding()
  {    
    this.dataForm.open(0);
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
