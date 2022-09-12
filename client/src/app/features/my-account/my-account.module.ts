import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MyAccountRoutingModule } from "./my-account-routing.module";
import { MyAccountComponent } from "./my-account.component";
import { MatCardModule } from "@angular/material/card";
import { MatInputModule } from "@angular/material/input";
import { MatDividerModule } from "@angular/material/divider";
import { MyDataComponent } from './my-data/my-data.component';
import { MyAccountDataResolveService } from "./shared/my-account-data-resolver.service";
import { SaveButtonsModule } from "src/app/shared/save-buttons/save-buttons.module";
import { HeaderBackModule } from "src/app/shared/header-back/header-back.module";
import { ChangePasswordComponent } from './change-password/change-password.component';

@NgModule({
    imports: [
        CommonModule,
        MyAccountRoutingModule,
        MatCardModule,
        MatInputModule,
        MatButtonModule,
        FormsModule,
        ReactiveFormsModule,
        MatProgressSpinnerModule,
        MatDividerModule,
        SaveButtonsModule,
        HeaderBackModule
    ],
    declarations: [
        MyAccountComponent,
        MyDataComponent,
        ChangePasswordComponent,
    ],
    providers: [
        MyAccountDataResolveService
    ]
})
export class MyAccountModule { }