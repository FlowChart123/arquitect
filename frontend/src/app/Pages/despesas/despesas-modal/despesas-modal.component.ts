import {  ChangeDetectorRef, Component, ElementRef, OnInit, Output, QueryList, TemplateRef, ViewChild, EventEmitter } from '@angular/core';
import { NgbModal,  NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

import { ContentRef } from '@ng-bootstrap/ng-bootstrap/util/popup';
import { DespesasFormComponent } from '../despesas-form/despesas-form.component';


@Component({
  selector: 'app-despesas-modal',
  templateUrl: './despesas-modal.component.html',
  styleUrls: ['./despesas-modal.component.sass']
})
export class DespesasModalComponent implements OnInit {
  @ViewChild('content', { static: true }) content: TemplateRef<NgbModal> ;
  @Output() OnSave=new EventEmitter<any>();
  form: DespesasFormComponent;

  

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
        this.title='Editar registro de despesa';         
        this.modal = this.modalService.open(this.content, {
            size: 'lg',
            windowClass:'modal-primary modal-large'
        });      
    }
    else
    {
      this.title='Adicionar registro de despesa';
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
