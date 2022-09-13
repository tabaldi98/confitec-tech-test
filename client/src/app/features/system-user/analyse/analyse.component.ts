import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, take, takeUntil } from 'rxjs';
import { RoleNameCanChangeGeneralSettings, RoleNameCanManageObjects, RoleNameCanManageSystemUsers } from 'src/app/core/authentication/authentication.model';
import { SystemUserService } from 'src/app/core/authentication/system-user.service';
import { SnackBarService } from 'src/app/core/snack-bar/snack-bar.service';
import { SystemUser } from '../shared/system-user.model';

@Component({
  selector: 'app-analyse',
  templateUrl: './analyse.component.html',
  styleUrls: ['./analyse.component.scss']
})
export class AnalyseComponent implements OnInit {
  form!: FormGroup;
  user!: SystemUser;

  private ngUnsubscribe: Subject<void> = new Subject<void>();

  constructor(
    public userService: SystemUserService,
    private router: Router,
    private route: ActivatedRoute,
    private snackBarService: SnackBarService) { }

  ngOnInit(): void {
    this.route.params
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((params: any) => {
        this.userService.get(params.id)
          .pipe(take(1))
          .subscribe((user: SystemUser) => {
            this.user = user;
            this.form = new FormGroup({
              aproved: new FormControl(this.user.isAproved, [Validators.required]),
              canManageObjects: new FormControl(this.user.permissions.some((x: string) => x === RoleNameCanManageObjects) , [Validators.required]),
              canManageSystemUsers: new FormControl(this.user.permissions.some((x: string) => x === RoleNameCanManageSystemUsers) , [Validators.required]),
              canManageSystemSettings: new FormControl(this.user.permissions.some((x: string) => x === RoleNameCanChangeGeneralSettings) , [Validators.required]),
            })

            // Usuário principal do sistema
            if (this.user.id === 1) {
              this.form.disable();
            }
          })
      })
  }

  onSave(): void {
    let permissions: string[] = [];
    if (this.form.get('canManageObjects')?.value) {
      permissions.push(RoleNameCanManageObjects);
    }
    if (this.form.get('canManageSystemUsers')?.value) {
      permissions.push(RoleNameCanManageSystemUsers);
    }
    if (this.form.get('canManageSystemSettings')?.value) {
      permissions.push(RoleNameCanChangeGeneralSettings);
    }

    this.userService.update({
      id: this.user.id,
      isAproved: this.form.get('aproved')?.value,
      permissions
    })
      .subscribe(() => {
        this.router.navigate(['../'], { relativeTo: this.route })
          .then(() => this.snackBarService.showSucessSnackBar('Salvo com sucesso!'));
      });
  }
}
