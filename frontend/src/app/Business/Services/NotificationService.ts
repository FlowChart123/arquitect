import { QueryList, Renderer2, ViewChildren, VERSION, Component } from '@angular/core';
import { cloneDeep, random } from 'lodash-es';
import { Injectable } from '@angular/core';

import {
    GlobalConfig,
    ToastrService,
    
  } from 'ngx-toastr';

  
import Swal from 'sweetalert2';

enum alertTypesEnum{
    success,
    error,
    info,
    warning
}
const types = ['success', 'error', 'info', 'warning'];
  
@Injectable({
    providedIn: 'root'
})

export class NotificationService {   
    constructor(public toastr: ToastrService) {      
        this.options = this.toastr.toastrConfig;  
    }

    
    
  heading = 'Toastr Alerts';
  subheading = 'Notifications represent one of the best ways to give feedback for various users actions.';
  icon = 'pe-7s-glasses icon-gradient bg-love-kiss';

  options: GlobalConfig;
  title = '';
  message = '';
  version = VERSION;
  enableBootstrap = false;
  private lastInserted: number[] = [];
  inline = false;
  inlinePositionIndex = 0;
    
  types = ['success', 'error', 'info', 'warning'];
  type = types[0];
  

  openToast(message: string, title: string, alertType: string) {        
        
    // Clone current config so it doesn't change when ngModel updates
    

    const opt = cloneDeep(this.options);
    const inserted = this.toastr.show(
      message,
      title,
      opt,
      this.options.iconClasses[alertType],
    );
    if (inserted) {
      this.lastInserted.push(inserted.toastId);
    }
    return inserted;
  }


  clearToasts() {
    this.toastr.clear();
  }

  clearLastToast() {
    this.toastr.clear(this.lastInserted.pop());
  }

  fixNumber(field: string) {
    this.options[field] = Number(this.options[field]);
  }

  setClass(enableBootstrap: boolean) {
    const add = enableBootstrap ? 'bootstrap' : 'normal';
    const remove = enableBootstrap ? 'normal' : 'bootstrap';
    // this.renderer.addClass(document.body, add);
    // this.renderer.removeClass(document.body, remove);
  }

  swalSuccess() {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: 'Your work has been saved',
      showConfirmButton: false,
      timer: 1500
    });
  }

  swalInfo() {
    Swal.fire({
      title: '<strong>HTML <u>example</u></strong>',
      icon: 'info',
      html:
        'You can use <b>bold text</b>, ' +
        '<a href="//sweetalert2.github.io">links</a> ' +
        'and other HTML tags',
      showCloseButton: true,
      showCancelButton: true,
      focusConfirm: false,
      confirmButtonText:
        '<i class="fa fa-thumbs-up"></i> Great!',
      confirmButtonAriaLabel: 'Thumbs up, great!',
      cancelButtonText:
        '<i class="fa fa-thumbs-down"></i>',
      cancelButtonAriaLabel: 'Thumbs down'
    });
  }
  
  swalWarning() {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You wont be able to revert this!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        Swal.fire(
          'Deleted!',
          'Your file has been deleted.',
          'success'
        );
      }
    });
  }
  swalError() {
    Swal.fire({
      icon: 'error',
      title: 'Oops...',
      text: 'Something went wrong!',
      footer: '<a href>Why do I have this issue?</a>'
    });
  }
  swalConfirm() {
    const swalWithBootstrapButtons = Swal.mixin({
      customClass: {
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger'
      },
      buttonsStyling: false
    });

    swalWithBootstrapButtons.fire({
      title: 'Are you sure?',
      text: 'You wont be able to revert this!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, cancel!',
      reverseButtons: true
    }).then((result) => {
      if (result.value) {
        swalWithBootstrapButtons.fire(
          'Deleted!',
          'Your file has been deleted.',
          'success'
        );
      } else if (
        /* Read more about handling dismissals below */
        result.dismiss === Swal.DismissReason.cancel
      ) {
        swalWithBootstrapButtons.fire(
          'Cancelled',
          'Your imaginary file is safe :)',
          'error'
        );
      }
    });
  }
  inputValidation() {
    Swal.fire({
      title: 'Submit your Github username',
      input: 'text',
      inputAttributes: {
        autocapitalize: 'off'
      },
      showCancelButton: true,
      confirmButtonText: 'Look up',
      showLoaderOnConfirm: true,
      preConfirm: (login) => {
        return fetch(`//api.github.com/users/${login}`)
          .then(response => {
            if (!response.ok) {
              throw new Error(response.statusText);
            }
            return response.json();
          })
          .catch(error => {
            Swal.showValidationMessage(
              `Request failed: ${error}`
            );
          });
      },
      allowOutsideClick: () => !Swal.isLoading()
    }).then((result) => {
      if (result.value) {
        Swal.fire({
          title: `${result.value.login}'s avatar`,
          imageUrl: result.value.avatar_url
        });
      }
    });
  }

}