import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  title: string = 'Usuários';
  @ViewChild('sidenav') sidenav?: MatSidenav;

  constructor() { };

  onToggleSideNav(): void {
    if (this.sidenav?.opened) {
      this.sidenav.close();
    } else {
      this.sidenav?.open();
    }
  }
}
