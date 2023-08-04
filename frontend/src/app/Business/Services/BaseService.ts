import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { environment } from './../../../environments/environment';
import { Observable, of } from 'rxjs';
import { NotificationService } from './NotificationService';


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
}