import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-save-buttons',
  templateUrl: './save-buttons.component.html',
  styleUrls: ['./save-buttons.component.scss']
})
export class SaveButtonsComponent {
  @Input() public form?: FormGroup
  @Output() public onSaveClick: EventEmitter<any> = new EventEmitter<any>();
  @Output() public onSaveAndCreateClick: EventEmitter<any> = new EventEmitter<any>();

  constructor(private router: Router) { 
  }

  onSave(): void {
    this.onSaveClick.emit();
  }

  onSaveAndCreate(): void {
    this.onSaveAndCreateClick.emit();
  }

  onCancel(): void {
    this.router.navigate(['../']);
  }
}
