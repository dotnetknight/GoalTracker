import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { UserRoutingModule } from './user-routing.module';
import { SharedModule } from '../shared.module';

@NgModule({
    declarations: [
        LoginComponent,
        SignUpComponent
    ],
    imports: [
        SharedModule,
        UserRoutingModule
    ],
    providers: [

    ],
    entryComponents: [
    ]
})

export class EmployeeModule {
}
