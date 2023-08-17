import { Component, OnInit, ViewChild } from '@angular/core';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { CodigoBarraModalComponent } from './codigobarra-modal/codigobarra-modal.component';
import { CodigoBarraListComponent } from './codigobarra-list/codigobarra-list.component';
import { CodigoBarraService } from 'src/app/Business/DataServices/CodigoBarraService';
import { NotificationService } from 'src/app/Business/Services/NotificationService';


@Component({
  selector: 'app-codigobarra',
  templateUrl: './codigobarra.component.html',
  styleUrls: ['./codigobarra.component.sass'],
  providers:[CodigoBarraService]
  
})
export class CodigoBarraComponent implements OnInit {
  @ViewChild('dataFormCB') dataForm: CodigoBarraModalComponent;
  @ViewChild('dataList') dataList: CodigoBarraListComponent;

  constructor( private principalService: CodigoBarraService,
    private notifier: NotificationService ) {    
  }

  ngOnInit(): void {
    EventEmitterService.get('edit-codigobarra').subscribe(p=>{
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
