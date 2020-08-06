import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable()
export class RoutingService {
    constructor(
        private router: Router) { }

    navigate(route: string) {
        this.router.navigate([route]);
    }
}