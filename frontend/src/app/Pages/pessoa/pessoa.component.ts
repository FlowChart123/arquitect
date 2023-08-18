import { Component, OnInit, ViewChild } from '@angular/core';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { PessoaModalComponent } from './pessoa-modal/pessoa-modal.component';
import { PessoaListComponent } from './pessoa-list/pessoa-list.component';
import { PessoaService } from 'src/app/Business/DataServices/PessoaService';
import { NotificationService } from 'src/app/Business/Services/NotificationService';
import { BasePageComponent } from 'src/app/Components/base-page/base-page.component';


@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.sass'],
  providers:[PessoaService]
  
})
export class PessoaComponent extends BasePageComponent implements OnInit {
  @ViewChild('dataForm') dataForm: PessoaModalComponent;
  @ViewChild('dataList') dataList: PessoaListComponent;

  constructor( private principalService: PessoaService,
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
