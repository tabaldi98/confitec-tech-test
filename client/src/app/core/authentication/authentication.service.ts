import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAuthenticationCommand, IAuthenticationModel, IRecoveryPassCheckCommand, IRecoveryPassCommand, ITokenModel, IUpdatePassOnRecoveryCommand, IMyInformationsModel, RoleNameCanChangeGeneralSettings, RoleNameCanManageObjects, RoleNameCanManageSystemUsers, IUpdatePassCommand, IUpdateMySelfCommand } from './authentication.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LocalStorageService } from '../local-storage/local-storage.service';
import { LocalStorageKeys } from '../local-storage/local-storage.model';
@Injectable({
    providedIn: 'root'
})
export class AuthService {
    jwtHelper: JwtHelperService = new JwtHelperService();
    lsToken?: ITokenModel;
    userApiUrl = `${environment.apiUrl}Login`;

    constructor(private http: HttpClient, private localStorage: LocalStorageService) { }

    get token(): ITokenModel {
        if (!this.lsToken) {
            const token: any = this.localStorage.getValue(LocalStorageKeys.Token);

            if (token) {
                this.lsToken = this.jwtHelper.decodeToken(token);
            }
        }

        return this.lsToken || <ITokenModel>{};
    }

    get hasCanManageObjectsRole(): boolean {
        return this.token.role.includes(RoleNameCanManageObjects);
    }

    get hasCanManageSystemUsersRole(): boolean {
        return this.token.role.includes(RoleNameCanManageSystemUsers);
    }

    get hasCanChangeGeneralSettingsRole(): boolean {
        return this.token.role.includes(RoleNameCanChangeGeneralSettings);
    }

    login(command: IAuthenticationCommand): Observable<IAuthenticationModel> {
        return this.http.post<IAuthenticationModel>(`${this.userApiUrl}/token`, command);
    }

    recoveryPassword(command: IRecoveryPassCommand): Observable<boolean> {
        return this.http.post<boolean>(`${this.userApiUrl}/recovery-password`, command);
    }

    validateCode(command: IRecoveryPassCheckCommand): Observable<boolean> {
        return this.http.post<boolean>(`${this.userApiUrl}/check-recovery-password`, command);
    }

    updatePasswordOnRecovery(command: IUpdatePassOnRecoveryCommand): Observable<boolean> {
        return this.http.put<boolean>(`${this.userApiUrl}/update-pass`, command);
    }  
    
    updatePassword(command: IUpdatePassCommand): Observable<boolean> {
        return this.http.post<boolean>(`${this.userApiUrl}/update-pass`, command);
    }


    isAlive(): Observable<boolean> {
        return this.http.get<boolean>(`${this.userApiUrl}/is-alive`);
    }

    me(): Observable<IMyInformationsModel> {
        return this.http.get<IMyInformationsModel>(`${this.userApiUrl}/me`,);
    }

    updateMySelf(command: IUpdateMySelfCommand): Observable<boolean>{
        return this.http.put<boolean>(`${this.userApiUrl}/update-myself`, command);
    }

    logout(): void {
        this.localStorage.deleteValue(LocalStorageKeys.Token);
        window.location.reload();
    }
}

