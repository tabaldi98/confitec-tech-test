import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDrawerMode, MatSidenav } from '@angular/material/sidenav';
import { AuthService } from 'src/app/core/authentication/authentication.service';
import { LocalStorageKeys } from 'src/app/core/local-storage/local-storage.model';
import { LocalStorageService } from 'src/app/core/local-storage/local-storage.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  title: string = 'Usuários';
  fullname: string = '';
  @ViewChild('sidenav') sidenav?: MatSidenav;
  mode!: MatDrawerMode;

  constructor(
    private authService: AuthService,
    private localStorageService: LocalStorageService,
  ) { }

  ngOnInit(): void {
    this.fullname = this.authService.token.fullname;
    this.mode = this.localStorageService.getBoolValue(LocalStorageKeys.SideNav) ? 'over' : 'side';
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
