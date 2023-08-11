
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-laila',
  templateUrl: './laila.component.html',
  styleUrls: ['./laila.component.sass'],  
}) 
export class LailaComponent implements OnInit {
  ngOnInit(): void {
    
  }
  heading = 'Bootstrap 5 Tables';
  subheading = 'Tables are the backbone of almost all web applications.';
  icon = 'pe-7s-drawer icon-gradient bg-happy-itmeo';
}


