import { Injectable } from '@angular/core';
import {
    CanActivate,
} from '@angular/router';
import { AuthService } from '../authentication/authentication.service';
@Injectable()
export class NotAllowManageGeneralSettingsGuardService implements CanActivate {

    constructor(private authService: AuthService) { }

    public canActivate(): boolean {
        if (this.authService.hasCanChangeGeneralSettingsRole) {
            return true;
        }

        this.authService.logout();

        return false;
    }
}
