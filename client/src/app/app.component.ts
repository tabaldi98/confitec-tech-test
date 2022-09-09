import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './core/authentication/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'confitec-technical-test';
  isLogged: boolean = false;
  isLoading: boolean = true;

  constructor(
    private authService: AuthService,
    private router: Router) { }

  public ngOnInit(): void {
    this.authService.isAlive()
      .subscribe(
        (result: boolean) => {
          this.isLogged = result;
          this.isLoading = false;
         // this.router.navigate(['/users']);
        },
        (): void => {
          this.isLoading = false;
          this.isLogged = false;
        })
  }
}
