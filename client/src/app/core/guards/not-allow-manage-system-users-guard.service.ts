import { Injectable } from '@angular/core';
import {
    CanActivate,
} from '@angular/router';
import { AuthService } from '../authentication/authentication.service';
@Injectable()
export class NotAllowManageSystemUsersGuardService implements CanActivate {

    constructor(private authService: AuthService) { }

    public canActivate(): boolean {
        if (this.authService.hasCanManageSystemUsersRole) {
            return true;
        }

        this.authService.logout();

        return false;
    }
}
