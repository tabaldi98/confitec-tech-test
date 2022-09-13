import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './core/authentication/auth-guard.service';
import { HeadderResolveService as HeaderResolveService } from './shared/header/shared/header-resolve.service';

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
    path: 'recovery-password',
    loadChildren: () => import('./features/recovery-pass/recovery-pass.module').then(x => x.RecoveryPassModule),
  }, 
  {
    path: 'register',
    loadChildren: () => import('./features/register/register.module').then(x => x.RegisterModule),
  },
  {
    path: 'users',
    loadChildren: () => import('./features/user/user.module').then(x => x.UserModule),
    canActivate: [AuthGuardService],
    data: {
      title: 'Usuários'
    },
    resolve: [HeaderResolveService]
  },
  {
    path: 'settings',
    loadChildren: () => import('./features/settings/settings.module').then(x => x.SettingsModule),
    canActivate: [AuthGuardService],
    data: {
      title: 'Configurações'
    },
    resolve: [HeaderResolveService]
  },
  {
    path: 'my-account',
    loadChildren: () => import('./features/my-account/my-account.module').then(x => x.MyAccountModule),
    canActivate: [AuthGuardService],
    data: {
      title: 'Minha conta'
    },
    resolve: [HeaderResolveService]
  },
  {
    path: 'system-users',
    loadChildren: () => import('./features/system-user/system-user.module').then(x => x.SystemUserModule),
    canActivate: [AuthGuardService],
    data: {
      title: 'Usuários do sistema'
    },
    resolve: [HeaderResolveService]
  },
  { path: '**', redirectTo: 'users', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
