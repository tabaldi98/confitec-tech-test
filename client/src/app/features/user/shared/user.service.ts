import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User, UserCreateCommand, UserDeleteCommand, UserUpdateCommand } from './user.model';
import { SnackBarService } from 'src/app/core/snack-bar/snack-bar.service';

@Injectable()
export class UserService {
  userApiUrl = `${environment.apiUrl}User`;

  constructor(
    private http: HttpClient,
     private snackBarService: SnackBarService) { }

  get(id: number): Observable<User> {
    return this.http.get<User>(`${this.userApiUrl}/${id}`);
  }

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.userApiUrl)
      .pipe(map((users: User[]) => {
        users.forEach((user: User) => {
          user.checked = false;
        })

        return users;
      }));
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

