import { DecimalPipe } from '@angular/common';
import { AfterViewInit, Component, OnInit, QueryList, ViewChildren, ChangeDetectorRef } from '@angular/core';
import { BehaviorSubject, Observable, Subject, of } from 'rxjs';
import { debounceTime, delay, delayWhen, switchMap, tap } from 'rxjs/operators';
import { Pager } from 'src/app/Business/Models/pager';
import { SearchResultGrid } from 'src/app/Business/Models/search-result-grid';
import { COUNTRIES } from 'src/app/DemoPages/Tables/dynamic/demo/countries';
import { DtHeaderDirective } from './dt-header.directive';
import { EventEmitterService } from 'src/app/Business/Services/EventEmitterService';



@Component({
  selector: 'app-datagrid',
  templateUrl: './datagrid.component.html',
  styleUrls: ['./datagrid.component.sass'],
  providers: [DecimalPipe]

})

export abstract class DatagridComponent implements OnInit {

  protected _searchTerm;
  private _sortColuumn; //TODO>> Implementar
  private _sortDirection;


  _pageSize = 10;
  _page = 1;
  _stateEdit=false;

  data=[];

  private _search$ = new Subject<void>();
  private _results$ = new BehaviorSubject<any[]>([]);
  private _total$ = new BehaviorSubject<number>(0);
  private _loading$ = new BehaviorSubject<boolean>(true);

  private _order="";
  private _dir="";

  get records$() { return this._results$.asObservable(); }
  get total$() { return this._total$.asObservable(); }
  get searchTerm() { return this._searchTerm; }
  get loading$() { return this._loading$.asObservable(); }
  get pageSize() { return this._pageSize; }
  get page() { return this._page }

  set searchTerm(searchTerm: string) { this._searchTerm = searchTerm; this._search$.next(); }
  set pageSize(pageSize: number) { this._pageSize = pageSize; this._search$.next(); }
  set page(page: number) { this._page = page; this._search$.next(); }
  set sortColumn(sortColumn: string) { this._sortColuumn = sortColumn }
  set sortDirection(sortDirection: string) { this._sortDirection = sortDirection }


  constructor() {
    this.Initialize();
  }

  dataRaw=[];
  

  ngOnInit(): void { }

  Initialize() {
    this._search$.pipe(
      tap(() => this._loading$.next(true)),
      debounceTime(200),
      switchMap(() => this._search(this._order,this._dir)),
      delay(200),
      tap(() => this._loading$.next(false))
    ).subscribe(result => {      
      this._results$.next(result.items);
      this._total$.next(result.total);
    });
    this._search$.next();

  }

  _RefreshData()
  {    
    this._search$.next();
  }

  _toggleSelection()
  {
   this._stateEdit=!this._stateEdit;
  }
  
  selecteds()
  {
    return this.data.filter(p=> {return p._selected==true});
  }

  
  refresh()
  {
    this._RefreshData();
  }


  _sort(evt)
  {
    this._order=evt.column;
    this._dir=evt.direction;
    this._search$.next();
    EventEmitterService.get('sort').emit(evt);
  }

  abstract _search(orderby:string,orderdir:string): Observable<SearchResultGrid>;
  abstract _edit(obj:any);
  abstract _remove(obj:any);



}
