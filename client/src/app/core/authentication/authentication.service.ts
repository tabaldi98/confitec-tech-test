import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAuthenticationCommand, IAuthenticationModel, ITokenModel } from './authentication.model';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
    providedIn: 'root'
})
export class AuthService {
    jwtHelper: JwtHelperService = new JwtHelperService();
    lsToken?: ITokenModel;
    userApiUrl = `${environment.apiUrl}Login`;

    constructor(private http: HttpClient) { }

    get token(): ITokenModel {
        if (!this.lsToken) {
            const token: any = localStorage.getItem('token');

            if (token) {
                this.lsToken = this.jwtHelper.decodeToken(token);
            }
        }

        return this.lsToken || <ITokenModel>{};
    }

    login(command: IAuthenticationCommand): Observable<IAuthenticationModel> {
        return this.http.post<IAuthenticationModel>(`${this.userApiUrl}/token`, command);
    }

    isAlive(): Observable<boolean> {
        return this.http.get<boolean>(`${this.userApiUrl}/is-alive`);
    }

    logout(): void {
        localStorage.removeItem('token');
        window.location.reload();
    }
}

