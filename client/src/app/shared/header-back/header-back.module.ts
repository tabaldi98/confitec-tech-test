import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { HeaderBackComponent } from "./header-back.component";

@NgModule({
    imports: [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        MatDividerModule
    ],
    declarations: [HeaderBackComponent],
    exports: [HeaderBackComponent],
})
export class HeaderBackModule { }