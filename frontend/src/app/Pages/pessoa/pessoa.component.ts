import { Component, OnInit, ViewChild } from '@angular/core';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { PessoaModalComponent } from './pessoa-modal/pessoa-modal.component';
import { PessoaListComponent } from './pessoa-list/pessoa-list.component';
import { PessoaService } from 'src/app/Business/DataServices/PessoaService';
import { NotificationService } from 'src/app/Business/Services/NotificationService';


@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.sass'],
  providers:[PessoaService]
  
})
export class PessoaComponent implements OnInit {
  @ViewChild('dataFormPessoa') dataForm: PessoaModalComponent;
  @ViewChild('dataList') dataList: PessoaListComponent;

  constructor( private principalService: PessoaService,
    private notifier: NotificationService ) {    
  }

  ngOnInit(): void {
    EventEmitterService.get('edit-pessoa').subscribe(p=>{
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
