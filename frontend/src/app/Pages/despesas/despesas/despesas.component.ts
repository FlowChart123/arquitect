import { Component, OnInit, ViewChild } from '@angular/core';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { DespesasModalComponent } from './despesas-modal/despesas-modal.component';
import { DespesasService } from 'src/app/Business/DataServices/DespesasService';
import { DespesasListComponent } from './despesas-list/despesas-list.component';


@Component({
  selector: 'app-despesas',
  templateUrl: './despesas.component.html',
  styleUrls: ['./despesas.component.sass'],
  providers:[DespesasService]
  
})
export class DespesasComponent implements OnInit {
  @ViewChild('dataForm') dataForm: DespesasModalComponent;
  @ViewChild('dataList') dataList: DespesasListComponent;

  constructor( private despesaService: DespesasService ) {    
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
    this.despesaService.InsertOrUpdate(obj).subscribe(p=>{    
      this.dataList._RefreshData();
      this.dataForm.close();
    });
  }
}
