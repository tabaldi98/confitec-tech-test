import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeUserComponent } from "./home/home-user.component";
import { UserAddComponent } from "./user-add/user-add.component";
import { UserViewComponent } from "./user-view/user-view.component";

const userRoutes: Routes = [
    {
        path: '',
        component: HomeUserComponent,
    },
    {
        path: 'create',
        component: UserAddComponent,
    },
    {
        path: ':id',
        children: [
            {
                path: '',
                component: UserViewComponent
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(userRoutes)],
    exports: [RouterModule],
})
export class UserRoutingModule { }