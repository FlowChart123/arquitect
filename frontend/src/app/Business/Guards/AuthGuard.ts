
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, UrlTree, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../Services/AuthService';



@Injectable(
  {
    providedIn:'root',    
  }
)
export class AuthGuard implements CanActivate {
    constructor(private authService: AuthService
        , private router: Router) { }


        canActivate(
            next: ActivatedRouteSnapshot,
            state: RouterStateSnapshot
          ):
            | Observable<boolean | UrlTree>
            | Promise<boolean | UrlTree>
            | boolean
            | UrlTree {
            return new Promise(resolve =>        
              {      
              this.authService.UsuarioEstaAutenticado().then(status => {
                 // let redirect: string = state.root.queryParams['returnUrl'];

                // let redirect = "/";
                let blnUnAuthorize = false;                  
                
                 //validation
                 if (status === false)
                   blnUnAuthorize = true;
       
                 //redirect
                //  if (blnUnAuthorize ) {                                                  
                //    this.router.navigate(["./pages/login", { queryParams: { returnUrl: state.url }}]);
                //  }
                if (blnUnAuthorize) {                          
                    this.router.navigate(["./pages/login"],{ queryParams: { returnUrl: state.url }});
                 }
                 else{
                  //this.router.navigate([state.url]);
                 }
       
                 resolve(status);
               }
               
               )
                 .catch(() => {                    
                   this.router.navigate(["login"]);
                   resolve(false);
                 })
             

          });
        }
}