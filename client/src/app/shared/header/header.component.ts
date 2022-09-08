import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  title: string = 'Usuários';
  @ViewChild('sidenav') sidenav?: MatSidenav;

  constructor(private router: Router) { }
  
  onToggleSideNav(): void {
    if (this.sidenav?.opened) {
      this.sidenav.close();
    } else {
      this.sidenav?.open();
    }
  }

  onExit(): void {
    localStorage.removeItem('token');
    window.location.reload();
  }
}
