import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackBarTemplateComponent } from './template/snack-bar-template.component';

@Injectable({
    providedIn: 'root'
})
export class SnackBarService {
    durationInSeconds = 3;

    constructor(private snackBar: MatSnackBar) { }

    showSucessSnackBar(message: string): void {
        this.snackBar.openFromComponent(SnackBarTemplateComponent, {
            duration: this.durationInSeconds * 1000,
            data: message,
            panelClass: ['snack-bar', 'snack-bar--sucess']
        });
    }

    showAlertSnackBar(message: string): void {
        this.snackBar.openFromComponent(SnackBarTemplateComponent, {
            duration: this.durationInSeconds * 1000,
            data: message,
            panelClass: ['snack-bar', 'snack-bar--alert']
        });
    }

    showErrorSnackBar(message: string): void {
        this.snackBar.openFromComponent(SnackBarTemplateComponent, {
            duration: this.durationInSeconds * 1000,
            data: message,
            panelClass: ['snack-bar', 'snack-bar--error']
        });
    }
}

