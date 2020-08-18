import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { LoginGuard } from '../_shared/guards/login.guard';
import { MyProfileComponent } from './my-profile/my-profile.component';
import { AuthGuard } from '../_shared/guards/auth.guard';


const routes: Routes = [
    { path: 'user/signup', component: SignUpComponent, canActivate: [LoginGuard] },
    { path: 'user/login', component: LoginComponent, canActivate: [LoginGuard] },
    { path: 'user/profile', component: MyProfileComponent, canActivate: [AuthGuard] },
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})
export class UserRoutingModule { }
