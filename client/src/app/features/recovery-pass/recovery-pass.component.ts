import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { AuthService } from 'src/app/core/authentication/authentication.service';

@Component({
  selector: 'app-recovery-pass',
  templateUrl: './recovery-pass.component.html',
  styleUrls: ['./recovery-pass.component.scss']
})
export class RecoveryPassComponent implements OnInit {
  form!: FormGroup;
  isLoading: boolean = false;
  hasErrorOnLogin: boolean = false;
  codeSend: boolean = false;
  codeValidated: boolean = false;
  userName: string = '';
  passwordValid: boolean = false;

  constructor(
    public authService: AuthService,
    private router: Router,
    private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      login: new FormControl('', [Validators.required]),
      code: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl('', [Validators.required]),
    });
  }

  onSend(): void {
    this.isLoading = true;

    if (this.codeSend) {
      this.authService
        .validateCode({
          userName: this.userName,
          code: this.form.get('code')?.value
        })
        .pipe(take(1))
        .subscribe((response: boolean) => {
          if (!response) {
            this.codeValidated = false
            this._snackBar.open('Código informado é inválido!', undefined, { duration: 3000 });
          } else {
            this.codeValidated = true;
          }
          this.isLoading = false;
        })

    } else {
      this.authService
        .recoveryPassword({
          userNameOrLogin: this.form.get('login')?.value
        })
        .pipe(take(1))
        .subscribe(() => {
          this._snackBar.open('Código enviado para o e-mail cadastrado!', undefined, { duration: 3000 });
          this.codeSend = true;
          this.isLoading = false;
          this.userName = this.form.get('login')?.value;
          this.form.get('login')?.setValue('');
        })
    }
  }

  onConfirm(): void {
    const pass: string = this.form.get('password')?.value;
    const confPass: string = this.form.get('confirmPassword')?.value;

    this.passwordValid = pass === confPass;

    if (this.passwordValid) {
      this.authService.updatePassword({
        userName: this.userName,
        password: pass
      })
        .pipe(take(1))
        .subscribe(() => {
          this._snackBar.open('Senha alterada com sucesso!', undefined, { duration: 3000 });
          this.router.navigate(['/login']);
        });
    }
  }
}
