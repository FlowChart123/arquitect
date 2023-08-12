import {  ChangeDetectorRef, Component, ElementRef, OnInit, QueryList, TemplateRef, ViewChild, ViewChildren } from '@angular/core';
import { NgbModal,  NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { RushFormComponent } from '../rush-form/rush-form.component';
import { ContentRef } from '@ng-bootstrap/ng-bootstrap/util/popup';

@Component({
  selector: 'app-rush-modal',
  templateUrl: './rush-modal.component.html',
  styleUrls: ['./rush-modal.component.sass']
})
export class RushModalComponent implements OnInit {
  @ViewChild('content', { static: true }) content: TemplateRef<NgbModal> ;
  form: RushFormComponent;

  

  private modal: NgbModalRef;
  title='Suplemento';

  constructor(
    private modalService: NgbModal,   
    private detector: ChangeDetectorRef 
    ) { }
  ngOnInit(): void {
  }

 
  elementId:any;
  open(id) {
    this.elementId=id;
    if (id!=undefined && id!='') {      
        this.title='Editar Suplemento';         
        this.modal = this.modalService.open(this.content, {
            size: 'lg',
            windowClass:'modal-primary modal-large'
        });      
    }
    else
    {
      this.title='Adicionar Suplemento';
    }                   
  }  

  initForm(frm)
  {
    this.form=frm;
    this.form.Initialize(this.elementId);
  }
}
