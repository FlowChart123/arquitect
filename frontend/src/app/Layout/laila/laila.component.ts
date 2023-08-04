import { Component, OnInit } from '@angular/core';
import { NotificationService } from 'src/app/Business/Services/NotificationService';
import { QueryList, Renderer2, ViewChildren, VERSION } from '@angular/core';

@Component({
  selector: 'app-laila',
  templateUrl: './laila.component.html',
  styleUrls: ['./laila.component.sass'],  
})
export class LailaComponent implements OnInit {

  constructor(
    private nota: NotificationService
  ) { }

  ngOnInit(): void {
  }

  Notificar()
  {
    this.nota.openToast("O registro foi atualizado com sucesso","Atualizado!",'success');
  }

}
