import { Component, OnInit } from '@angular/core';
import { UserService } from '../users/user.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  constructor(private _userService: UserService) { }

  ngOnInit() {
    if (localStorage.getItem('jwt')) {
      this._userService.chaseUserAuthenticationState(true);
    }
  }

}
