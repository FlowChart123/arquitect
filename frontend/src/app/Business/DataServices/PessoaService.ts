import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BaseService } from '../Services/BaseService';
import { NotificationService } from '../Services/NotificationService';
import { map, catchError } from 'rxjs/operators';
import { NotificationResult } from '../Interfaces/NotificationResult';
import { createUser } from './../Models/login';
import { Pager } from '../Models/pager';
import { Pessoa } from '../Models/pessoa';




@Injectable({
    providedIn: 'root'
})

export class PessoaService extends BaseService {
          
  constructor(
    private httpClient: HttpClient,
    notificationService: NotificationService) {    
    super(notificationService);
  }

    private readonly baseUrl = environment["endPoint"];
    private readonly controller='Pessoa';

    Page(obj: Pager) : Observable<any> {          
        return this.httpClient.post<any>(`${this.baseUrl}/${this.controller}/Page/`, obj);        
    }
    
    Load(id: number): Observable<Pessoa> {
        const url = `${this.baseUrl}/${this.controller}/Load/${id}`;
        return this.httpClient.get<Pessoa>(url, { headers: this.getAuthHeaders() })
          .pipe(catchError(this.handleError<Pessoa>()));
          
    }

    InsertOrUpdate(obj: Pessoa) : Observable<any> {     
      if (obj.id ) {     
          return this.httpClient.put<any>(`${this.baseUrl}/${this.controller}/Update`, obj);
          // .pipe(catchError(this.handleError<Pessoa>()));
      }
      else{        
        return this.httpClient.post<any>(`${this.baseUrl}/${this.controller}/Insert`, obj);
        // .pipe(catchError(this.handleError<Pessoa>()));
      }
    }
   
}