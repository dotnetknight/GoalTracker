import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { SnackBarService } from '../services/snackbar.service';

@Injectable({ providedIn: 'root' })

export class LoginGuard implements CanActivate {

    constructor(private router: Router, private _snackBarService: SnackBarService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (localStorage.getItem('jwt')) {
            this.router.navigate(['/sample'], { queryParams: { returnUrl: state.url } });
            this._snackBarService.openSnackBar(["You are already logged in"], 4000, "center", "center", 'error');
            return false;
        }
        return true;
    }
}
