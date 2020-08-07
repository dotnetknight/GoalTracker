import { NgModule } from '@angular/core';
import { SharedModule } from '../shared.module';
import { DailyTaskComponent } from './daily-task/daily-task.component';
import { TrackerRoutingModule } from './tracker-routing.module';

@NgModule({
    declarations: [

        DailyTaskComponent],
    imports: [
        SharedModule,
        TrackerRoutingModule

    ],
    providers: [

    ],
    entryComponents: [
    ]
})

export class TrackerModule {
}
