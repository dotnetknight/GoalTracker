import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './_shared/guards/auth.guard';
import { LoginComponent } from './users/login/login.component';


const routes: Routes = [{ path: '', component: LoginComponent, canActivate: [AuthGuard] }]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
