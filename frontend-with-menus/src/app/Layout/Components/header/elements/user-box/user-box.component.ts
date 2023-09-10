import { Component, OnInit } from '@angular/core';
import { faCalendar } from '@fortawesome/free-solid-svg-icons';
import { ThemeOptions } from '../../../../../theme-options';
import { AuthService } from 'src/app/Business/Services/AuthService';

@Component({
  selector: 'app-user-box',
  templateUrl: './user-box.component.html',
})
export class UserBoxComponent implements OnInit {

  faCalendar = faCalendar;

  toggleDrawer() {
    this.globals.toggleDrawer = !this.globals.toggleDrawer;
  }

  constructor(public globals: ThemeOptions,
    private authService: AuthService) {
  }

  ngOnInit() {
  }

  Logout()
  {
    this.authService.Logout();
  }

}
