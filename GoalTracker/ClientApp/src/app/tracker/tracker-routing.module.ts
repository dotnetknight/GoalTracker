import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DailyTaskComponent } from './daily-task/daily-task.component';
import { AuthGuard } from '../_shared/guards/auth.guard';
import { AddTaskComponent } from './add-task/add-task.component';

const routes: Routes = [
    { path: 'tracker/dailytasks', component: DailyTaskComponent, canActivate: [AuthGuard] },
    { path: 'tracker/addtask', component: AddTaskComponent, canActivate: [AuthGuard] }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})
export class TrackerRoutingModule { }
