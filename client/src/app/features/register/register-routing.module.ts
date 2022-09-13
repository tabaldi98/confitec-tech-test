import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { RegisterComponent } from "./register.component";

const userRoutes: Routes = [
    {
        path: '',
        component: RegisterComponent,
    }
];

@NgModule({
    imports: [RouterModule.forChild(userRoutes)],
    exports: [RouterModule],
})
export class RegisterRoutingModule { }