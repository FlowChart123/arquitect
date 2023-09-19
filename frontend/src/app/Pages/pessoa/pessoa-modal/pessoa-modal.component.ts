import {  ChangeDetectorRef, Component, ElementRef, OnInit, Output, QueryList, TemplateRef, ViewChild, EventEmitter } from '@angular/core';
import { NgbModal,  NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

import { ContentRef } from '@ng-bootstrap/ng-bootstrap/util/popup';
import { PessoaFormComponent } from '../pessoa-form/pessoa-form.component';


@Component({
  selector: 'app-pessoa-modal',
  templateUrl: './pessoa-modal.component.html',
  styleUrls: ['./pessoa-modal.component.sass']
})
export class PessoaModalComponent implements OnInit {
  @ViewChild('content', { static: true }) content: TemplateRef<NgbModal> ;
  @Output() OnSave=new EventEmitter<any>();
  form: PessoaFormComponent;

  

  private modal: NgbModalRef;
  title='Pessoas';

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
        this.title='Editar registro - Pessoas';         
        this.modal = this.modalService.open(this.content, {
            size: 'lg',
            windowClass:'modal-primary modal-large'
        });      
    }
    else
    {
      this.title='Adicionar registro - Pessoas';
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
    this.form.Initialize(frm.id);
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
