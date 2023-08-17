import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Pager } from 'src/app/Business/Models/pager';
import { SearchResultGrid } from 'src/app/Business/Models/search-result-grid';
import { DatagridComponent } from 'src/app/Components/datagrid/datagrid.component';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { CodigoBarraService } from 'src/app/Business/DataServices/CodigoBarraService';



@Component({
  selector: 'app-codigobarra-list',
  templateUrl: './codigobarra-list.component.html',
  styleUrls: ['./codigobarra-list.component.sass'],
  providers: [CodigoBarraService]
  
})
export class CodigoBarraListComponent extends DatagridComponent implements OnInit {  


  //Inicializar o subject record$.subscribe(()) para trazer o registros
  constructor(
    private _supService: CodigoBarraService
    ) {
    super();
    
    super.records$.subscribe(p=>{
      this.data=p;
    })

  }
  

  _search(orderby:string,orderdir:string): Observable<SearchResultGrid> {
    //Em caso de vaios retornos utilizar o mergeMap!.
    let order=orderby == "" ? "codigobarras":orderby;
    let dir=orderdir == "" ? "asc":orderdir;

    console.log(order,dir);
    let tmp = { items: [], total: 0 } as SearchResultGrid;
    let searcht = this._searchTerm != undefined ? this._searchTerm : '';
    let input = { page: this._page, size: this._pageSize, orderBy: order, orderDirection: dir, search: searcht } as Pager;
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
  


  ngOnInit(): void {
    
  }


  _edit(l)
  {
    EventEmitterService.get('edit').emit(l);    
  }


  _remove(obj)
  {  
      if (obj==null)
      {
        //remover items selecionados
      }
      else{
        //remover item específico
      }
  }



  /********************************************* */
}
