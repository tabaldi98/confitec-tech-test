import { Injectable } from '@angular/core';
import {
    ActivatedRouteSnapshot,
    Resolve,
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { HeaderService } from './header.service';


@Injectable()
export class HeadderResolveService implements Resolve<any> {

    constructor(private headerService: HeaderService) { }
    public resolve(route: ActivatedRouteSnapshot): Observable<any> {
        this.headerService.onRouteChanged.emit(route.data.title);

        return of(route.data.title);
    }
}
