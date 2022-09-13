import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { NotAllowManageObjectsGuardService } from "src/app/core/guards/not-allow-manage-objects-guard.service";
import { AnalyseComponent } from "./analyse/analyse.component";
import { SystemUserGridComponent } from "./grid/system-user-grid.component";

const userRoutes: Routes = [
    {
        path: '',
        component: SystemUserGridComponent,
    },
    // {
    //     path: 'create',
    //     component: UserAddComponent,
    //     canActivate: [NotAllowManageObjectsGuardService]
    // },
    {
        path: ':id',
        children: [
            {
                path: '',
                component: AnalyseComponent,
                canActivate: [NotAllowManageObjectsGuardService]
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(userRoutes)],
    exports: [RouterModule],
})
export class SystemUserRoutingModule { }