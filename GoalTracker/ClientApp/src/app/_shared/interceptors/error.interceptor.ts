import { throwError } from 'rxjs/internal/observable/throwError';
import { HttpHandler, HttpEvent, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/internal/operators/catchError';
import { SnackBarService } from '../services/snackbar.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private _snackBarService: SnackBarService) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError(err => {
                if (err.error.errors != undefined) {
                    this._snackBarService
                        .openSnackBar(err.error.errors
                            .map(element => element.message), 4000, 'center', 'center', 'error');
                }
                else {
                    this._snackBarService
                        .openSnackBar([err.error.message], 4000, 'center', 'center', 'error');
                }
                return throwError(err);
            })
        );
    }
}