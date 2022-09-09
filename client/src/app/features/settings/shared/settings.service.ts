import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ISetting, ISettingUpdateCommand } from './settings.model';

@Injectable()
export class SettingsService {
  settingApiUrl = `${environment.apiUrl}Parameter`;

  constructor(private http: HttpClient, private _snackBar: MatSnackBar) { }

  get(id: number): Observable<ISetting> {
    return this.http.get<ISetting>(`${this.settingApiUrl}/${id}`);
  }

  getAll(): Observable<ISetting[]> {
    return this.http.get<ISetting[]>(this.settingApiUrl);
  }

  edit(command: ISettingUpdateCommand): Observable<boolean> {
    return this.http.put<boolean>(this.settingApiUrl, command)
      .pipe(tap(() => this.showSnackBar('Configuração alterada com sucesso!')));
  }

  showSnackBar(message: string): void {
    this._snackBar.open(message, undefined, { duration: 3000 })
  }
}

