import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ISetting, ISettingUpdateCommand } from './settings.model';
import { SnackBarService } from 'src/app/core/snack-bar/snack-bar.service';

@Injectable()
export class SettingsService {
  settingApiUrl = `${environment.apiUrl}Parameter`;

  constructor(
    private http: HttpClient,
    private snackBarService: SnackBarService) { }

  get(id: number): Observable<ISetting> {
    return this.http.get<ISetting>(`${this.settingApiUrl}/${id}`);
  }

  getAll(): Observable<ISetting[]> {
    return this.http.get<ISetting[]>(this.settingApiUrl);
  }

  edit(command: ISettingUpdateCommand): Observable<boolean> {
    return this.http.put<boolean>(this.settingApiUrl, command)
      .pipe(tap(() => this.snackBarService.showSucessSnackBar('Configuração alterada com sucesso!')));
  }
}

