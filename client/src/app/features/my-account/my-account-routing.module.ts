import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ChangePasswordComponent } from "./change-password/change-password.component";
import { MyAccountComponent } from "./my-account.component";
import { MyDataComponent } from "./my-data/my-data.component";
import { MyAccountDataResolveService } from "./shared/my-account-data-resolver.service";

const userRoutes: Routes = [
    {
        path: '',
        resolve: { mydata: MyAccountDataResolveService },
        children: [
            {
                path: '',
                component: MyAccountComponent,
            },
            {
                path: 'my-data',
                component: MyDataComponent,
            }, 
            {
                path: 'change-password',
                component: ChangePasswordComponent,
            },
        ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(userRoutes)],
    exports: [RouterModule],
})
export class MyAccountRoutingModule { }