import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Business/DataServices/LoginService';
import { AuthService } from 'src/app/Business/Services/AuthService';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {

  slideConfig2 = {
    className: 'center',
    centerMode: true,
    infinite: true,
    centerPadding: '0',
    slidesToShow: 1,
    speed: 500,
    dots: true,
  };

  constructor(public formBuilder: FormBuilder,
    private router: Router,
    private loginService: LoginService,
    public authService: AuthService) {

  }

  loginForm: FormGroup;
  loading=false;

  ngOnInit(): void {

    this.loginForm = this.formBuilder.group
      (
        {
          email: ['', [Validators.required, Validators.email]],
          senha: ['', [Validators.required]]
        }
      )
  }

  get dadosForm() {
    return this, this.loginForm.controls;
  }


  loginUser() {

    this.loading = true;
    this.loginService.login(this.dadosForm["email"].value, this.dadosForm["senha"].value, this.Error).subscribe(
      token => {      
        this.authService.setToken(token);
        this.router.navigate(['/']);        
      },
      err => {        
        this.loading = false;
        console.log(err);
      }

    )

  }

  Error()
  {
    this.loading=false;
  }

}
