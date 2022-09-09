import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { RecoveryPassComponent } from "./recovery-pass.component";
import { RecoveryPassRoutingModule } from "./recovery-pass-routing.module";

@NgModule({
    imports: [
        CommonModule,
        RecoveryPassRoutingModule,
        MatCardModule,
        MatInputModule,
        MatButtonModule,
        FormsModule,
        ReactiveFormsModule,
        MatProgressSpinnerModule
    ],
    declarations: [
        RecoveryPassComponent,
    ],
    providers: []
})
export class RecoveryPassModule { }