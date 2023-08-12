import {  EventEmitter, Component, Input, OnInit, Output } from '@angular/core';
import { SupplementService } from 'src/app/Business/DataServices/SupplementService';
import { Supplement } from 'src/app/Business/Models/supplement';




@Component({
  selector: 'app-rush-form',
  templateUrl: './rush-form.component.html',
  styleUrls: ['./rush-form.component.sass'],
  providers: [SupplementService]
})
export class RushFormComponent implements OnInit {
  
  @Output()  init= new EventEmitter<any>();

  constructor(
    private supplementService: SupplementService
  ) { }
  model:Supplement;

  ngOnInit(): void {
    this.init.emit(this);
  }
  elementId:any;
  
  Initialize(id : any){    
    if (id && id!=''){
      this.elementId=id;
      this._get_record(id)
    }
  }

  _get_newModel()
  {
    return {
      name:'',
      id:null      
    } as Supplement;
  }
  _get_record(id)
  {
      this.supplementService.Load(this.elementId).subscribe(p=>{
        console.log('registro:',p);
      })
  }

}
