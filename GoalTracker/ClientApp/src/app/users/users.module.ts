import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { UserRoutingModule } from './user-routing.module';
import { SharedModule } from '../shared.module';
import { UserService } from './user.service';
import { MyProfileComponent } from './my-profile/my-profile.component';

@NgModule({
    declarations: [
        LoginComponent,
        SignUpComponent,
        MyProfileComponent
    ],
    imports: [
        SharedModule,
        UserRoutingModule
    ],
    providers: [
        UserService
    ],
    entryComponents: [
    ]
})

export class EmployeeModule {
}
