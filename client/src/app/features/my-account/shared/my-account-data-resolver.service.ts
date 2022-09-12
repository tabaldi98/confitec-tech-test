import { Injectable } from '@angular/core';
import {
    ActivatedRouteSnapshot,
    Resolve,
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { AuthService } from 'src/app/core/authentication/authentication.service';


@Injectable()
export class MyAccountDataResolveService implements Resolve<any> {

    constructor(private authSerice: AuthService) { }

    public resolve(route: ActivatedRouteSnapshot): Observable<any> {
        return this.authSerice.me();
    }
}
