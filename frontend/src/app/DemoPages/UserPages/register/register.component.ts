import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Business/DataServices/LoginService';
import { ConfirmValidator } from 'src/app/Business/Validators/ConfirmValidator';
import { GenericValidator } from 'src/app/Business/Validators/CpfValidator';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: [],
  providers:[GenericValidator, LoginService]
})
export class RegisterComponent implements OnInit {
  
  slideConfig2 = {
    className: 'center',
    centerMode: true,
    infinite: true,
    centerPadding: '0',
    slidesToShow: 1,
    speed: 500,
    dots: false,
  };

  myForm: FormGroup;  
  constructor(private fb: FormBuilder,
    private loginService: LoginService,
    private router: Router  ) {    
  }

  checkPasswords: ValidatorFn = (group: AbstractControl):  ValidationErrors | null => { 
    let pass = group.get('password').value;
    let confirmPass = group.get('confirmPassword').value
    return pass === confirmPass ? null : { notSame: true }
  }

  ngOnInit() {
    

    this.myForm = this.fb.group({
      cpf:['',[Validators.required, GenericValidator.isValidCpf()]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
      confirmPassword: ['']
    }, { validators: [ConfirmValidator('password','confirmPassword')]   })

  }

  

  get f(){
    return this.myForm.controls;
  }


  Save()
  {
    if (this.myForm.valid==true){
      let data = this.myForm.value;
      this.loginService.createUser(data).subscribe(p=>
        {
          console.log(p);
          this.router.navigate(["login"]);
        })
    }
  }
}
