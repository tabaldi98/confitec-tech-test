import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { IMyInformationsModel, RoleNameCanChangeGeneralSettings, RoleNameCanManageObjects, RoleNameCanManageSystemUsers } from 'src/app/core/authentication/authentication.model';

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.scss']
})
export class MyAccountComponent implements OnInit {
  data!: IMyInformationsModel;
  isLoading: boolean = true;

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

  constructor(private route: ActivatedRoute,) { }

  ngOnInit(): void {
    this.route.data
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((data: any) => {
        this.data = data.mydata;
        this.isLoading = false;
      })
  }
}
