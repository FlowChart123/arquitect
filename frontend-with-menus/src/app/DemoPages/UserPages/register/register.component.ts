import { ElementSchemaRegistry } from '@angular/compiler';
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
  loading=false;

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
      senha: ['', [Validators.required]],
      confirmPassword: ['']
    }, { validators: [ConfirmValidator('senha','confirmPassword')]   })

  }

  

  get f(){
    return this.myForm.controls;
  }
  

  customErrors=[
    {id:'PasswordTooShort',desc:'Senha muito curta, use ao menos 6 caracteres'},
    {id:'PasswordRequiresLower',desc:'Senha requer ao menos um caracter minúsculo'},
  ]

  errors=[];
  Save()
  {    
    this.errors=[];
    if (this.myForm.valid==true){
      let data = this.myForm.value;  
      this.loading=true;    
      this.loginService.createUser(data).subscribe(p=>
        {          
          //console.log(p);               
          if (p.status==false){
            p.messages.forEach(p=>{
              this.customErrors.forEach(ce=>{
                  if (ce.id==p.code){
                    this.errors.push(ce);
                  }
              });              
            });
            this.loading=false;
          } else {
            this.router.navigate(["pages/login"]);       
          }                                   
          this.loading=false;      
        }, onerr=>{
          this.loading=false;
        })        
    }
  }

  

}
