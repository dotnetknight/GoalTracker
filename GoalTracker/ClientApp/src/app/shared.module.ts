import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from './material.module';
import { SpinnerComponent } from './spinner/spinner.component';
import { SnackBarService } from './_shared/services/snackbar.service';
import { RoutingService } from './_shared/services/routing.service';


@NgModule({
    declarations: [
        SpinnerComponent,
    ],

    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        FlexLayoutModule,
        MaterialModule
    ],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        FlexLayoutModule,
        MaterialModule,
        SpinnerComponent
    ],
    providers: [
        SnackBarService,
        RoutingService
    ]
})
export class SharedModule {
}
