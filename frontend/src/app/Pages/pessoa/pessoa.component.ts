import { Component, OnInit, ViewChild } from '@angular/core';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { PessoaModalComponent } from './pessoa-modal/pessoa-modal.component';
import { PessoaListComponent } from './pessoa-list/pessoa-list.component';
import { PessoaService } from 'src/app/Business/DataServices/PessoaService';


@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.sass'],
  providers:[PessoaService]
  
})
export class PessoaComponent implements OnInit {
  @ViewChild('dataForm') dataForm: PessoaModalComponent;
  @ViewChild('dataList') dataList: PessoaListComponent;

  constructor( private principalService: PessoaService ) {    
  }

  ngOnInit(): void {
    EventEmitterService.get('edit').subscribe(p=>{
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
    });
  }
}
