import {  ChangeDetectorRef, Component, ElementRef, OnInit, Output, QueryList, TemplateRef, ViewChild, EventEmitter } from '@angular/core';
import { NgbModal,  NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

import { ContentRef } from '@ng-bootstrap/ng-bootstrap/util/popup';
import { SFFormComponent } from '../sf-form/sf-form.component';


@Component({
  selector: 'app-sf-modal',
  templateUrl: './sf-modal.component.html',
  styleUrls: ['./sf-modal.component.sass']
})
export class SFModalComponent implements OnInit {
  @ViewChild('content', { static: true }) content: TemplateRef<NgbModal> ;
  @Output() OnSave=new EventEmitter<any>();
  form: SFFormComponent;

  

  private modal: NgbModalRef;
  title='Despesa';

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
        this.title='Editar registro - sistema financeiro';         
        this.modal = this.modalService.open(this.content, {
            size: 'lg',
            windowClass:'modal-primary modal-large'
        });      
    }
    else
    {
      this.title='Adicionar registro - sistema financeiro';
      this.modal = this.modalService.open(this.content, {
        size: 'lg',
        windowClass:'modal-primary modal-large'
    });    
    }                   
  }  

  close()
  {
    this.modal.close();
  }

  initForm(frm)
  {
    this.form=frm;
    this.form.Initialize(this.elementId);
  }

  save()
  {
    let f = this.form.form;    
    this.form.submitted=true;    
    if (f.valid==true) {
      let vr=f.value;       
      this.OnSave.emit(vr);
      }
  }
}
