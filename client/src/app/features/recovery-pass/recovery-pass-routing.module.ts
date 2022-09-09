import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { RecoveryPassComponent } from "./recovery-pass.component";

const userRoutes: Routes = [
    {
        path: '',
        component: RecoveryPassComponent,
    }
];

@NgModule({
    imports: [RouterModule.forChild(userRoutes)],
    exports: [RouterModule],
})
export class RecoveryPassRoutingModule { }