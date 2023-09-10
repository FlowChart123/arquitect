import { Component, Input, OnInit, QueryList, ViewChildren } from '@angular/core';
import { DecimalPipe } from '@angular/common';

import { Observable, Subject, of } from 'rxjs';
// import { CountryService } from './demo/country.service';
import { Country } from './demo/country';
import { NgbdSortableHeaderDirective, SortEvent } from './demo/sortable.directive';
import { DataGridService } from './demo/datagrid.service';

import { COUNTRIES } from 'src/app/DemoPages/Tables/dynamic/demo/countries';

// @ts-ignore
@Component({
  selector: 'table-dynamic',
  templateUrl: './dynamic.component.html',
  providers: [DataGridService, DecimalPipe]
})
export class TableDynamicComponent implements OnInit {

  @Input() Title  = 'Tabela dinâmica';
    
  countries$: Observable<Country[]>;
  total$: Observable<number>;
  
  // @ts-ignore
  @ViewChildren(NgbdSortableHeaderDirective) headers: QueryList<NgbdSortableHeaderDirective>;

  constructor(
    public service: DataGridService) 
    {            
      // this.service._subscriber=this;
      this.countries$ = service.records$;
      this.total$ = service.total$;
      this.getlocal();
  }

  ngOnInit(): void {
    
  }


  getlocal()
  {
        //CARREGA OS DADOS
        let items=[];
        let cont = 100;
        COUNTRIES.forEach(p=>{
          cont++;
          let obj={
            area:p.area,
            flag:p.flag,
            id:p.id,
            name:p.name + ' - ' + cont,
            population:p.population        
          };
          items.push(obj);        
        })     
        this.service.items=items;
        this.service.Initialize();
  }

  get():Observable<any[]>
  {

     //CARREGA OS DADOS
     let items=[];
     let cont = 100;
     COUNTRIES.forEach(p=>{
       cont++;
       let obj={
         area:p.area,
         flag:p.flag,
         id:p.id,
         name:p.name + ' - ' + cont,
         population:p.population        
       };
       items.push(obj);        
     })      
   
    return of (items);
  }

  onSort({ column, direction }: SortEvent) {

    // resetting other headers
    this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.service.sortColumn = column;
    this.service.sortDirection = direction;
  }
}
