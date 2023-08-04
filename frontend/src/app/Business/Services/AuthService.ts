
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
    providedIn: 'root'
})

export class AuthService {
    private usuarioAutenticadoPortal: boolean = false;
    private token: any;
    private user: any;

    constructor(private httpClient: HttpClient,
        private jwtService: JwtHelperService) {
    }

    checkToken() {
        return Promise.resolve(true);
    }

    UsuarioAutenticado(status: boolean) {
        localStorage.setItem('user-arquitect', JSON.stringify(status));
        
        this.usuarioAutenticadoPortal = status;
    }

    UsuarioEstaAutenticado(): Promise<boolean> {
        this.usuarioAutenticadoPortal = localStorage.getItem('user-arquitect') == 'true';
        // return Promise.resolve(false);
        return Promise.resolve(this.usuarioAutenticadoPortal);
    }

    setToken(token: string) {
        localStorage.setItem('token-arquitect', token);
        this.token = token;
    }


    tokenExpirado()
    {
        try {
            const token = localStorage.getItem("token-arquitect");        
            if (token==null) return true;
            if (token && !this.jwtService.isTokenExpired(token)){
                return true;
            }
            else{
                return false;
            }
        }
        catch(e)
        {
            return true;
        }

    }

    get getToken() {
        this.token = localStorage.getItem('token-arquitect');
        return this.token;
    }

    limparToken() {
        this.token = null;
        this.user = null;
    }

    limparDadosUsuario() {
        this.UsuarioAutenticado(false);
        this.limparToken();
        localStorage.clear();
        sessionStorage.clear();
    }



}