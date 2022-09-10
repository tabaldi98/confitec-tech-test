import { Component, Inject, } from '@angular/core';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';

@Component({
  selector: '',
  templateUrl: './snack-bar-template.component.html',
  styleUrls: ['./snack-bar-template.component.scss']
})
export class SnackBarTemplateComponent {

  constructor(@Inject(MAT_SNACK_BAR_DATA) public title: string) { }
}
