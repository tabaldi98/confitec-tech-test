import { Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { User } from 'src/app/models/User';
import { UserScholarity } from 'src/app/models/user.scholarity.enum';

@Component({
  selector: 'app-element-dialog',
  templateUrl: './element-dialog.component.html',
  styleUrls: ['./element-dialog.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class ElementDialogComponent implements OnInit {
  element!: User;
  isChange!: boolean;
  maxDate: Date = new Date();
  scholarities: UserScholarity[] = [UserScholarity.Infantile, UserScholarity.Fundamental, UserScholarity.Medium, UserScholarity.Higher];
  form!: FormGroup;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: User,
    public dialogRef: MatDialogRef<ElementDialogComponent>,
  ) { }

  ngOnInit(): void {
    this.isChange = this.data.id !== null;

    this.form = new FormGroup({
      id: new FormControl(this.data.id),
      name: new FormControl(this.data.name, [Validators.required]),
      surname: new FormControl(this.data.surname, [Validators.required]),
      mail: new FormControl(this.data.mail, [Validators.required, Validators.email]),
      birthDate: new FormControl(this.data.birthDate, [Validators.required]),
      scholarity: new FormControl(this.data.scholarity, [Validators.required]),
    });
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  formatScholarity(scholarity: any): string {
    switch (scholarity) {
      default:
      case UserScholarity.Infantile:
        return 'Infantil';
      case UserScholarity.Fundamental:
        return 'Fundamental';
      case UserScholarity.Medium:
        return 'Médio';
      case UserScholarity.Higher:
        return 'Superior';
    }
  }
}
