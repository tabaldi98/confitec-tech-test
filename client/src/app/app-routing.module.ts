import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './core/authentication/auth-guard.service';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'users',
    pathMatch: 'full',
  },
  {
    path: 'login',
    loadChildren: () => import('./features/login/login.module').then(x => x.LoginModule),
  },
  {
    path: 'users',
    loadChildren: () => import('./features/user/user.module').then(x => x.UserModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'settings',
    loadChildren: () => import('./features/settings/settings.module').then(x => x.SettingsModule),
    canActivate: [AuthGuardService],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
