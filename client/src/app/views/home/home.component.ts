import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTable } from '@angular/material/table';
import { User } from 'src/app/models/User';
import { UserScholarity } from 'src/app/models/user.scholarity.enum';
import { UserService } from 'src/app/services/user.service';
import { ConfirmDeleteComponent } from 'src/app/shared/confirm-delete/confirm-delete.component';
import { ElementDialogComponent } from 'src/app/shared/element-dialog/element-dialog.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [UserService]
})
export class HomeComponent implements OnInit {
  @ViewChild(MatTable) table!: MatTable<any>;
  displayedColumns: string[] = ['name', 'surname', 'mail', 'birthDate', 'scholarity', 'actions'];
  dataSource!: User[];

  constructor(
    public dialog: MatDialog,
    public userService: UserService,
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.updateTable();
  }

  openDialog(user: User | null): void {
    const dialogRef = this.dialog.open(ElementDialogComponent, {
      width: '250px',
      data: user === null ? {
        id: null,
        name: null,
        surname: null,
        mail: null,
        birthDate: null,
        scholarity: null
      } : {
        id: user.id,
        name: user.name,
        surname: user.surname,
        mail: user.mail,
        birthDate: user.birthDate,
        scholarity: user.scholarity
      }
    });

    dialogRef.afterClosed()
      .subscribe(
        result => {
          if (result !== undefined) {
            if (this.dataSource.map(p => p.id).includes(result.id)) {
              this.userService
                .editUser(result)
                .subscribe(
                  () => {
                    this.updateTable();
                    this.table.renderRows();
                  },
                  () => {
                    this.showSnackBar();
                    this.openDialog(result);
                  });
            } else {
              this.userService
                .createUser(result)
                .subscribe(
                  () => {
                    this.updateTable();
                    this.table.renderRows();
                  },
                  () => {
                    this.showSnackBar();
                    this.openDialog(result);
                  });
            }
          }
        });
  }

  editElement(element: User): void {
    this.openDialog(element);
  }

  deleteElement(user: User): void {
    const dialogRef = this.dialog.open(ConfirmDeleteComponent, {
      width: '250px',
      data: user
    });

    dialogRef.afterClosed()
      .subscribe(
        result => {
          if (result) {
            this.userService
              .deleteUser(user.id)
              .subscribe(() => {
                this.dataSource = this.dataSource.filter(p => p.id !== user.id);
              });
          }
        });
  }

  updateTable(): void {
    this.userService.getAllUsers()
      .subscribe((data: User[]) => {
        this.dataSource = data;
      });
  }

  formatScholarity(scholarity: UserScholarity): string {
    switch (scholarity) {
      default:
      case UserScholarity.Infantile:
        return 'Infantil';
      case UserScholarity.Fundamental:
        return 'Fundamental';
      case UserScholarity.Medium:
        return 'Médio';
      case UserScholarity.Higher:
        return 'Superior';
    }
  }

  showSnackBar(): void {
    this._snackBar.open('Já existe um usuário cadastrado com esse nome!', undefined, { duration: 3000 })
  }
}
