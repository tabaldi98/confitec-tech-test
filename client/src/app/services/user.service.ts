import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';
import { MatSnackBar } from '@angular/material/snack-bar';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable()
export class UserService {
  userApiUrl = `${environment.apiUrl}User`;
  
  constructor(private http: HttpClient, private _snackBar: MatSnackBar) { }

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.userApiUrl);
  }

  createUser(user: User): Observable<User> {
    return this.http.post<User>(this.userApiUrl, user)
      .pipe(
          tap(() => this.showSnackBar('Usuário criado com sucesso!')));
  }

  editUser(user: User): Observable<User> {
    return this.http.put<User>(this.userApiUrl, user)
      .pipe(tap(() => this.showSnackBar('Usuário alterado com sucesso!')));
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete<any>(`${this.userApiUrl}/${id}`)
      .pipe(tap(() => this.showSnackBar('Usuário deletado com sucesso!')));
  }

  showSnackBar(message: string): void {
    this._snackBar.open(message, undefined, { duration: 3000 })
  }
}

