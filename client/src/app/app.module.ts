import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatTooltipModule } from '@angular/material/tooltip';
import { CommonModule } from '@angular/common';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { AuthService } from './core/authentication/authentication.service';
import { TokenInterceptor } from './core/http-interceptors/token-interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ClientErrorInterceptor } from './core/http-interceptors/client-error-interceptor';
import { AuthGuardService } from './core/authentication/auth-guard.service';
import { LocalStorageService } from './core/local-storage/local-storage.service';
import { SnackBarService } from './core/snack-bar/snack-bar.service';
import { GridODataService } from './shared/grid/shared/grid-odata.service';
import { HeaderService } from './shared/header/shared/header.service';
import { HeadderResolveService } from './shared/header/shared/header-resolve.service';
import { NotAllowManageObjectsGuardService } from './core/guards/not-allow-manage-objects-guard.service';
import { NotAllowManageSystemUsersGuardService } from './core/guards/not-allow-manage-system-users-guard.service';
import { NotAllowManageGeneralSettingsGuardService } from './core/guards/not-allow-manage-general-settings-guard.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    CommonModule,
    AppRoutingModule,
    NoopAnimationsModule,
    MatToolbarModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    HttpClientModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    MatCheckboxModule,
    MatTooltipModule,
    MatSidenavModule,
    MatListModule,
    MatMenuModule,
    MatProgressSpinnerModule,
  ],
  providers: [
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ClientErrorInterceptor,
      multi: true,
    },
    LocalStorageService,
    SnackBarService,
    GridODataService,
    HeaderService,
    HeadderResolveService,

    // Auth-Guards
    AuthGuardService,
    NotAllowManageObjectsGuardService,
    NotAllowManageSystemUsersGuardService,
    NotAllowManageGeneralSettingsGuardService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
