import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from '../user.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { confirmPasswordValidator } from '../validators/confirm-password.validator';
import { SnackBarService } from 'src/app/_shared/services/snackbar.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent implements OnInit, OnDestroy {
  private _unsubscribeAll: Subject<any>;
  profileForm: FormGroup;
  isLoading: boolean = true;

  constructor(private _userService: UserService,
    private _formBuilder: FormBuilder,
    private _snackBarService: SnackBarService
  ) {
    this._unsubscribeAll = new Subject();
  }

  ngOnInit(): void {
    this._userService.myProfile()
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe(result => {
        console.log(result);

        this.createForm(result);
        this.passwordValueChangeEventListener();
        this.isLoading = false;
      });
  }

  update() {
    this._userService.updateMyProfile(this.profileForm.value)
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe(result => {
        console.log(result);

        this._snackBarService.openSnackBar([result.message], 6000, 'center', 'center', 'success');
        this.isLoading = false;
        this._userService.logout();
      });
  }

  createForm(form) {
    this.profileForm = this._formBuilder.group({
      firstName: [form.firstName, Validators.required],
      lastName: [form.lastName, Validators.required],
      email: [form.email],
      password: [null],
      passwordConfirm: [null, [confirmPasswordValidator]]
    });
  }

  passwordValueChangeEventListener() {
    this.profileForm.get('password').valueChanges
      .pipe(takeUntil(this._unsubscribeAll))
      .subscribe(() => {
        this.profileForm
          .get('passwordConfirm')
          .updateValueAndValidity();
      });
  }

  ngOnDestroy(): void {
    this._unsubscribeAll.next();
    this._unsubscribeAll.complete();
  }
}