import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RecoveryPassComponent } from "./recovery-pass.component";
import { RecoveryPassRoutingModule } from "./recovery-pass-routing.module";
import { MatStepperModule } from '@angular/material/stepper';
import { CdkStepperModule } from '@angular/cdk/stepper';

@NgModule({
    imports: [
        CommonModule,
        RecoveryPassRoutingModule,
        MatCardModule,
        MatInputModule,
        MatButtonModule,
        FormsModule,
        ReactiveFormsModule,
        CdkStepperModule,
        MatStepperModule,
    ],
    declarations: [
        RecoveryPassComponent,
    ],
    providers: []
})
export class RecoveryPassModule { }