import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
    selector: 'app-confirm-delete',
    templateUrl: './register-sucess-dialog.component.html',
    styleUrls: []
})
export class RegisterSucessDialogComponent {

    constructor(public dialogRef: MatDialogRef<RegisterSucessDialogComponent>) { }

    onClose(): void {
        this.dialogRef.close();
    }
}
