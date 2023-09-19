import { Component, OnInit, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-left-toolbox-form',
  templateUrl: './left-toolbox-form.component.html',
  styleUrls: ['./left-toolbox-form.component.sass']
})
export class LeftToolboxFormComponent implements OnInit {
  @Output() OnAdding = new EventEmitter<any>();
  @Output() OnPrint = new EventEmitter<any>();
  constructor() { }

  ngOnInit(): void {
  }

  Adding()
  {
    this.OnAdding.emit();
  }
  PrintContent()
  {
    this.OnPrint.emit();
  }
}
