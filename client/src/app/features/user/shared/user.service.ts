import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User, UserCreateCommand, UserDeleteCommand, UserUpdateCommand } from './user.model';
import { SnackBarService } from 'src/app/core/snack-bar/snack-bar.service';
import { IODataModel } from 'src/app/shared/grid/models/odata.model';

@Injectable()
export class UserService {
  userApiUrl = `${environment.apiUrl}User`;

  constructor(
    private http: HttpClient,
     private snackBarService: SnackBarService) { }

  get(id: number): Observable<User> {
    return this.http.get<User>(`${this.userApiUrl}/${id}`);
  }

  getAllUsers(): Observable<IODataModel<User>> {
    return this.http.get<IODataModel<User>>(`${environment.odataUrl}UsersOData?count=true&top=100`);
  }

  createUser(user: UserCreateCommand): Observable<number> {
    return this.http.post<number>(this.userApiUrl, user)
      .pipe(
        tap(() => this.showSnackBar('Usuário criado com sucesso!')));
  }

  editUser(user: UserUpdateCommand): Observable<User> {
    return this.http.put<User>(this.userApiUrl, user)
      .pipe(tap(() => this.showSnackBar('Usuário alterado com sucesso!')));
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete<any>(`${this.userApiUrl}/${id}`)
      .pipe(tap(() => this.showSnackBar('Usuário deletado com sucesso!')));
  }

  deleteManyUsers(command: UserDeleteCommand): Observable<boolean> {
    return this.http.post<boolean>(`${this.userApiUrl}/deleteMany`, command)
      .pipe(tap(() => this.showSnackBar('Usuários deletados com sucesso!')));
  }

  showSnackBar(message: string): void {
    this.snackBarService.showSucessSnackBar(message)
  }
}

