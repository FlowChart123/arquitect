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
import { SistemaFinanceiro } from '../Models/sistema-financeiro';



@Injectable({
    providedIn: 'root'
})

export class SistemaFinanceiroService extends BaseService {
          
  constructor(
    private httpClient: HttpClient,
    notificationService: NotificationService) {    
    super(notificationService);
  }

    private readonly baseUrl = environment["endPoint"];
    private readonly controller='SistemaFinanceiro';

    Page(obj: Pager) : Observable<any> {          
        return this.httpClient.post<any>(`${this.baseUrl}/${this.controller}/Page/`, obj);        
    }
    
    Load(id: number): Observable<SistemaFinanceiro> {
        const url = `${this.baseUrl}/${this.controller}/Load/${id}`;
        return this.httpClient.get<SistemaFinanceiro>(url, { headers: this.getAuthHeaders() })
          .pipe(catchError(this.handleError<SistemaFinanceiro>()));
          
    }

    InsertOrUpdate(obj: SistemaFinanceiro) : Observable<any> {     
      if (obj.id && obj.id>0) {     
          return this.httpClient.put<any>(`${this.baseUrl}/${this.controller}/Update`, obj)
          .pipe(catchError(this.handleError<SistemaFinanceiro>()));
      }
      else{        
        return this.httpClient.post<any>(`${this.baseUrl}/${this.controller}/Insert`, obj)
        .pipe(catchError(this.handleError<SistemaFinanceiro>()));
      }
    }
   
}