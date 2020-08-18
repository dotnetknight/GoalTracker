import { Component, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/users/user.service';
import { SnackBarService } from 'src/app/_shared/services/snackbar.service';
import { RoutingService } from 'src/app/_shared/services/routing.service';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SidenavComponent implements OnInit, OnDestroy {
  isAuth = false;
  authSubscription: Subscription;
  @Output() sidenavToggle = new EventEmitter<void>();

  constructor(private _userService: UserService, private _routingService: RoutingService, private _snackbarService: SnackBarService) { }


  ngOnInit() {
    this.authSubscription = this._userService.isAuthSubject
      .subscribe(authState => {
        this.isAuth = authState
      });
  }

  ngOnDestroy() {
    this.authSubscription.unsubscribe();
  }

  close() {
    if (window.innerWidth < 500) {
      this.sidenavToggle.emit();
    }
  }

  onLogout() {
    this._userService.logout();
  }
}