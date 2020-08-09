import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/users/user.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    contentType;
    constructor(private _userService: UserService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const jwtToken = this._userService.getToken();

        if (jwtToken) {
            request = request.clone({
                setHeaders: {
                    'Authorization': `Bearer ${jwtToken}`
                }
            });
        }

        return next.handle(request);
    }
}
