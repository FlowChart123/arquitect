import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BaseService } from '../Services/BaseService';
import { NotificationService } from '../Services/NotificationService';
import { map, catchError } from 'rxjs/operators';
import { NotificationResult } from '../Interfaces/NotificationResult';
import { createUser } from './../Models/login';

@Injectable({
    providedIn: 'root'
})

export class LoginService extends BaseService {
      
    
  constructor(
    private httpClient: HttpClient,
    notificationService: NotificationService) {    
    super(notificationService);
  }

    private readonly baseUrl = environment["endPoint"];

    login(Email: string, Password: string, onerr) : Observable<any> {          
        return this.httpClient.post<any>(`${this.baseUrl}/CreateToken`, { Email: Email, Password: Password })
        .pipe(catchError(this.handleError<NotificationResult>(null,null,onerr)));
    }

    createUser(obj: createUser) : Observable<any> {          
        return this.httpClient.post<any>(`${this.baseUrl}/AdicionaUsuario`, obj);        
    }
   
}