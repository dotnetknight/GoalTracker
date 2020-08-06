import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from 'app/authentication/services/authentication.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    contentType;
    constructor(private authService: AuthService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const jwtToken = this.authService.getToken();

        if (jwtToken) {
            request = request.clone({
                setHeaders: {
                    'Authorization': `Bearer ${this.authService.getToken()}`
                }
            });
        }

        return next.handle(request);
    }
}
