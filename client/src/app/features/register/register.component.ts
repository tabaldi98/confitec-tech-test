import { Component, OnInit } from '@angular/core';
import { SocialAuthService } from "@abacritt/angularx-social-login";
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {
  GoogleLoginProvider,
} from '@abacritt/angularx-social-login';
import { MatDialog } from '@angular/material/dialog';
import { RegisterSucessDialogComponent } from './register-sucess-dialog/register-sucess-dialog.component';
import { Router } from '@angular/router';
import { SystemUserService } from 'src/app/core/authentication/system-user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  form!: FormGroup;

  constructor(
    private authService1: SocialAuthService,
    public dialog: MatDialog,
    private router: Router,
    private systemService: SystemUserService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      username: new FormControl('', [Validators.required]),
      fullname: new FormControl('', [Validators.required]),
      mail: new FormControl('', [Validators.required]),
      pass: new FormControl('', [Validators.required]),
    });

    this.authService1.authState
      .subscribe((user: any) => {
        this.form.get('username')?.setValue(user.firstName.toLowerCase() + '.' + user.lastName.toLowerCase());
        this.form.get('fullname')?.setValue(user.name);
        this.form.get('mail')?.setValue(user.email);
      });
  }

  onRegister(): void {
    this.form.disable();
    this.systemService.create(
      {
        fullName: this.form.get('fullname')?.value,
        userName: this.form.get('username')?.value,
        mail: this.form.get('mail')?.value,
        password: this.form.get('pass')?.value,
      })
      .subscribe(() => {
        const dialogRef = this.dialog.open(RegisterSucessDialogComponent, {
          width: '250px'
        });
        dialogRef.afterClosed()
          .subscribe(() => {
            this.router.navigate(['/login']);
          });
      });
  }
}
