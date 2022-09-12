import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';
import { IMyInformationsModel } from 'src/app/core/authentication/authentication.model';
import { AuthService } from 'src/app/core/authentication/authentication.service';
import { SnackBarService } from 'src/app/core/snack-bar/snack-bar.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {
  form!: FormGroup;
  isLoading: boolean = true;
  data!: IMyInformationsModel;

  private ngUnsubscribe: Subject<void> = new Subject<void>();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private snackBarService: SnackBarService) { }

  ngOnInit(): void {
    this.route.data
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((data: any) => {
        this.data = data.mydata;
        this.form = new FormGroup({
          currentPass: new FormControl('', [Validators.required]),
          pass: new FormControl('', [Validators.required]),
          pass2: new FormControl('', [Validators.required]),
        });
        this.isLoading = false;
      })
  }

  save(): void {
    if (!this.form.valid) { return; }
    const currentPassword: string = this.form.get('currentPass')?.value;
    const password: string = this.form.get('pass')?.value;
    const password2: string = this.form.get('pass2')?.value;

    if (password !== password2) {
      this.snackBarService.showErrorSnackBar('Senhas não conferem.');
      return;
    }

    this.isLoading = true;
    this.authService.updatePassword({ currentPassword, password })
      .pipe(finalize(() => this.isLoading = false))
      .subscribe(
        () => {
          this.router.navigate(['../'], { relativeTo: this.route })
          .then((() => {
            this.snackBarService.showSucessSnackBar('Senha alterada com sucesso.');
          }));
        },
        () => {
          this.snackBarService.showErrorSnackBar('Senha atual digitada não é valida.');
        }
      )
  }
}
