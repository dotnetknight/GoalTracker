import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackbarMessageComponent } from '../snackbar-message/snackbar-message.component';

@Injectable()
export class SnackBarService {
    constructor(
        private snackBar: MatSnackBar) { }

    openSnackBar(messages: string[], duration: number, verticalPosition, horizontalPosition, type: string): void {
        this.snackBar.openFromComponent(SnackbarMessageComponent, {
            data: {
                type,
                messages
            },
            verticalPosition: verticalPosition,
            horizontalPosition: horizontalPosition,
            panelClass: type,
            duration: duration,
        });
    }
}