import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-base-page',
  templateUrl: './base-page.component.html',
  styleUrls: ['./base-page.component.sass']
})
export abstract class BasePageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  abstract Edit(l);
  abstract Adding();  
  abstract PrintContent();
  // abstract FormCallBack(obj);

  onPrintById(divName) {
    const printContents = document.getElementById(divName).innerHTML;
    const originalContents = document.body.innerHTML;
    document.body.innerHTML = printContents;
    window.print();
    document.body.innerHTML = originalContents;
 }
  onPrintByClass(className) {
    const printContents = document.getElementsByClassName(className)[0].innerHTML;
    const originalContents = document.body.innerHTML;
    document.body.innerHTML = printContents;
    window.print();
    document.body.innerHTML = originalContents;
  }

}
