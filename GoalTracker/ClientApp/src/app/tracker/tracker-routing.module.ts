import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DailyTaskComponent } from './daily-task/daily-task.component';


const routes: Routes = [
    { path: 'tracker/dailyTasks', component: DailyTaskComponent }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule]
})
export class TrackerRoutingModule { }
