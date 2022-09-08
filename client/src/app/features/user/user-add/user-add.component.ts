import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { UserService } from 'src/app/features/user/shared/user.service';
import { allUserScholarity, formatScholarity, UserScholarity } from '../shared/user.model';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.scss']
})
export class UserAddComponent implements OnInit {
  form!: FormGroup;
  maxDate: Date = new Date();
  scholarities: UserScholarity[] = allUserScholarity;

  constructor(
    public userService: UserService,
    private router: Router,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
      surname: new FormControl('', [Validators.required]),
      mail: new FormControl('', [Validators.required, Validators.email]),
      birthDate: new FormControl('', [Validators.required]),
      scholarity: new FormControl('', [Validators.required]),
    });
  }

  formatScholarity(scholarity: any): string {
    return formatScholarity(scholarity);
  }

  onSave(saveAndCreate: boolean = false): void {
    if (!this.form.valid) { return; }

    this.userService
      .createUser({
        name: this.form.get('name')?.value,
        surname: this.form.get('surname')?.value,
        birthDate: this.form.get('birthDate')?.value,
        mail: this.form.get('mail')?.value,
        scholarity: this.form.get('scholarity')?.value,
      })
      .subscribe(
        () => {
          if (saveAndCreate) {
            this.form.reset();
            this.form.markAsPristine();
          } else {
            this.router.navigate(['../']);
          }
        },
        () => {
          this.showSnackBar();
        });
  }

  onSaveAndCreate(): void {
    this.onSave(true);
  }

  showSnackBar(): void {
    this.snackBar.open('Já existe um usuário cadastrado com esse nome!', undefined, { duration: 3000 });
  }
}
