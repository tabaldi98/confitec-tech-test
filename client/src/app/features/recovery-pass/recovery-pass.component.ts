import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatStepper } from '@angular/material/stepper';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { AuthService } from 'src/app/core/authentication/authentication.service';
import { SnackBarService } from 'src/app/core/snack-bar/snack-bar.service';

@Component({
  selector: 'app-recovery-pass',
  templateUrl: './recovery-pass.component.html',
  styleUrls: ['./recovery-pass.component.scss']
})
export class RecoveryPassComponent implements OnInit {
  formFirstStep!: FormGroup;
  formSecondStep!: FormGroup;
  formThirdStep!: FormGroup;

  constructor(
    public authService: AuthService,
    private router: Router,
    private snackBarService: SnackBarService) { }

  ngOnInit(): void {
    this.formFirstStep = new FormGroup({
      login: new FormControl('', [Validators.required]),
    });

    this.formSecondStep = new FormGroup({
      code: new FormControl('', [Validators.required]),
    });
    this.formSecondStep.disable();

    this.formThirdStep = new FormGroup({
      pass: new FormControl('', [Validators.required]),
      pass2: new FormControl('', [Validators.required]),
    });
    this.formThirdStep.disable();
  }

  onFirstActionSubmmit(stepper: MatStepper): void {
    this.formFirstStep.disable();
    this.authService
      .recoveryPassword({ userNameOrLogin: this.formFirstStep.get('login')?.value })
      .pipe(take(1))
      .subscribe(
        () => {
          stepper.next();
          this.formSecondStep.enable();
        },
        () => {
          this.snackBarService.showErrorSnackBar('Nenhum usuário encontrado!');
          this.formFirstStep.enable();
        })
  }

  onSecondActionSubmmit(stepper: MatStepper): void {
    this.formSecondStep.disable();
    this.authService
      .validateCode({
        userName: this.formFirstStep.get('login')?.value,
        code: this.formSecondStep.get('code')?.value
      })
      .subscribe(
        (result: boolean) => {
          if (result) {
            stepper.next();
            this.formThirdStep.enable();
          } else {
            this.snackBarService.showErrorSnackBar('Código inválido!');
            this.formSecondStep.enable();
          }
        })
  }

  onThirdActionSubmmit(stepper: MatStepper): void {
    const pass: string = this.formThirdStep.get('pass')?.value
    const pass2: string = this.formThirdStep.get('pass2')?.value

    if (pass !== pass2) {
      this.snackBarService.showErrorSnackBar('Senhas não conferem!');
      return;
    }

    this.authService.updatePasswordOnRecovery({
      userName: this.formFirstStep.get('login')?.value,
      password: pass,
      code: this.formSecondStep.get('code')?.value
    })
      .pipe(take(1))
      .subscribe(() => {
        this.router.navigate(['/login'])
          .then(() => this.snackBarService.showSucessSnackBar('Senha alterada com sucesso!'));
      });
  }
}
