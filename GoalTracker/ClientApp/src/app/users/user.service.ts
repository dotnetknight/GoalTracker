import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject, Subject } from 'rxjs';
import { SignUpResponse } from './responses/sign-up.response';
import { LoginResponse } from './responses/login.response';

@Injectable()
export class UserService {
    private isAuth: boolean = false;

    isAuthSubject = new Subject<boolean>();

    constructor(
        private httpClient: HttpClient) { }

    login(loginForm): Observable<LoginResponse> {
        return this.httpClient.post<LoginResponse>('api/Users/Login', loginForm);
    }

    signUp(signUpForm): Observable<SignUpResponse> {
        return this.httpClient.post<SignUpResponse>('api/Users/SignUp', signUpForm);
    }

    checkUserExistence(email: string): Observable<boolean> {
        let params = new HttpParams();
        params = params.append('email', email);
        return this.httpClient.get<boolean>('api/Users/UserByEmail', {
            params: params
        });
    }

    chaseUserAuthenticationState(isAuth: boolean) {
        this.isAuthSubject.next(isAuth);
    }

    isUserAuthenticated(): Observable<boolean> {
        return this.isAuthSubject.asObservable();
    }

    getToken() {
        return localStorage.getItem("jwt");
    }
}