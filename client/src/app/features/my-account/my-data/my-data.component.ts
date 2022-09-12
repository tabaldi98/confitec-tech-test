import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';
import { IMyInformationsModel, RoleNameCanChangeGeneralSettings, RoleNameCanManageObjects, RoleNameCanManageSystemUsers } from 'src/app/core/authentication/authentication.model';
import { AuthService } from 'src/app/core/authentication/authentication.service';
import { SnackBarService } from 'src/app/core/snack-bar/snack-bar.service';

@Component({
  selector: 'app-my-data',
  templateUrl: './my-data.component.html',
  styleUrls: ['./my-data.component.scss']
})
export class MyDataComponent implements OnInit {
  form!: FormGroup;
  isLoading: boolean = true;
  data!: IMyInformationsModel;

  get permissions(): string {
    let p: string = '';
    this.data?.permissions.forEach((permission: string) => {
      switch (permission) {
        case RoleNameCanManageObjects:
          p += 'Editar objetos, '
          break;
        case RoleNameCanManageSystemUsers:
          p += 'Gerenciar usuários do sistema, '
          break;
        case RoleNameCanChangeGeneralSettings:
          p += 'Gerenciar configurações gerais, '
          break;
      }
    })

    p = p.slice(0, -2);
    return p;
  }

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
          fullName: new FormControl(this.data.fullName, [Validators.required]),
          mail: new FormControl(this.data.mail, [Validators.required]),
        });
        this.isLoading = false;
      })
  }

  save(): void {
    if (!this.form.valid) { return; }

    this.isLoading = true;
    this.authService.updateMySelf({
      fullName: this.form.get('fullName')?.value,
      mail: this.form.get('mail')?.value,
    })
      .pipe(finalize(() => this.isLoading = false))
      .subscribe(() => {
        this.router.navigate(['../'], { relativeTo: this.route }).then((() => this.snackBarService.showSucessSnackBar('Dados alterados com sucesso.')));
      })
  }
}
