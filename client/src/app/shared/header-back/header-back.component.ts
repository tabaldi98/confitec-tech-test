import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header-back',
  templateUrl: './header-back.component.html',
  styleUrls: ['./header-back.component.scss']
})
export class HeaderBackComponent {
  @Input() public title?: string;

  constructor(private router: Router) { }

  onBack(): void {
    this.router.navigate(['../']);
  }
}
