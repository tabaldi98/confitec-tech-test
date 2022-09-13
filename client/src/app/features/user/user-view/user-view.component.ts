import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { take, takeUntil } from 'rxjs/operators';
import { SnackBarService } from 'src/app/core/snack-bar/snack-bar.service';
import { UserService } from 'src/app/features/user/shared/user.service';
import { allUserScholarity, formatScholarity, User, UserScholarity } from '../shared/user.model';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.scss']
})
export class UserViewComponent implements OnInit {
  maxDate: Date = new Date();
  form!: FormGroup;
  scholarities: UserScholarity[] = allUserScholarity;
  private ngUnsubscribe: Subject<void> = new Subject<void>();

  constructor(
    public userService: UserService,
    private router: Router,
    private route: ActivatedRoute,
    private snackBarService: SnackBarService) { }

  ngOnInit(): void {
    this.route.params
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((params: any) => {
        this.userService.get(params.id)
          .pipe(take(1))
          .subscribe((user: User) => {
            this.form = new FormGroup({
              id: new FormControl(user.id, [Validators.required]),
              name: new FormControl(user.name, [Validators.required]),
              surname: new FormControl(user.surname, [Validators.required]),
              mail: new FormControl(user.mail, [Validators.required, Validators.email]),
              birthDate: new FormControl(user.birthDate, [Validators.required]),
              scholarity: new FormControl(user.scholarity, [Validators.required]),
            });
          })
      })
  }

  formatScholarity(scholarity: any): string {
    return formatScholarity(scholarity);
  }

  onSave(): void {
    if (!this.form.valid) { return; }

    this.userService
      .editUser({
        id: this.form.get('id')?.value,
        name: this.form.get('name')?.value,
        surname: this.form.get('surname')?.value,
        birthDate: this.form.get('birthDate')?.value,
        mail: this.form.get('mail')?.value,
        scholarity: this.form.get('scholarity')?.value,
      })
      .subscribe(
        () => {
          this.router.navigate(['../']);
        },
        () => {
          this.showSnackBar();
        });
  }

  showSnackBar(): void {
    this.snackBarService.showErrorSnackBar('Já existe um usuário cadastrado com esse nome!');
  }
}
