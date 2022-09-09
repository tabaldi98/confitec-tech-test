import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDrawerMode, MatSidenav } from '@angular/material/sidenav';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
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

  private ngUnsubscribe: Subject<void> = new Subject<void>();

  constructor(
    private authService: AuthService,
    private localStorageService: LocalStorageService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.fullname = this.authService.token.fullname;
    this.mode = this.localStorageService.getBoolValue(LocalStorageKeys.SideNav) ? 'over' : 'side';

      // this.route.data.pipe(
      //   takeUntil(this.ngUnsubscribe))
      //   .subscribe((data: any) => {
      //       debugger;
      //   });
  }

  onExit(): void {
    this.authService.logout();
  }
}
