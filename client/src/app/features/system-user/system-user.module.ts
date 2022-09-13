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
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatTableModule } from "@angular/material/table";
import { MatDialogModule } from "@angular/material/dialog";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatTooltipModule } from "@angular/material/tooltip";
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { GridModule } from "src/app/shared/grid/grid.module";
import { SystemUserGridComponent } from "./grid/system-user-grid.component";
import { SystemUserRoutingModule } from "./system-user-routing.module";
import { AnalyseComponent } from './analyse/analyse.component';
import { MatSlideToggleModule } from "@angular/material/slide-toggle";
import { ConfirmDeleteComponent } from "./confirm-delete/confirm-delete.component";

@NgModule({
    imports: [
        CommonModule,
        SystemUserRoutingModule,
        MatToolbarModule,
        MatTableModule,
        MatButtonModule,
        MatIconModule,
        MatDialogModule,
        MatInputModule,
        FormsModule,
        ReactiveFormsModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatSelectModule,
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
        MatSlideToggleModule
    ],
    declarations: [
        SystemUserGridComponent,
        AnalyseComponent,
        ConfirmDeleteComponent,
    ],
    providers: []
})
export class SystemUserModule { }