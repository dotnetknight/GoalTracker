import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { UserService } from 'src/app/users/user.service';
import { SnackBarService } from '../services/snackbar.service';
import { RoutingService } from '../services/routing.service';

@Injectable({ providedIn: 'root' })

export class AuthGuard implements CanActivate {

    constructor(
        private _routingService: RoutingService,
        private _userService: UserService,
        private _snackBarService: SnackBarService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (localStorage.getItem('jwt')) {
            this._userService.chaseUserAuthenticationState(true);
            return true;
        }
        this._routingService.navigate('/user/login');
        this._snackBarService.openSnackBar(["You need to be logged in to view this page"], 4000, 'center', 'center', 'error');
        return false;
    }
}
