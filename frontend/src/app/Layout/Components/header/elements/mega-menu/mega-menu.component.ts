import { Component, OnInit } from '@angular/core';
import { NgbPopover } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-mega-menu',
  templateUrl: './mega-menu.component.html',
})
export class MegamenuComponent implements OnInit {
  public value = false;
  constructor() { }

  ngOnInit() {
    
  }

  hideMegamenu() {
    this.value = !this.value;
  }

}
