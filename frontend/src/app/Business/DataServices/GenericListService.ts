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

export class GenericListService extends BaseService {
          
  constructor(
    private httpClient: HttpClient,
    notificationService: NotificationService) {    
    super(notificationService);
  }

    private readonly baseUrl = environment["endPoint"];
    

    Get(method: string,params:string): Observable<any> {
        const url = `${this.baseUrl}/GenericList/${method}/${params}`;
        return this.httpClient.get<any>(url, { headers: this.getAuthHeaders() })
          .pipe(catchError(this.handleError<Supplement>()));    
    }
   Meses()
   {
    const m=[
      {id:1,name:'Janeiro'},{id:2,name:'Fevereiro'},{id:3,name:'Março'},{id:4,name:'Abril'},
      {id:5,name:'Maio'},{id:6,name:'Junho'},{id:7,name:'Julho'},{id:8,name:'Agosto'},
      {id:9,name:'Setembro'},{id:10,name:'Outubro'},{id:11,name:'Novembro'},{id:12,name:'Dezembro'},
    ];
    return m;
   }

   TiposDespesa()
   {
    const m=[
      {id:1,name:'Despesa tipo 1'},{id:2,name:'Despesa tipo 2'}
    ];
    return m;
   }
}