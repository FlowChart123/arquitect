import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Pager } from 'src/app/Business/Models/pager';
import { SearchResultGrid } from 'src/app/Business/Models/search-result-grid';
import { DatagridComponent } from 'src/app/Components/datagrid/datagrid.component';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { CategoriaService } from 'src/app/Business/DataServices/CategoriaService';



@Component({
  selector: 'app-categoria-list',
  templateUrl: './categoria-list.component.html',
  styleUrls: ['./categoria-list.component.sass'],
  providers: [CategoriaService]
  
})
export class CategoriaListComponent extends DatagridComponent implements OnInit {  


  //Inicializar o subject record$.subscribe(()) para trazer o registros
  constructor(
    private _supService: CategoriaService
    ) {
    super();
    
    super.records$.subscribe(p=>{
      this.data=p;
    })

  }
  

  _search(orderby:string,orderdir:string): Observable<SearchResultGrid> {
    //Em caso de vaios retornos utilizar o mergeMap!.
    let order=orderby == "" ? "nome":orderby;
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
    this.OnEdit.emit(l);    
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
