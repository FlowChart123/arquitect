import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal,  ModalDismissReasons, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-rush-form',
  templateUrl: './rush-form.component.html',
  styleUrls: ['./rush-form.component.sass']
})
export class RushFormComponent implements OnInit {
  @ViewChild('content', { static: true }) content: any;
  
  private modal: NgbModalRef;
  title='Suplemento';

  constructor(private modalService: NgbModal) { }
  ngOnInit(): void {
  }

  
  open(id) {
    this.title='Editar Suplemento';
    this.modalService.open(this.content, {
      size: 'lg',
      windowClass:'modal-primary modal-large'
    });
  }
  

}
