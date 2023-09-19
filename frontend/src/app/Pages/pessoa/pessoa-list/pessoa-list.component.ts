import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Pager } from 'src/app/Business/Models/pager';
import { SearchResultGrid } from 'src/app/Business/Models/search-result-grid';
import { DatagridComponent } from 'src/app/Components/datagrid/datagrid.component';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';
import { PessoaService } from 'src/app/Business/DataServices/PessoaService';



@Component({
  selector: 'app-pessoa-list',
  templateUrl: './pessoa-list.component.html',
  styleUrls: ['./pessoa-list.component.sass'],
  providers: [PessoaService]
  
})
export class PessoaListComponent extends DatagridComponent implements OnInit {  


  //Inicializar o subject record$.subscribe(()) para trazer o registros
  constructor(
    private _supService: PessoaService
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
    
    let tmp = { items: [], total: 0 } as SearchResultGrid;
    let searcht = this._searchTerm != undefined ? this._searchTerm : '';
    let input = { page: this._page, size: this._pageSize, orderBy: order, orderDirection: dir, search: searcht } as Pager;
    this._supService.Page(input).subscribe(p => {
      tmp.total = p.totalItems;
      p.items.forEach(x => {
        x._selected=false;
        tmp.items.push(x);
      })
      console.log(p);
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
      let selecionados = this.data.filter(p=>{
        return p._selected==true;
      });
      console.group(selecionados);

      let ids=[];
      selecionados.forEach(p=>{
        ids.push(p.id);
      });
      console.log(ids);
      this._supService.Delete(ids).subscribe(p=>{
        console.log(p);
        this.refresh();
      })
  }

  

  /********************************************* */
}
