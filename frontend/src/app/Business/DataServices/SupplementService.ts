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
import { Supplement } from '../Models/supplement';

@Injectable({
    providedIn: 'root'
})

export class SupplementService extends BaseService {
          
  constructor(
    private httpClient: HttpClient,
    notificationService: NotificationService) {    
    super(notificationService);
  }

    private readonly baseUrl = environment["endPoint"];
    Page(obj: Pager) : Observable<any> {          
        return this.httpClient.post<any>(`${this.baseUrl}/Supplement/Page/`, obj);        
    }
    
    Load(id: number): Observable<Supplement> {
        const url = `${this.baseUrl}/Supplement/Load/${id}`;
        return this.httpClient.get<Supplement>(url, { headers: this.getAuthHeaders() })
          .pipe(catchError(this.handleError<Supplement>()));
  }
   
}