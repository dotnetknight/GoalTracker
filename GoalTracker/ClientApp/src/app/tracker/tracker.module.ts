import { NgModule } from '@angular/core';
import { SharedModule } from '../shared.module';
import { DailyTaskComponent } from './daily-task/daily-task.component';
import { TrackerRoutingModule } from './tracker-routing.module';
import { AddTaskComponent } from './add-task/add-task.component';
import { TrackerService } from './tracker.service';

@NgModule({
    declarations: [

        DailyTaskComponent,

        AddTaskComponent],
    imports: [
        SharedModule,
        TrackerRoutingModule

    ],
    providers: [
        TrackerService
    ],
    entryComponents: [
    ]
})

export class TrackerModule {
}
