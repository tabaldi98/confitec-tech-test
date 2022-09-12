import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { finalize, take } from 'rxjs/operators';
import { IAuthenticationModel } from 'src/app/core/authentication/authentication.model';
import { AuthService } from 'src/app/core/authentication/authentication.service';
import { LocalStorageKeys } from 'src/app/core/local-storage/local-storage.model';
import { LocalStorageService } from 'src/app/core/local-storage/local-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  isLoading: boolean = false;
  hasErrorOnLogin: boolean = false;

  constructor(
    public authService: AuthService, 
    private router: Router,
    private localStorage: LocalStorageService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      login: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
    });
  }

  onLogin(): void {
    this.isLoading = true;
    this.authService
      .login({
        login: this.form.get('login')?.value,
        password: this.form.get('password')?.value
      })
      .pipe(take(1), finalize(() => this.isLoading = false))
      .subscribe(
        (result: IAuthenticationModel): void => {
          this.hasErrorOnLogin = false;
          this.localStorage.setValue(LocalStorageKeys.Token, result.accessToken);
          this.router.navigate(['./'])
            .then(() => {
              window.location.reload();
            });
        },
        (): void => {
          this.hasErrorOnLogin = true;
        }
      )
  }

  onRecoveryPass(): void {
    this.router.navigate(['/recovery-password']);
  }
}
