import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, ValidatorFn, ValidationErrors } from '@angular/forms';
import { UserService } from '../user.service';
import { Subject } from 'rxjs';
import { takeUntil, map } from "rxjs/operators";
import { RoutingService } from 'src/app/_shared/services/routing.service';
import { SnackBarService } from 'src/app/_shared/services/snackbar.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit, OnDestroy {
  isLoading = false;
  registerForm: FormGroup;
  private _unsubscribeAll: Subject<any>;

  constructor(private _userService: UserService,
    private _snackBarService: SnackBarService,
    private _formBuilder: FormBuilder,
    private _routingService: RoutingService) {
    this._unsubscribeAll = new Subject();
  }

  ngOnInit() {
    this.createForm();
    this.passwordValueChangeEventListener();
  }

  signUp() {
    this._userService.signUp(this.registerForm.value)
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe(result => {
        this._snackBarService.openSnackBar([result.message], 4000, 'center', 'center', 'success');
        this._routingService.navigate('/user/login');
      });
  }

  createForm() {
    this.registerForm = this._formBuilder.group({
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      email: [null, [Validators.required, Validators.email], this.validateUserExistence.bind(this)],
      password: [null, Validators.required],
      passwordConfirm: [null, [Validators.required, confirmPasswordValidator]]
    });
  }

  passwordValueChangeEventListener() {
    this.registerForm.get('password').valueChanges
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe(() => {
        this.registerForm
          .get('passwordConfirm')
          .updateValueAndValidity();
      });
  }

  validateUserExistence(control: AbstractControl) {
    return this._userService
      .checkUserExistence(control.value)
      .pipe(map(res => {
        return res ? { userExists: true } : null;
      }));
  }

  ngOnDestroy(): void {
    this._unsubscribeAll.next();
    this._unsubscribeAll.complete();
  }
}

export const confirmPasswordValidator: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {

  if (!control.parent || !control) {
    return null;
  }

  const password = control.parent.get('password');
  const passwordConfirm = control.parent.get('passwordConfirm');

  if (!password || !passwordConfirm)
    return null;

  if (passwordConfirm.value === '')
    return null;


  if (password.value === passwordConfirm.value)
    return null;

  return { 'passwordsNotMatching': true };
};