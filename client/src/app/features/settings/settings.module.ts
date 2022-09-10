import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { SettingsComponent } from "./settings.component";
import { SettingsRoutingModule } from "./settings-routing.module";
import { MatDividerModule } from "@angular/material/divider";
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { SettingsService } from "./shared/settings.service";

@NgModule({
    imports: [
        CommonModule,
        SettingsRoutingModule,
        MatCardModule,
        MatInputModule,
        MatButtonModule,
        FormsModule,
        ReactiveFormsModule,
        MatProgressSpinnerModule,
        MatDividerModule,
        MatSlideToggleModule
    ],
    declarations: [
        SettingsComponent,
    ],
    providers: [
        SettingsService
    ]
})
export class SettingsModule { }