import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ISystemUserCreateCommand, ISystemUserDeleteCommand, ISystemUserUpdateCommand } from './system-user.model';
import { SystemUser } from 'src/app/features/system-user/shared/system-user.model';

@Injectable({
    providedIn: 'root'
})
export class SystemUserService {
    userApiUrl = `${environment.apiUrl}SystemUser`;

    constructor(private http: HttpClient) { }

    create(command: ISystemUserCreateCommand): Observable<boolean> {
        return this.http.post<boolean>(`${this.userApiUrl}`, command);
    }

    get(id: number): Observable<SystemUser> {
        return this.http.get<SystemUser>(`${this.userApiUrl}/${id}`);
    }

    update(command: ISystemUserUpdateCommand): Observable<boolean> {
        return this.http.put<boolean>(this.userApiUrl, command);
    }

    delete(command: ISystemUserDeleteCommand): Observable<boolean> {
        return this.http.post<boolean>(`${this.userApiUrl}/delete`, command);
    }
}
