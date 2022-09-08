import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from "@angular/material/divider";
import { SaveButtonsComponent } from "./save-buttons.component";

@NgModule({
  imports: [
    CommonModule,
    MatButtonModule,
    MatDividerModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  declarations: [SaveButtonsComponent],
  exports: [SaveButtonsComponent],
})
export class SaveButtonsModule { }