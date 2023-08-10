import { Injectable, PipeTransform } from '@angular/core';
import { BehaviorSubject, forkJoin, Observable, of, Subject } from 'rxjs';
import { DecimalPipe } from '@angular/common';
import { debounceTime, delay, flatMap, mergeMap, switchMap, tap } from 'rxjs/operators';
import { SortDirection } from './sortable.directive';
import { COUNTRIES } from './countries';



interface SearchResult {
  countries: any[];
  total: number;
}

interface State {
  page: number;
  pageSize: number;
  searchTerm: string;
  sortColumn: string;
  sortDirection: SortDirection;
}

interface greeter{
  get():Observable<any>;
}


@Injectable({ providedIn: 'root' })
export class DataGridService {

  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _results$ = new BehaviorSubject<any[]>([]);
  private _total$ = new BehaviorSubject<number>(0);  
  public filterableFields=['name','area'];

  private _state: State = {
    page: 1,
    pageSize: 4,
    searchTerm: '',
    sortColumn: '',
    sortDirection: ''
  };

  items = [];
  
  
  compare(v1, v2) {  
    return v1 < v2 ? -1 : v1 > v2 ? 1 : 0;
  }

  sort(countries: any[], column: string, direction: string): any[] {
    if (direction === '') {
      return countries;
    } else {
      return [...countries].sort((a, b) => {
        const res = this.compare(a[column], b[column]);
        return direction === 'asc' ? res : -res;
      });
    }
  }

  matches(country: any, term: string, pipe: PipeTransform) {
        let res=false;
        this.filterableFields.forEach(p=>{
          if (country[p].toString().toLowerCase().includes(term) )
          {
            res = true;
          }        
        })
        return res;      
  }


  //GUARDAR LOCAL CASO PRECISAR
  // reload():Observable<SearchResult>
  // {    
  //   return this._subscriber.get().pipe(
  //     mergeMap(data=>
  //     {
  //           this.items=data;
  //           return this._search();
  //     })      
  //   )
  // }


  Initialize()
  { 
    this._search$.pipe(
      tap(() => this._loading$.next(true)),
      debounceTime(200),
      switchMap(() => this._search()), //reload no lugar do search
      delay(200),
      tap(() => this._loading$.next(false))
    ).subscribe(result => {
      this._results$.next(result.countries);
      this._total$.next(result.total);
    });
    this._search$.next();
  }

  constructor(private pipe: DecimalPipe) {    
   
  }

  get records$() { return this._results$.asObservable(); }
  get total$() { return this._total$.asObservable(); }
  get loading$() { return this._loading$.asObservable(); }
  get page() { return this._state.page; }
  get pageSize() { return this._state.pageSize; }
  get searchTerm() { return this._state.searchTerm; }

  set page(page: number) { this._set({ page }); }
  set pageSize(pageSize: number) { this._set({ pageSize }); }
  set searchTerm(searchTerm: string) { this._set({ searchTerm }); }
  set sortColumn(sortColumn: string) { this._set({ sortColumn }); }
  set sortDirection(sortDirection: SortDirection) { this._set({ sortDirection }); }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  
  _subscriber:greeter;
  
  

  private _search(): Observable<SearchResult> {
    const { sortColumn, sortDirection, pageSize, page, searchTerm } = this._state;


    // 1. sort
    let countries = this.sort(this.items, sortColumn, sortDirection);
    
    // 2. filter    
    countries = countries.filter(country => this.matches(country, searchTerm, this.pipe));
    const total = countries.length;

    // 3. paginate
    countries = countries.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({ countries, total });
    
  }
}
