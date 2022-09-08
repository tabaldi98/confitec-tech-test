import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAuthenticationCommand, IAuthenticationModel } from './authentication.model';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    userApiUrl = `${environment.apiUrl}Login`;

    constructor(private http: HttpClient) { }

    login(command: IAuthenticationCommand): Observable<IAuthenticationModel> {
        return this.http.post<IAuthenticationModel>(`${this.userApiUrl}/token`, command);
    }
    
    isAlive(): Observable<boolean> {
        return this.http.get<boolean>(`${this.userApiUrl}/is-alive`);
    }
}

