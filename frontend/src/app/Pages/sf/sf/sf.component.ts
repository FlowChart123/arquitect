import { Component, OnInit, ViewChild } from '@angular/core';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { SFModalComponent } from './sf-modal/sf-modal.component';
import { SFListComponent } from './sf-list/sf-list.component';
import { SistemaFinanceiroService } from 'src/app/Business/DataServices/SistemaFinanceiroService';


@Component({
  selector: 'app-sf',
  templateUrl: './sf.component.html',
  styleUrls: ['./sf.component.sass'],
  providers:[SistemaFinanceiroService]
  
})
export class SFComponent implements OnInit {
  @ViewChild('dataForm') dataForm: SFModalComponent;
  @ViewChild('dataList') dataList: SFListComponent;

  constructor( private principalService: SistemaFinanceiroService ) {    
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
