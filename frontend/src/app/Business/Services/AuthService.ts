
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})

export class AuthService {
    
    private user: any;

    constructor(private httpClient: HttpClient,
        private router: Router,
        private jwtService: JwtHelperService) {
    }

    

   

    UsuarioEstaAutenticado(): Promise<boolean> {
        let tokens = localStorage.getItem('token-arquitect');
        if (tokens==null) Promise.resolve(false);
        if (tokens=='') Promise.resolve(false);
        
        if (tokens!=null && tokens!="") {   
            return Promise.resolve(true);         
            // if (this.tokenExpirado(tokens)==true){                
            //     return Promise.resolve(false)
            // }
            // else{                
            //     return Promise.resolve(true)
            // }
        }        
        else{            
            return Promise.resolve(false)
        }
    }

    setToken(token: string) {
        localStorage.setItem('token-arquitect', token);        
    }


    tokenExpirado(token)
    {
        try {
        if (token && !this.jwtService.isTokenExpired(token)){
            return true;
        }
        else{
            return false;
        }
    }
    catch(e)
    {
        return false;
    }

    }

    get getToken() {
        let token = localStorage.getItem('token-arquitect');
        return token;
    }

    Logout() {        
        this.user = null;
        localStorage.setItem('token-arquitect',"");     
        this.router.navigate(["./pages/login"]);
    }

    limparDadosUsuario() {                
        localStorage.clear();
        sessionStorage.clear();
        this.Logout();
    }
}