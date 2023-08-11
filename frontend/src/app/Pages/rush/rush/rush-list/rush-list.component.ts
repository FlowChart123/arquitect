import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable, of } from 'rxjs';
import { SupplementService } from 'src/app/Business/DataServices/SupplementService';
import { Pager } from 'src/app/Business/Models/pager';
import { SearchResultGrid } from 'src/app/Business/Models/search-result-grid';
import { DatagridComponent } from 'src/app/Components/datagrid/datagrid.component';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';


@Component({
  selector: 'app-rush-list',
  templateUrl: './rush-list.component.html',
  styleUrls: ['./rush-list.component.sass'],
  providers: [SupplementService]
})
export class RushListComponent extends DatagridComponent implements OnInit {

  

  data=[];
  constructor(
    private _supService: SupplementService
    ) {
    super();
    
    super.records$.subscribe(p=>{
      this.data=p;
    })
  }
  

  _search(): Observable<SearchResultGrid> {
    //Em caso de vaios retornos utilizar o mergeMap!.
    let tmp = { items: [], total: 0 } as SearchResultGrid;
    let searcht = this._searchTerm != undefined ? this._searchTerm : '';
    let input = { page: this._page, size: this._pageSize, orderBy: 'name', orderDirection: 'asc', search: searcht } as Pager;
    this._supService.Page(input).subscribe(p => {
      tmp.total = p.totalItems;
      p.items.forEach(x => {
        x._selected=false;
        tmp.items.push(x);
      })
    })
    return of(tmp);
  }
 


  /************ AÇÕES DE INTERAÇÃO ************ */  
  stateEdit=false;
  toggleSelection()
  {
    this.stateEdit=!this.stateEdit;
  }
  ngOnInit(): void {
  }

  selecteds()
  {
    return this.data.filter(p=> {return p._selected==true});
  }

  edit(l)
  {
    EventEmitterService.get('edit').emit(l);    
  }

  refresh()
  {
    super._RefreshData();
  }

  Remove()
  {  
  }

  /********************************************* */
}
