import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatNativeDateModule } from "@angular/material/core";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { HeaderBackModule } from "src/app/shared/header-back/header-back.module";
import { SaveButtonsModule } from "src/app/shared/save-buttons/save-buttons.module";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { UserRoutingModule } from "./user-routing.module";
import { UserAddComponent } from "./user-add/user-add.component";
import { UserViewComponent } from "./user-view/user-view.component";
import { HomeUserComponent } from "./home/home-user.component";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatTableModule } from "@angular/material/table";
import { MatDialogModule } from "@angular/material/dialog";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatTooltipModule } from "@angular/material/tooltip";
import { UserService } from "./shared/user.service";
import { ConfirmDeleteComponent } from "./confirm-delete/confirm-delete.component";
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { GridModule } from "src/app/shared/grid/grid.module";

@NgModule({
    imports: [
        CommonModule,
        UserRoutingModule,
        MatToolbarModule,
        MatTableModule,
        MatButtonModule,
        MatIconModule,
        MatDialogModule,
        MatInputModule,
        FormsModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatSelectModule,
        ReactiveFormsModule,
        MatSnackBarModule,
        MatCheckboxModule,
        MatTooltipModule,
        HeaderBackModule,
        SaveButtonsModule,
        MatProgressSpinnerModule,
        MatFormFieldModule,
        MatPaginatorModule,
        MatSortModule,
        DragDropModule,
        GridModule,
    ],
    declarations: [
        UserAddComponent,
        UserViewComponent,
        HomeUserComponent,
        ConfirmDeleteComponent,
    ],
    providers: [UserService]
})
export class UserModule { }