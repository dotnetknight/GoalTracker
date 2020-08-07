import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from '../user.service';
import { Subject } from 'rxjs';
import { takeUntil } from "rxjs/operators";
import { RoutingService } from 'src/app/_shared/services/routing.service';
import { SnackBarService } from 'src/app/_shared/services/snackbar.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit, OnDestroy {
  maxDate;
  private _unsubscribeAll: Subject<any>;
  isLoading = false;

  constructor(private _userService: UserService,
    private _snackBarService: SnackBarService,
    private _routingService: RoutingService,) {
    this._unsubscribeAll = new Subject();
  }

  ngOnInit() {
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  }

  signUp(form: NgForm) {
    this.isLoading = true;
    this._userService.signUp(form.value)
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe(result => {
        this._snackBarService.openSnackBar([result.message], 4000, 'center', 'center', 'success');
        this._routingService.navigate('/user/login');
      }, err => {
        console.log(err);
        this._snackBarService.openSnackBar(err.error.errors.map(element => element.message), 4000, 'center', 'center', 'error');
      });
  }

  ngOnDestroy(): void {
    this._unsubscribeAll.next();
    this._unsubscribeAll.complete();
  }


}