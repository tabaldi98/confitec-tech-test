import { Injectable } from '@angular/core';
import {
    CanActivate,
    CanLoad,
} from '@angular/router';
import {
    Observable,
    of as observableOf,
} from 'rxjs';
import { tap } from 'rxjs/operators';
import { AuthService } from './authentication.service';


@Injectable()
export class AuthGuardService implements CanLoad, CanActivate {
    constructor(private authService: AuthService) { }

    public canLoad(): Observable<boolean> {

        return this.authService.isAlive()
            .pipe(tap((response: boolean) => {
                if (!response) {
                    this.authService.logout();
                }
            }));
    }

    public canActivate(): Observable<boolean> {
        return this.canLoad();
    }
}
