import { Component, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/users/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy {
  isAuth = false;
  authSubscription: Subscription;
  @Output() sidenavToggle = new EventEmitter<void>();

  constructor(private _userService: UserService) { }

  ngOnInit() {
    this.authSubscription = this._userService.isAuthSubject
      .subscribe(authState => {
        this.isAuth = authState
      });
  }

  onToggleSidenav() {
    this.sidenavToggle.emit();
  }

  ngOnDestroy() {
    this.authSubscription.unsubscribe();
  }
}