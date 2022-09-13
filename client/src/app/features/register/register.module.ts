import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatDividerModule } from "@angular/material/divider";
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { RegisterRoutingModule } from "./register-routing.module";
import { RegisterComponent } from "./register.component";
import { SocialAuthServiceConfig } from '@abacritt/angularx-social-login';
import {
    GoogleLoginProvider,
} from '@abacritt/angularx-social-login';
import { environment } from 'src/environments/environment';
import { SocialLoginModule } from '@abacritt/angularx-social-login';
import { MatDialogModule } from "@angular/material/dialog";

const CLIENT_ID = environment.clientId;

@NgModule({
    imports: [
        CommonModule,
        RegisterRoutingModule,
        MatCardModule,
        MatInputModule,
        MatButtonModule,
        FormsModule,
        ReactiveFormsModule,
        MatProgressSpinnerModule,
        MatDividerModule,
        MatSlideToggleModule,
        SocialLoginModule,
        MatDialogModule,
    ],
    declarations: [
        RegisterComponent,
    ],
    providers: [{
        provide: 'SocialAuthServiceConfig',
        useValue: {
            autoLogin: false,
            providers: [
                {
                    id: GoogleLoginProvider.PROVIDER_ID,
                    provider: new GoogleLoginProvider(
                        CLIENT_ID
                    )
                }
            ],
            onError: (err) => {
                console.error(err);
            }
        } as SocialAuthServiceConfig,
    }
    ]
})
export class RegisterModule { }