import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { SettingsComponent } from "./settings.component";

const userRoutes: Routes = [
    {
        path: '',
        component: SettingsComponent,
    }
];

@NgModule({
    imports: [RouterModule.forChild(userRoutes)],
    exports: [RouterModule],
})
export class SettingsRoutingModule { }