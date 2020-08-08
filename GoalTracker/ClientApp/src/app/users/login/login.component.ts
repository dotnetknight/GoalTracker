import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { UserService } from '../user.service';
import { SnackBarService } from 'src/app/_shared/services/snackbar.service';
import { RoutingService } from 'src/app/_shared/services/routing.service';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  isLoading = false;
  loginForm: FormGroup;

  private _unsubscribeAll: Subject<any>;

  constructor(private _userService: UserService,
    private _snackBarService: SnackBarService,
    private _formBuilder: FormBuilder,
    private _routingService: RoutingService) {
    this._unsubscribeAll = new Subject();
  }

  ngOnInit(): void {
    this.loginForm = this._formBuilder.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, Validators.required]
    });
  }

  login() {
    this._userService.login(this.loginForm.value)
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe(res => {
        let token = (<any>res).token;
        localStorage.setItem("jwt", token);
        this._userService.chaseUserAuthenticationState(true);

        this._snackBarService.openSnackBar([res.message], 4000, 'center', 'center', 'success');
        this._routingService.navigate('/tracker/dailytasks');
      }, err => {
        if (err.error.errors != undefined) {
          this._snackBarService
            .openSnackBar(err.error.errors
              .map(element => element.message), 4000, 'center', 'center', 'error');
        }

        else {
          this._snackBarService
            .openSnackBar([err.error.message], 4000, 'center', 'center', 'error');
        }
      });
  }

  ngOnDestroy(): void {
    this._unsubscribeAll.next();
    this._unsubscribeAll.complete();
  }
}