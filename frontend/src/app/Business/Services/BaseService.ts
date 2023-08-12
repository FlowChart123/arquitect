import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { environment } from './../../../environments/environment';
import { Observable, of } from 'rxjs';
import { NotificationService } from './NotificationService';
import { TokenAuthentication } from '../Models/token-authentication';


@Injectable()
export class BaseService {
    
    constructor(
        private notificationService: NotificationService,    
      ) { }
    
  public handleError<T>(operation = 'operation', result?: T, next?:Function) {    
    return (error: any): Observable<T> => {
      console.error(error); // log to console instead
      console.log(`${operation} failed: ${error.message}`);
      var x = error.message + " ";
      
      if (x.indexOf("401") > -1) {        
        this.notificationService.openToast("Favor logue no sistema .", "Logar","error");       
      }
      else
      {
        this.notificationService.openToast(error.message, "Ops!","error");         
        if (next!=null)
        {
          next();
        }
      }
      return of(result as T);
    };
  }

  
  protected getAuthHeaders(apiVersion = '1.0'): HttpHeaders {
    let headers = this.getHeaders(apiVersion);
    const authentication = this.getAuthentication();

    if (authentication) {
      headers = headers.set('Authorization', `Bearer ${authentication.access_token}`);
    }

    return headers;
  }

  
  
  protected getHeaders(apiVersion = '1.0'): HttpHeaders {
    const headers = new HttpHeaders()
      .set('Accept', 'application/json')            
    return headers;
  }
  
  protected getAuthentication(): TokenAuthentication {
    const key = 'authentication';
    let authentication: TokenAuthentication = JSON.parse(localStorage.getItem(key));

    if (!authentication) {
      authentication = JSON.parse(sessionStorage.getItem(key));
    }

    return authentication;
  }

  protected setAuthentication(authentication: TokenAuthentication, remember: boolean) {
    const key = 'authentication';

    if (remember) {
      localStorage.setItem(key, JSON.stringify(authentication));
    } else {
      sessionStorage.setItem(key, JSON.stringify(authentication));
    }
  }

  
}