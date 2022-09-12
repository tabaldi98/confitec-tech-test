import {
    HttpErrorResponse,
    HttpEvent,
    HttpHandler,
    HttpInterceptor,
    HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
    NavigationEnd,
    Router,
} from '@angular/router';
import {
    Observable,
    throwError,
} from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LocalStorageKeys } from '../local-storage/local-storage.model';
import { LocalStorageService } from '../local-storage/local-storage.service';

@Injectable()
export class ClientErrorInterceptor implements HttpInterceptor {
    private static HTTP_STATUS_UNAUTHORIZED: number = 401;
    private static HTTP_STATUS_FORBIDDEN: number = 403;
    private static HTTP_STATUS_NOTFOUND: number = 404;

    constructor(private router: Router, private localStorage: LocalStorageService) { }

    public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next
            .handle(request)
            .pipe(
                catchError((reason: any) => {
                    if (reason instanceof HttpErrorResponse) {
                        switch (reason.status) {
                            case ClientErrorInterceptor.HTTP_STATUS_UNAUTHORIZED:
                                this.handleUnauthorizedRequest();
                                break;

                            case ClientErrorInterceptor.HTTP_STATUS_FORBIDDEN:
                                this.handleForbiddenRequest();
                                break;

                            case ClientErrorInterceptor.HTTP_STATUS_NOTFOUND:
                                this.handleNotFoundRequest();
                                break;

                            default:
                                break;
                        }
                    }

                    return throwError(reason);
                }),
            );
    }

    private handleUnauthorizedRequest(): void {
        try {
            this.localStorage.deleteValue(LocalStorageKeys.Token);
        } finally {
            this.router.navigate(['/login']);
        }
    }

    private handleForbiddenRequest(): void {
        this.handleUnauthorizedRequest();
    }

    private handleNotFoundRequest(): void {
        this.router.navigate(['/users']);
    }
}
