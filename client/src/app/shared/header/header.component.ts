import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDrawerMode, MatSidenav } from '@angular/material/sidenav';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { AuthService } from 'src/app/core/authentication/authentication.service';
import { LocalStorageKeys } from 'src/app/core/local-storage/local-storage.model';
import { LocalStorageService } from 'src/app/core/local-storage/local-storage.service';
import { HeaderService } from './shared/header.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  panelOpenState = false;
  title: string = '';
  fullname: string = '';
  @ViewChild('sidenav') sidenav?: MatSidenav;
  mode!: MatDrawerMode;
  hasSystemUserPermission: boolean = false;

  private ngUnsubscribe: Subject<void> = new Subject<void>();

  constructor(
    private authService: AuthService,
    private localStorageService: LocalStorageService,
    private headerService: HeaderService
  ) { }

  ngOnInit(): void {
    this.fullname = this.authService.token.fullname;
    this.mode = this.localStorageService.getBoolValue(LocalStorageKeys.SideNav) ? 'over' : 'side';
    this.hasSystemUserPermission = this.authService.hasCanManageSystemUsersRole;

    this.headerService.onRouteChanged
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((title: string) => this.title = title);
  }

  onExit(): void {
    this.authService.logout();
  }

  onClick(title: string, sidenav: MatSidenav): void {
    this.title = title;
    if (this.mode == 'over') {
      sidenav.toggle();
    }
  }
}
