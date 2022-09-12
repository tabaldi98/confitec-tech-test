import {
    HttpEvent,
    HttpHandler,
    HttpInterceptor,
    HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LocalStorageKeys } from '../local-storage/local-storage.model';
import { LocalStorageService } from '../local-storage/local-storage.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
    constructor(private localStorage: LocalStorageService) { }

    public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        request = request.clone({
            setHeaders: {
                Authorization: `Bearer ${this.localStorage.getValue(LocalStorageKeys.Token)}`,
            },
        });

        return next.handle(request);
    }
}
